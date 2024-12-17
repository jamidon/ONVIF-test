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
    sealed public class PTZClient
    {
        private DeviceTime DeviceTime { get; set; }
        private PTZ.PTZClient Client { get; set; }
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

        public PTZClient(EndpointAddress epa, string username, string password)
        {
            // create a device time object
            DeviceTime = new DeviceTime(epa.Uri);

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

            Client = new PTZ.PTZClient(bind, epa);
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                var pdb = new PasswordDigestBehavior(username, password);
                pdb.callback += () =>
                {
                    return DeviceTime.DeviceTimestamp();
                };
                Client.Endpoint.EndpointBehaviors.Add(pdb);
            }

            // not initialized
            IsInitialized = false;
        }

        public PTZClient(string uri, string username, string password)
            : this(new EndpointAddress(uri), username, password)
        { }

        private bool IsInitialized { get; set; }

        #region internal camera parameters

        private PTZ.PTZConfiguration[] ptzConfigurations { get; set; }
        private PTZ.PTZNode ptzNode { get; set; }
        private float ptzPanSpeedMin = 0;
        private float ptzPanSpeedMax = 1;
        private float ptzTiltSpeedMin = 0;
        private float ptzTiltSpeedMax = 1;
        private float ptzZoomSpeedMin = 0;
        private float ptzZoomSpeedMax = 1;

        #endregion

        public void GetConfiguration(string profileToken)
        {
            if (!IsInitialized)
            {
                var mediaClient = new MediaClient(EndPointAddress, Username, Password);
                var profile = mediaClient.GetProfile(profileToken);

                if (!string.IsNullOrWhiteSpace(profile.PTZConfiguration.NodeToken))
                {
                    var node = Client.GetNode(profile.PTZConfiguration.NodeToken);

                    // grab continuous move since that what we care about
                    var cmPanTiltSpace = node.SupportedPTZSpaces.ContinuousPanTiltVelocitySpace.FirstOrDefault();
                    if (cmPanTiltSpace != null)
                    {
                        ptzPanSpeedMax = cmPanTiltSpace.XRange.Max;
                        ptzPanSpeedMin = cmPanTiltSpace.XRange.Min;
                        ptzTiltSpeedMax = cmPanTiltSpace.YRange.Max;
                        ptzTiltSpeedMin = cmPanTiltSpace.YRange.Min;
                    }
                    else
                    {
                        ptzPanSpeedMax = profile.PTZConfiguration.PanTiltLimits.Range.XRange.Max;
                        ptzPanSpeedMin = profile.PTZConfiguration.PanTiltLimits.Range.XRange.Min;
                        ptzTiltSpeedMax = profile.PTZConfiguration.PanTiltLimits.Range.YRange.Max;
                        ptzTiltSpeedMin = profile.PTZConfiguration.PanTiltLimits.Range.YRange.Min;
                    }

                    var cmZoomSpace = node.SupportedPTZSpaces.ContinuousZoomVelocitySpace.FirstOrDefault();
                    if (cmZoomSpace != null)
                    {
                        ptzZoomSpeedMax = cmZoomSpace.XRange.Max;
                        ptzZoomSpeedMin = cmZoomSpace.XRange.Min;
                    }
                    else
                    {
                        ptzZoomSpeedMax = profile.PTZConfiguration.ZoomLimits.Range.XRange.Max;
                        ptzZoomSpeedMin = profile.PTZConfiguration.ZoomLimits.Range.XRange.Min;
                    }
                }
                else
                {
                    ptzPanSpeedMax = profile.PTZConfiguration.PanTiltLimits.Range.XRange.Max;
                    ptzPanSpeedMin = profile.PTZConfiguration.PanTiltLimits.Range.XRange.Min;
                    ptzTiltSpeedMax = profile.PTZConfiguration.PanTiltLimits.Range.YRange.Max;
                    ptzTiltSpeedMin = profile.PTZConfiguration.PanTiltLimits.Range.YRange.Min;
                    ptzZoomSpeedMax = profile.PTZConfiguration.ZoomLimits.Range.XRange.Max;
                    ptzZoomSpeedMin = profile.PTZConfiguration.ZoomLimits.Range.XRange.Min;
                }

                IsInitialized = true;
            }
        }
        public void Stop(string profileToken)
        {
            Client.Stop(profileToken, true, true);
        }
        public void Move(string profileToken, PTZ.PTZSpeed velocity, string timeout = null)
        {
            // maybe get configuration
            GetConfiguration(profileToken);

            Client.ContinuousMove(profileToken, velocity, timeout);
        }
        public void ZoomOut(string profileToken, double percentSpeed = 0.1)
        {
            Move(profileToken,
                new PTZ.PTZSpeed { Zoom = new PTZ.Vector1D { x = (float)(-ptzZoomSpeedMax * percentSpeed) } });
        }
        public void ZoomIn(string profileToken, double percentSpeed = 0.1)
        {
            Move(profileToken,
                new PTZ.PTZSpeed { Zoom = new PTZ.Vector1D { x = (float)(ptzZoomSpeedMax * percentSpeed) } });
        }
        public void PanLeft(string profileToken, double percentSpeed = 0.1)
        {
            Move(profileToken,
                new PTZ.PTZSpeed { PanTilt = new PTZ.Vector2D { x = (float)(-ptzPanSpeedMax * percentSpeed) } });
        }
        public void PanRight(string profileToken, double percentSpeed = 0.1)
        {
            Move(profileToken,
                new PTZ.PTZSpeed { PanTilt = new PTZ.Vector2D { x = (float)(ptzPanSpeedMax * percentSpeed) } });
        }
        public void TiltUp(string profileToken, double percentSpeed = 0.1)
        {
            Move(profileToken,
                new PTZ.PTZSpeed { PanTilt = new PTZ.Vector2D { y = (float)(ptzTiltSpeedMax * percentSpeed) } });
        }
        public void TiltDown(string profileToken, double percentSpeed = 0.1)
        {
            Move(profileToken,
                new PTZ.PTZSpeed { PanTilt = new PTZ.Vector2D { y = (float)(-ptzTiltSpeedMax * percentSpeed) } });
        }
        public void MoveDownLeft(string profileToken, double percentSpeed = 0.1)
        {
            Move(profileToken,
                new PTZ.PTZSpeed { PanTilt = new PTZ.Vector2D { x = (float)(-ptzPanSpeedMax * percentSpeed), y = (float)(-ptzPanSpeedMax * percentSpeed) } });
        }
        public void MoveDownRight(string profileToken, double percentSpeed = 0.1)
        {
            Move(profileToken,
                new PTZ.PTZSpeed { PanTilt = new PTZ.Vector2D { x = (float)(ptzPanSpeedMax * percentSpeed), y = (float)(-ptzPanSpeedMax * percentSpeed) } });
        }
        public void MoveUpLeft(string profileToken, double percentSpeed = 0.1)
        {
            Move(profileToken,
                new PTZ.PTZSpeed { PanTilt = new PTZ.Vector2D { x = (float)(-ptzPanSpeedMax * percentSpeed), y = (float)(ptzPanSpeedMax * percentSpeed) } });
        }
        public void MoveUpRight(string profileToken, double percentSpeed = 0.1)
        {
            Move(profileToken,
                new PTZ.PTZSpeed { PanTilt = new PTZ.Vector2D { x = (float)(ptzPanSpeedMax * percentSpeed), y = (float)(ptzPanSpeedMax * percentSpeed) } });
        }
        public void GotoPreset(string profileToken, string presetToken)
        {
            Client.GotoPreset(profileToken, presetToken, new PTZ.PTZSpeed());
            //Client.GotoPreset(profileToken, presetToken, new PTZ.PTZSpeed
            //{
            //    Zoom = new PTZ.Vector1D { x = (float)(ptzZoomSpeedMax * percentSpeed) },
            //    PanTilt = new PTZ.Vector2D
            //    {
            //        x = (float)(ptzPanSpeedMax * percentSpeed),
            //        y = (float)(ptzPanSpeedMax * percentSpeed)
            //    }
            //});
        }
        public void GotoPosition(string profileToken, PTZ.PTZVector position)
        {
            Client.AbsoluteMove(profileToken, position, new PTZ.PTZSpeed());
            //Client.AbsoluteMove(profileToken, position, new PTZ.PTZSpeed
            //{
            //    PanTilt = new PTZ.Vector2D
            //    {
            //        x = (float)(ptzPanSpeedMax * percentSpeed),
            //        y = (float)(ptzPanSpeedMax * percentSpeed)
            //    }
            //});
        }
        public void SetPreset(string profileToken, string presetName, ref string presetToken)
        {
            Client.SetPreset(profileToken, presetName, ref presetToken);
        }
        public void DeletePreset(string profileToken, string presetToken)
        {
            Client.RemovePreset(profileToken, presetToken);
        }
        public void DeletePresetByName(string profileToken, string presetName)
        {
            var presets = GetPresets(profileToken);
            var preset = presets.Where(p => p.Name == presetName).FirstOrDefault();

            DeletePreset(profileToken, preset.token);
        }

        public PTZ.PTZPreset[] GetPresets(string profileToken)
        {
            return Client.GetPresets(profileToken);
        }
        public PTZ.PTZStatus GetStatus(string profileToken)
        {
            return Client.GetStatus(profileToken);
        }
    }
}
