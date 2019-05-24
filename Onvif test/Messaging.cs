using System;
using System.Security.Cryptography;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;

namespace Onvif_test
{
    // thanks to
    // http://developer.pearson.com/blog/navigating-legacy-soap-api-authentication-wcf
    // I was able to eliminate using the crusty Microsoft.Web.Services3 assembly
    public class SecurityHeader: MessageHeader
    {
        private string Username { get; set; }
        private string Password { get; set; }

        public SecurityHeader(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public override bool MustUnderstand => false;
        public override string Name => "Security";
        public override string Namespace => "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            // Create the Nonce
            byte[] nonce = GenerateNonce();

            // Create the Created Date
            string created = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            // Create the WSSE Security Header, starting with the Username Element
            writer.WriteStartElement("wsse", "UsernameToken", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            writer.WriteXmlnsAttribute("wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
            writer.WriteStartElement("wsse", "Username", null);
            writer.WriteString(Username);
            writer.WriteEndElement();

            // Add the Password Element
            writer.WriteStartElement("wsse", "Password", null);
            writer.WriteAttributeString("Type", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest");
            writer.WriteString(GeneratePasswordDigest(nonce, created, Password));
            writer.WriteEndElement();

            // Add the Nonce Element
            writer.WriteStartElement("wsse", "Nonce", null);
            writer.WriteAttributeString("EncodingType", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary");
            writer.WriteBase64(nonce, 0, nonce.Length);
            writer.WriteEndElement();

            // Lastly, add the Created Element
            writer.WriteStartElement("wsu", "Created", null);
            writer.WriteString(created);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();
        }
        /// <summary>
        /// Generates a random Nonce for encryption purposes
        /// </summary>
        /// <returns>byte[]</returns>
        private byte[] GenerateNonce()
        {
            RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
            byte[] buf = new byte[0x10];
            rand.GetBytes(buf);

            return buf;
        }

        /// <summary>
        /// Generates the PasswordDigest using a SHA1 Hash
        /// </summary>
        /// <param name="nonceBytes">byte[]</param>
        /// <param name="created">string</param>
        /// <param name="password">string</param>
        /// <returns>string</returns>
        private string GeneratePasswordDigest(byte[] nonceBytes, string created, string password)
        {
            // Convert the values to be hashed to bytes
            byte[] createdBytes = Encoding.UTF8.GetBytes(created);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] msgBytes = new byte[nonceBytes.Length + createdBytes.Length + passwordBytes.Length];

            // Combine the values into one byte array
            Array.Copy(nonceBytes, msgBytes, nonceBytes.Length);
            Array.Copy(createdBytes, 0, msgBytes, nonceBytes.Length, createdBytes.Length);
            Array.Copy(passwordBytes, 0, msgBytes, (nonceBytes.Length + createdBytes.Length), passwordBytes.Length);

            // Generate the hash
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] hashBytes = sha1.ComputeHash(msgBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }

    public class PasswordDigestMessageInspector : IClientMessageInspector
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public PasswordDigestMessageInspector(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

#region IClientMessageInspector Members

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            //throw new NotImplementedException();
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            var securityHeader = new SecurityHeader(Username, Password);
            request.Headers.Add(securityHeader);

            // complete
            return Convert.DBNull;
        }

#endregion
    }

    /// <summary>
    /// Custom Endpoint Behavior to provide a Client Client behavior
    /// </summary>
    public class PasswordDigestBehavior : IEndpointBehavior
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public PasswordDigestBehavior(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

#region IEndpointBehavior Members

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            //throw new NotImplementedException();
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new PasswordDigestMessageInspector(this.Username, this.Password));
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            //throw new NotImplementedException();
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            //throw new NotImplementedException();
        }

#endregion
    }
}