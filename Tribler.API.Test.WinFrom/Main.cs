using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Automation;
using System.Windows.Forms;

namespace Tribler.API.Test.WinFrom
{
    public partial class Main : Form
    {
        Downloads downloads;
        private bool OverMinimumRunningTime = false;
        internal static Color BaseColor = Color.FromArgb(248, 111, 0);

        public Main()
        {
            InitializeComponent();
        }

        private void Button_Test_Click(object sender, EventArgs e)
        {

        }

        private async void Button_Add_Torrent_Click(object sender, EventArgs e)
        {
            OpenFileDialog openTorrent = new() { Filter = "torrent file(*.torrent)|*.torrent", Multiselect = true };
            if (openTorrent.ShowDialog() == DialogResult.OK)
            {
                Downloads downloads = new(new Settings());
                foreach (string fileName in openTorrent.FileNames)
                {
                    await downloads.Add(File.ReadAllBytes(fileName));
                }
            }
        }

        private async void Button_Detete_Torrent_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete selected torrents?") == DialogResult.OK)
            {
                Downloads downloads = new(new Settings());
                foreach (DataGridViewRow row in DataGridView_List.SelectedRows)
                {
                    await downloads.Remove(Convert.ToString(row.Cells["InfoHash"].Value));
                }
            }
        }

        private async void Button_Resume_Torrent_Click(object sender, EventArgs e)
        {
            Downloads downloads = new(new Settings());
            foreach (DataGridViewRow row in DataGridView_List.SelectedRows)
            {
                await downloads.Resume(Convert.ToString(row.Cells["InfoHash"].Value), true);
            }
        }

        private async void Button_Stop_Torrent_Click(object sender, EventArgs e)
        {
            Downloads downloads = new(new Settings());
            foreach (DataGridViewRow row in DataGridView_List.SelectedRows)
            {
                await downloads.Resume(Convert.ToString(row.Cells["InfoHash"].Value), false);
            }
        }

        private void Button_Get_List_Click(object sender, EventArgs e)
        {
            LoadDataGridView_List();
        }

        private void SetWidth()
        {
            this.Width = DataGridView_List.Columns.GetColumnsWidth(DataGridViewElementStates.None) + DataGridView_List.FirstDisplayedScrollingColumnHiddenWidth + marginWidth;
            DataGridView_List.HorizontalScrollingOffset = 1000;
            this.Width += DataGridView_List.FirstDisplayedScrollingColumnHiddenWidth;
        }

        private void Test_ControlAdded(object sender, ControlEventArgs e)
        {
        }

        private void Test_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MainLocation.X == 0 && Properties.Settings.Default.MainLocation.Y == 0)
            {
            }
            else
            {
                this.Location = Properties.Settings.Default.MainLocation;
            }

            InitializeDataGridView_List();

            Settings settings = new();
            if (settings.Loaded)
            {
                downloads = new(settings);
                Timer TriblerProcessTimer = new()
                {
                    Interval = 1000
                };
                TriblerProcessTimer.Tick += delegate (object sender, EventArgs e)
                {
                    var triblerProcess = Process.GetProcessesByName("Tribler").FirstOrDefault();
                    if (triblerProcess == null) { ToolStripStatusLabel_RunningTIme.Text = "Not Executing"; }
                    else
                    {
                        TimeSpan runningTime = DateTime.Now - triblerProcess.StartTime;
                        OverMinimumRunningTime = runningTime > new TimeSpan(1, 23, 45, 67);
                        ToolStripStatusLabel_RunningTIme.Text = String.Format("Running Time: {0}", runningTime.ToString(@"dd\.hh\:mm\:ss"));
                        if (downloads.LIST == null) Button_Get_List_Click(Button_Get_List, new EventArgs());
                    }
                };
                TriblerProcessTimer.Start();
            }
            else
            {
                MessageBox.Show("Cannot loaded Tribler Settings!");
                this.Close();
            }
        }

        private void SetNotifyIconText(Object information)
        {
            if (this.Visible || NotifyIcon.Visible || NotifyIcon.Text.Contains("NotifyIcon"))
            {
                NotifyIcon.Text = String.Format("DN: {0}/s\r\nUP: {1}/s\r\n{2}({3})", ((long)information.GetPropertyValue("DownloadSpeed")).SizeString(), ((long)information.GetPropertyValue("UploadSpeed")).SizeString(), information.GetPropertyValue("TotalCount"), ((long)information.GetPropertyValue("TotalSize")).SizeString());
            }
        }

        private void Main_Move(object sender, EventArgs e)
        {
        }

        private void Main_LocationChanged(object sender, EventArgs e)
        {
        }

        private void Main_StyleChanged(object sender, EventArgs e)
        {

        }

        private void ToolStripStatusLabel_Total_TextChanged(object sender, EventArgs e)
        {
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.NotifyIcon.Visible = true;
                getListTimer.Interval = 60 * 1000;
            }
            else
            {
                this.ShowInTaskbar = true;
                this.NotifyIcon.Visible = false;
                getListTimer.Interval = 5000;
                this.TopMost = true;
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void Main_Shown(object sender, EventArgs e)
        {
        }

        private void Main_Activated(object sender, EventArgs e)
        {
        }

        private void Main_Deactivate(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void Main_Leave(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MainLocation = this.WindowState == FormWindowState.Normal ? this.Location : this.RestoreBounds.Location;

            Properties.Settings.Default.Save();
        }
    }
}
