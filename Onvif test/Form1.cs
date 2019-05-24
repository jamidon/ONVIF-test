using System;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;

namespace Onvif_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PTZClient ptzClient { get; set; }
        PTZ.PTZPreset[] ptzPresets { get; set; }
        PTZ.PTZStatus ptzStatus { get; set; }

        MediaClient mediaClient { get; set; }
        Media.Profile[] mediaProfiles { get; set; }
        Media.MediaUri[] mediaURIs { get; set; }

        DeviceClient deviceClient { get; set; }
        Device.DeviceServiceCapabilities serviceCapabilities { get; set; }
        Device.Capabilities capabilities { get; set; }

        private void createDeviceClient()
        {
            deviceClient = new DeviceClient(new EndpointAddress(textBoxUrl.Text),
                textBoxUsername.Text, textBoxPassword.Text)
            {
                OpenTimeout = 1000
            };
        }

        private void createPtzClient()
        {
            ptzClient = new PTZClient(new EndpointAddress(textBoxUrl.Text),
                textBoxUsername.Text, textBoxPassword.Text)
            {
                OpenTimeout = 1000
            };
        }

        private void createMediaClient()
        {
            mediaClient = new MediaClient(new EndpointAddress(textBoxUrl.Text),
                textBoxUsername.Text, textBoxPassword.Text)
            {
                OpenTimeout = 1000
            };
        }

        private void buttonGetCapabilities_Click(object sender, EventArgs e)
        {
            if (deviceClient == null)
            {
                createDeviceClient();
            }

            try
            {
                capabilities = deviceClient.GetCapabilities();
                this.toolTip1.SetToolTip(buttonGetCapabilities, capabilities.PTZ.XAddr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetCapabilities failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                serviceCapabilities = deviceClient.GetServiceCapabilities();
                comboBoxAuxCommands.Items.Clear();
                if (serviceCapabilities.Misc != null && serviceCapabilities.Misc.AuxiliaryCommands != null)
                {
                    comboBoxAuxCommands.Items.AddRange(serviceCapabilities.Misc.AuxiliaryCommands);
                    comboBoxAuxCommands.Enabled = comboBoxAuxCommands.Items.Count > 0;
                }
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
            if (ptzClient == null)
            {
                createPtzClient();
            }
            try
            {
                this.mediaProfiles = mediaClient.GetProfiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetProfiles failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            var preset = ptzPresets.Where(p => p.Name == name).FirstOrDefault();
            if (preset != null)
            {
                textBoxPresetName.Text = name;
                textBoxPresetToken.Text = preset.token;
            }
            buttonPresetGo.Enabled = preset != null;
        }

        private void comboBoxProfileTokens_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonGetPresets.Enabled =
                buttonGetStatus.Enabled =
                buttonMoveDown.Enabled =
                buttonMoveDownRight.Enabled =
                buttonMoveDownLeft.Enabled =
                buttonMoveUp.Enabled =
                buttonMoveUpRight.Enabled =
                buttonMoveUpLeft.Enabled =
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
                buttonGoToStatus.Enabled = true;
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

        private void buttonMoveUpLeft_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ptzClient.MoveUpLeft(comboBoxProfileTokens.SelectedItem.ToString(), trackBarMoveSpeed.Value * 0.01);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TiltDown failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMoveUpRight_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ptzClient.MoveUpRight(comboBoxProfileTokens.SelectedItem.ToString(), trackBarMoveSpeed.Value * 0.01);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TiltDown failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMoveDownRight_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ptzClient.MoveDownRight(comboBoxProfileTokens.SelectedItem.ToString(), trackBarMoveSpeed.Value * 0.01);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TiltDown failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMoveDownLeft_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ptzClient.MoveDownLeft(comboBoxProfileTokens.SelectedItem.ToString(), trackBarMoveSpeed.Value * 0.01);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TiltDown failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSetPreset_Click(object sender, EventArgs e)
        {
            try
            {
                string presetToken = null;
                ptzClient.SetPreset(comboBoxProfileTokens.SelectedItem.ToString(), textBoxPresetName.Text, ref presetToken);
                textBoxPresetToken.Text = presetToken;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetPreset failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeletePreset_Click(object sender, EventArgs e)
        {
            try
            {
                ptzClient.DeletePreset(comboBoxProfileTokens.SelectedItem.ToString(), textBoxPresetToken.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DeletePreset failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPresetName_TextChanged(object sender, EventArgs e)
        {
            buttonSetPreset.Enabled = (sender as TextBox).Text.Length > 0;
        }

        private void textBoxPresetToken_TextChanged(object sender, EventArgs e)
        {
            buttonDeletePreset.Enabled = (sender as TextBox).Text.Length > 0;
        }

        private void comboBoxAuxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonGoAuxCommand.Enabled = (sender as ComboBox).SelectedIndex != -1;
        }

        private void buttonGoAuxCommand_Click(object sender, EventArgs e)
        {
            var response = deviceClient.SendAuxCommand(comboBoxAuxCommands.SelectedItem.ToString());
            if (string.IsNullOrWhiteSpace(response))
            {
                MessageBox.Show(response, "Send Aux Command", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void endpoint_TextChanged(object sender, EventArgs e)
        {
            ptzClient = null;
            mediaClient = null;
            deviceClient = null;
        }
    }
}
