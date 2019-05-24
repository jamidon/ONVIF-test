using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Onvif_test
{
    sealed public class DeviceClient
    {
        private Device.DeviceClient Client { get; set; }
        private EndpointAddress EndPointAddress { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }

        public int OpenTimeout
        {
            get
            {
                if (Client == null || Client.Endpoint == null)
                {
                    throw new InvalidOperationException("internal object is null");
                }
                return Convert.ToInt32(Client.Endpoint.Binding.OpenTimeout.TotalMilliseconds);
            }
            set
            {
                Client.Endpoint.Binding.OpenTimeout = new TimeSpan(0, 0, 0, 0, value);
            }
        }
        public int SendTimeout
        {
            get
            {
                if (Client == null || Client.Endpoint == null)
                {
                    throw new InvalidOperationException("internal object is null");
                }
                return Convert.ToInt32(Client.Endpoint.Binding.SendTimeout.TotalMilliseconds);
            }
            set
            {
                Client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 0, value);
            }
        }

        public DeviceClient(EndpointAddress epa, string username, string password)
        {
            EndPointAddress = epa;
            Username = username;
            Password = password;

            var httpBinding = new HttpTransportBindingElement
            {
                AuthenticationScheme = AuthenticationSchemes.Digest
            };

            var messageElement = new TextMessageEncodingBindingElement
            {
                MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None)
            };

            var bind = new CustomBinding(messageElement, httpBinding);

            Client = new Device.DeviceClient(bind, epa);
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                Client.Endpoint.EndpointBehaviors.Add(new PasswordDigestBehavior(username, password));
            }
        }

        public DeviceClient(string uri, string username, string password)
            : this(new EndpointAddress(uri), username, password)
        { }

        public Device.Scope[] GetScopes()
        {
            return Client.GetScopes();
        }
        public Device.DeviceServiceCapabilities GetServiceCapabilities()
        {
            return Client.GetServiceCapabilities();
        }
        public Device.Service[] GetServices()
        {
            return Client.GetServices(true);
        }
        public Device.Capabilities GetCapabilities()
        {
            return Client.GetCapabilities(new[] { Device.CapabilityCategory.All });
        }
        public string GetDeviceInformation(out string model, out string firmwareVersion, out string serialNumber, out string hardwareId)
        {
            return Client.GetDeviceInformation(out model, out firmwareVersion, out serialNumber, out hardwareId);
        }
        public string SendAuxCommand(string auxCommand)
        {
            return Client.SendAuxiliaryCommand(auxCommand);
        }
    }
}