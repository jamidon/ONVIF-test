﻿using Microsoft.Web.Services3.Security.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Windows.Forms;
using System.Xml;

namespace Onvif_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PtzClient ptzClient { get; set; }
        PTZ.PTZPreset[] ptzPresets { get; set; }
        PTZ.PTZStatus ptzStatus { get; set; }

        MediaClient mediaClient { get; set; }
        Media.Profile[] mediaProfiles { get; set; }
        Media.MediaUri[] mediaURIs { get; set; }

        DeviceIO.DeviceClient deviceClient { get; set; }
        DeviceIO.Capabilities capabilities { get; set; }

        void createDeviceClient()
        {
            var serviceAddress = new EndpointAddress(textBoxUrl.Text);
            var httpBinding = new HttpTransportBindingElement();

            httpBinding.AuthenticationScheme = AuthenticationSchemes.Digest;

            var messageElement = new TextMessageEncodingBindingElement();

            messageElement.MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None);

            var bind = new CustomBinding(messageElement, httpBinding);

            deviceClient = new DeviceIO.DeviceClient(bind, serviceAddress);
            deviceClient.ClientCredentials.UserName.UserName = textBoxUsername.Text;
            deviceClient.ClientCredentials.UserName.Password = textBoxPassword.Text;
        }

        void createPtzClient()
        {
            var serviceAddress = new EndpointAddress(textBoxUrl.Text);
            ptzClient = new PtzClient(serviceAddress, textBoxUsername.Text, textBoxPassword.Text);
        }

        private void buttonGetCapabilities_Click(object sender, EventArgs e)
        {
            if (deviceClient == null)
            {
                createDeviceClient();
            }

            try
            {
                capabilities = deviceClient.GetCapabilities(new[] { DeviceIO.CapabilityCategory.All });
                this.toolTip1.SetToolTip(buttonGetCapabilities, capabilities.PTZ.XAddr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetCapabilities failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGetPresets_Click(object sender, EventArgs e)
        {
            try
            {
                ptzPresets = ptzClient.GetPresets(comboBoxProfileTokens.SelectedItem.ToString());
                if (ptzPresets.Length > 0)
                {
                    comboBoxPresets.Items.Clear();
                    comboBoxPresets.Items.AddRange(ptzPresets.Select(p => p.Name).ToArray());
                    comboBoxPresets.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetPresets failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGetProfiles_Click(object sender, EventArgs e)
        {
            if (mediaClient == null)
            {
                createMediaClient();
            }
            if (ptzClient==null)
            {
                createPtzClient();
            }
            this.mediaProfiles = mediaClient.GetProfiles();
            if (mediaProfiles.Length > 0)
            {
                this.toolTip1.SetToolTip(sender as Button,
                    String.Join(",", mediaProfiles.Select(p => p.token).ToArray()));

                comboBoxProfileTokens.Items.Clear();
                comboBoxProfileTokens.Items.AddRange(mediaProfiles.Select(p => p.token).ToArray());
                comboBoxProfileTokens.Enabled = true;

                buttonGetStreamURI.Enabled = true;
            }
        }

        private void createMediaClient()
        {
            var serviceAddress = new EndpointAddress(textBoxUrl.Text);
            mediaClient = new MediaClient(serviceAddress, textBoxUsername.Text, textBoxPassword.Text);
        }

        private void buttonPresetGo_Click(object sender, EventArgs e)
        {
            var name = comboBoxPresets.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(name))
            {
                var preset = ptzPresets.Where(p => p.Name == name).FirstOrDefault();
                if (preset == null)
                {
                    MessageBox.Show(string.Format("Finding {0} failed", name), "Lookup failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    ptzClient.GotoPreset(comboBoxProfileTokens.SelectedItem.ToString(), preset.token);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Goto preset failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = comboBoxPresets.SelectedItem.ToString();
            buttonPresetGo.Enabled = ptzPresets.Length > 0
                && ptzPresets.Where(p => p.Name == name).FirstOrDefault() != null
                ;
        }

        private void comboBoxProfileTokens_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonGetPresets.Enabled =
                buttonGetStatus.Enabled =
                buttonMoveDown.Enabled =
                buttonMoveUp.Enabled =
                buttonMoveRight.Enabled =
                buttonMoveLeft.Enabled =
                buttonZoomIn.Enabled =
                buttonZoomOut.Enabled =
                buttonGetStreamURI.Enabled = mediaProfiles.Length > 0
                && comboBoxProfileTokens.SelectedItem != null
                ;
        }

        private void comboBoxStreamURIs_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonGoStream.Enabled = mediaURIs.Length > 0
                && comboBoxStreamURIs.SelectedItem != null
                ;
        }

        private void buttonGetStreamURI_Click(object sender, EventArgs e)
        {
            try
            {
                mediaURIs = mediaClient.GetStreamURIs(this.mediaProfiles);

                comboBoxStreamURIs.Items.Clear();
                comboBoxStreamURIs.Items.AddRange(mediaURIs.Select(uri => uri.Uri).ToArray());

                comboBoxStreamURIs.DropDownWidth =
                    mediaURIs.Select(uri => uri.Uri).Max(s => TextRenderer.MeasureText(s, comboBoxStreamURIs.Font).Width + 10);

                comboBoxStreamURIs.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Goto preset failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonGoStream_Click(object sender, EventArgs e)
        {
            var url = comboBoxStreamURIs.SelectedItem.ToString();
            if (url.LastIndexOf('?') >= 0)
            {
                url = url.Split('?')[0];
            }
            url = url.Replace("rtsp://", string.Format("rtsp://{0}:{1}@", textBoxUsername.Text, textBoxPassword.Text));

            vlcControl1.Play(url, null);
        }

        private void vlcControl1_EncounteredError(object sender, Vlc.DotNet.Core.VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            MessageBox.Show("An error occurred", "Playing video failed?", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void buttonGetStatus_Click(object sender, EventArgs e)
        {
            try
            {
                ptzStatus = ptzClient.GetStatus(comboBoxProfileTokens.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetStatus failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGoToStatus_Click(object sender, EventArgs e)
        {
            try
            {
                ptzClient.GotoPosition(comboBoxProfileTokens.SelectedItem.ToString(), ptzStatus.Position);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetStatus failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMoveLeft_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ptzClient.PanLeft(comboBoxProfileTokens.SelectedItem.ToString(), trackBarMoveSpeed.Value * 0.01);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PanLeft failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMoveRight_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ptzClient.PanRight(comboBoxProfileTokens.SelectedItem.ToString(), trackBarMoveSpeed.Value * 0.01);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PanRight failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMoveUp_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ptzClient.TiltUp(comboBoxProfileTokens.SelectedItem.ToString(), trackBarMoveSpeed.Value * 0.01);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TiltUp failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ptzClient.TiltDown(comboBoxProfileTokens.SelectedItem.ToString(), trackBarMoveSpeed.Value * 0.01);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TiltDown failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMove_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ptzClient.Stop(comboBoxProfileTokens.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Stop failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trackBarMoveSpeed_Scroll(object sender, EventArgs e)
        {
            var tb = sender as TrackBar;
            toolTip1.SetToolTip(tb, (tb.Value * 0.01).ToString());
        }

        private void buttonZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ptzClient.ZoomOut(comboBoxProfileTokens.SelectedItem.ToString(), trackBarMoveSpeed.Value * 0.01);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TiltDown failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ptzClient.ZoomIn(comboBoxProfileTokens.SelectedItem.ToString(), trackBarMoveSpeed.Value * 0.01);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TiltDown failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    sealed public class PtzClient
    {
        private PTZ.PTZClient Client { get; set; }

        public PtzClient(EndpointAddress epa, string username, string password)
        {
            var httpBinding = new HttpTransportBindingElement();
            httpBinding.AuthenticationScheme = AuthenticationSchemes.Digest;

            var messageElement = new TextMessageEncodingBindingElement();
            messageElement.MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None);

            var bind = new CustomBinding(messageElement, httpBinding);
            var behavior = new PasswordDigestBehavior(username, password);

            Client = new PTZ.PTZClient(bind, epa);
            Client.Endpoint.EndpointBehaviors.Add(behavior);
        }

        public void GotoPosition(string profileToken, PTZ.PTZVector position, double percentSpeed = 0.1)
        {
            var velocity = new PTZ.PTZSpeed();
            velocity.PanTilt = new PTZ.Vector2D();
            velocity.PanTilt.x = (float)(1.0 * percentSpeed);
            velocity.PanTilt.y = (float)(1.0 * percentSpeed);
            Client.AbsoluteMove(profileToken, position, new PTZ.PTZSpeed());
        }
        public void Stop(string profileToken)
        {
            Client.Stop(profileToken, true, true);
        }
        public void ZoomOut(string profileToken, double percentSpeed = 0.1)
        {
            var velocity = new PTZ.PTZSpeed();
            velocity.Zoom = new PTZ.Vector1D();
            velocity.Zoom.x = (float)(-1.0 * percentSpeed);

            Client.ContinuousMove(profileToken, velocity, null);
        }
        public void ZoomIn(string profileToken, double percentSpeed = 0.1)
        {
            var velocity = new PTZ.PTZSpeed();
            velocity.Zoom = new PTZ.Vector1D();
            velocity.Zoom.x = (float)(1.0 * percentSpeed);

            Client.ContinuousMove(profileToken, velocity, null);
        }
        public void PanLeft(string profileToken, double percentSpeed = 0.1)
        {
            var velocity = new PTZ.PTZSpeed();
            velocity.PanTilt = new PTZ.Vector2D();
            velocity.PanTilt.x = (float)(-1.0 * percentSpeed);

            Client.ContinuousMove(profileToken, velocity, null);
        }
        public void PanRight(string profileToken, double percentSpeed = 0.1)
        {
            var velocity = new PTZ.PTZSpeed();
            velocity.PanTilt = new PTZ.Vector2D();
            velocity.PanTilt.x = (float)(1.0 * percentSpeed);

            Client.ContinuousMove(profileToken, velocity, null);
        }
        public void TiltUp(string profileToken, double percentSpeed = 0.1)
        {
            var velocity = new PTZ.PTZSpeed();
            velocity.PanTilt = new PTZ.Vector2D();
            velocity.PanTilt.y = (float)(1.0 * percentSpeed);

            Client.ContinuousMove(profileToken, velocity, null);
        }
        public void TiltDown(string profileToken, double percentSpeed = 0.1)
        {
            var velocity = new PTZ.PTZSpeed();
            velocity.PanTilt = new PTZ.Vector2D();
            velocity.PanTilt.y = (float)(-1.0 * percentSpeed);

            Client.ContinuousMove(profileToken, velocity, null);
        }
        public void GotoPreset(string profileToken, string presetToken, double percentSpeed = 0.1)
        {
            Client.GotoPreset(profileToken, presetToken, new PTZ.PTZSpeed());
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

    sealed public class MediaClient
    {
        private Media.MediaClient Client { get; set; }

        public MediaClient(EndpointAddress epa, string username, string password)
        {
            var httpBinding = new HttpTransportBindingElement();
            httpBinding.AuthenticationScheme = AuthenticationSchemes.Digest;

            var messageElement = new TextMessageEncodingBindingElement();
            messageElement.MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None);

            var bind = new CustomBinding(messageElement, httpBinding);
            var behavior = new PasswordDigestBehavior(username, password);

            Client = new Media.MediaClient(bind, epa);
            Client.Endpoint.EndpointBehaviors.Add(behavior);
        }

        public Media.Profile[] GetProfiles()
        {
            return Client.GetProfiles();
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
            // Use the WSE 3.0 security token class
            UsernameToken token = new UsernameToken(this.Username, this.Password, PasswordOption.SendHashed);

            // Serialize the token to XML
            XmlElement securityToken = token.GetXml(new XmlDocument());

            //
            MessageHeader securityHeader = MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", securityToken, false);
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
            throw new NotImplementedException();
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}