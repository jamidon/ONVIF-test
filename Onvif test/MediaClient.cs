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
    sealed public class MediaClient
    {
        private DeviceTime DeviceTime { get; set; }
        private Media.MediaClient Client { get; set; }
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

        public MediaClient(EndpointAddress epa, string username, string password)
        {
            // create a device time object
            DeviceTime = new DeviceTime(epa.Uri);

            var httpBinding = new HttpTransportBindingElement
            {
                AuthenticationScheme = AuthenticationSchemes.Digest
            };

            var messageElement = new TextMessageEncodingBindingElement
            {
                MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None)
            };

            var bind = new CustomBinding(messageElement, httpBinding);

            Client = new Media.MediaClient(bind, epa);
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                var pdb = new PasswordDigestBehavior(username, password);
                pdb.callback += () =>
                {
                    return DeviceTime.DeviceTimestamp();
                };
                Client.Endpoint.EndpointBehaviors.Add(pdb);
            }
        }

        public MediaClient(string uri, string username, string password)
            : this(new EndpointAddress(uri), username, password)
        { }

        public Media.Profile[] GetProfiles()
        {
            return Client.GetProfiles();
        }

        public Media.Profile GetProfile(string profileToken)
        {
            return Client.GetProfile(profileToken);
        }

        public Media.VideoSourceConfiguration[] GetVideoSourceConfigurations()
        {
            return Client.GetVideoSourceConfigurations();
        }

        public Media.MediaUri[] GetStreamURIs(Media.Profile[] profiles)
        {
            var list = new List<Media.MediaUri>();
            var setup = new Media.StreamSetup();
            setup.Transport = new Media.Transport();
            foreach (var p in profiles.Where(p => p.VideoEncoderConfiguration.Multicast.Address.IPv4Address == "0.0.0.0"))
            {
                setup.Stream = Media.StreamType.RTPUnicast;
                setup.Transport.Protocol = Media.TransportProtocol.RTSP;
                try
                {
                    list.Add(Client.GetStreamUri(setup, p.token));
                }
                catch { }
            }

            foreach (var p in profiles.Where(p => p.VideoEncoderConfiguration.Multicast.Address.IPv4Address != "0.0.0.0"))
            {
                setup.Stream = Media.StreamType.RTPMulticast;
                setup.Transport.Protocol = Media.TransportProtocol.UDP;
                try
                {
                    list.Add(Client.GetStreamUri(setup, p.token));
                }
                catch { }
            }

            return list.ToArray();
        }
    }
}