using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Onvif_test
{
    sealed public class Vapix3Client
    {
        private const string URI_CTRL = "ptz.cgi?";

        private const string CMD_QUERY_AUX = "query=auxiliary";
        private const string CMD_SEND_AUX = "auxiliary=";

        private string Username { get; }
        private string Password { get; }
        private string IpAddress { get; }
        HttpWebRequest _myReq;
        HttpWebResponse _myRsp;

        public int DropId { get; set; }
        public bool UseDigest { get; set; }


        public Vapix3Client(string address, string username, string password)
        {
            IpAddress = address;
            Username = username;
            Password = password;
            DropId = 1;
        }

        public string[] GetAuxFunctions()
        {
            var rspString = QueryAux();

            var auxFunctions = new List<string>();
            var delimiters = new string[] { "\r\n" };
            foreach (var af in rspString.Split(delimiters, StringSplitOptions.None))
            {
                if (string.IsNullOrWhiteSpace(af) || 
                    af[0] == '\0' ||
                    af.ToLower().IndexOf("commands") != -1)
                {
                    continue;
                }
                auxFunctions.Add(af);
            }

            return auxFunctions.ToArray();
        }

        public string SendAuxCommand(string cmd)
        {
            return SendAux(cmd);
        }

        #region low-level commands

        private string SendAux(string cmd)
        {
            SendCmd(string.Format("{0}{1}", CMD_SEND_AUX, cmd), URI_CTRL);
            try
            {
                _myRsp = (HttpWebResponse)_myReq.GetResponse();
                string rspString = "";

                using (Stream stm = _myRsp.GetResponseStream())
                {
                    int cnt = 0;
                    byte[] buffer = new Byte[4096];
                    int bytes2read = (int)buffer.Length;

                    while (bytes2read > 0)
                    {
                        cnt = stm.Read(buffer, 0, bytes2read);

                        if (cnt == 0)
                            break;

                        ASCIIEncoding enc = new ASCIIEncoding();

                        rspString = enc.GetString(buffer);

                        bytes2read--;
                    }
                }

                return rspString;
            }
            finally
            {
                CloseResponse();
            }
        }

        private string QueryAux()
        {
            SendCmd(CMD_QUERY_AUX, URI_CTRL);

            try
            {
                _myRsp = (HttpWebResponse)_myReq.GetResponse();
                string rspString = "";

                using (Stream stm = _myRsp.GetResponseStream())
                {
                    int cnt = 0;
                    byte[] buffer = new Byte[4096];
                    int bytes2read = (int)buffer.Length;

                    while (bytes2read > 0)
                    {
                        cnt = stm.Read(buffer, 0, bytes2read);

                        if (cnt == 0)
                            break;

                        ASCIIEncoding enc = new ASCIIEncoding();

                        rspString = enc.GetString(buffer);

                        bytes2read--;
                    }
                }

                return rspString;
            }
            finally
            {
                CloseResponse();
            }
        }

        private void SendCmd(string cmd, string uri)
        {
            int portNum = 80;
            var urlWithCommand = string.Format("http://{0}:{1}/axis-cgi/com/{2}camera={3}&{4}", 
                IpAddress, portNum, uri, DropId, cmd);

            CredentialCache myCache = new CredentialCache();
            myCache.Add(new Uri(string.Format("http://{0}:{1}", IpAddress, portNum)), "Basic", new NetworkCredential(Username, Password));
            myCache.Add(new Uri(string.Format("http://{0}:{1}", IpAddress, portNum)), "Digest", new NetworkCredential(Username, Password));

            _myRsp = null;
            _myReq = null;
            _myReq = (HttpWebRequest)WebRequest.Create(urlWithCommand);
            _myReq.Credentials = myCache;
            _myReq.KeepAlive = true;
        }

        private void CloseResponse()
        {
            if (_myRsp != null)
            {
                _myRsp.Close();
                _myRsp = null;
            }
        }

        #endregion
    }
}
