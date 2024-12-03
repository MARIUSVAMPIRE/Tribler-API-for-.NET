using System.Drawing;
using System.Net.Http.Headers;

namespace Tribler.API.Test.WinFrom
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Button_Test = new System.Windows.Forms.Button();
            this.DataGridView_List = new System.Windows.Forms.DataGridView();
            this.StatusStrip_Status = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel_RunningTIme = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel_TotalUploadSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel_TotalDownloadSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel_Total = new System.Windows.Forms.ToolStripStatusLabel();
            this.Button_Stop_Torrent = new System.Windows.Forms.Button();
            this.Button_Resume_Torrent = new System.Windows.Forms.Button();
            this.Button_Remove_Torrent = new System.Windows.Forms.Button();
            this.Button_Get_List = new System.Windows.Forms.Button();
            this.Button_Add_Torrent = new System.Windows.Forms.Button();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_List)).BeginInit();
            this.StatusStrip_Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_Test
            // 
            this.Button_Test.Location = new System.Drawing.Point(12, 12);
            this.Button_Test.Name = "Button_Test";
            this.Button_Test.Size = new System.Drawing.Size(75, 23);
            this.Button_Test.TabIndex = 0;
            this.Button_Test.Text = "Test";
            this.Button_Test.UseVisualStyleBackColor = true;
            this.Button_Test.Click += new System.EventHandler(this.Button_Test_Click);
            // 
            // DataGridView_List
            // 
            this.DataGridView_List.AllowUserToAddRows = false;
            this.DataGridView_List.AllowUserToOrderColumns = true;
            this.DataGridView_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_List.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridView_List.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_List.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_List.Location = new System.Drawing.Point(12, 41);
            this.DataGridView_List.Name = "DataGridView_List";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_List.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_List.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DataGridView_List.RowTemplate.Height = 23;
            this.DataGridView_List.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_List.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_List.Size = new System.Drawing.Size(1160, 695);
            this.DataGridView_List.TabIndex = 2;
            this.DataGridView_List.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_List_CellDoubleClick);
            this.DataGridView_List.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_List_CellFormatting);
            this.DataGridView_List.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridView_List_ColumnWidthChanged);
            this.DataGridView_List.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView_List_DataBindingComplete);
            this.DataGridView_List.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DataGridView_List_RowPostPaint);
            this.DataGridView_List.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridView_List_RowsAdded);
            this.DataGridView_List.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DataGridView_List_Scroll);
            this.DataGridView_List.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.DataGridView_List_SortCompare);
            this.DataGridView_List.Sorted += new System.EventHandler(this.DataGridView_List_Sorted);
            this.DataGridView_List.SizeChanged += new System.EventHandler(this.DataGridView_List_SizeChanged);
            this.DataGridView_List.DoubleClick += new System.EventHandler(this.DataGridView_List_DoubleClick);
            this.DataGridView_List.Resize += new System.EventHandler(this.DataGridView_List_Resize);
            // 
            // StatusStrip_Status
            // 
            this.StatusStrip_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel_RunningTIme,
            this.ToolStripStatusLabel_Status,
            this.ToolStripStatusLabel_TotalUploadSpeed,
            this.ToolStripStatusLabel_TotalDownloadSpeed,
            this.ToolStripStatusLabel_Total});
            this.StatusStrip_Status.Location = new System.Drawing.Point(0, 737);
            this.StatusStrip_Status.Name = "StatusStrip_Status";
            this.StatusStrip_Status.Size = new System.Drawing.Size(1184, 24);
            this.StatusStrip_Status.TabIndex = 4;
            this.StatusStrip_Status.Text = "Status";
            // 
            // ToolStripStatusLabel_RunningTIme
            // 
            this.ToolStripStatusLabel_RunningTIme.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.ToolStripStatusLabel_RunningTIme.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.ToolStripStatusLabel_RunningTIme.Name = "ToolStripStatusLabel_RunningTIme";
            this.ToolStripStatusLabel_RunningTIme.Size = new System.Drawing.Size(4, 19);
            // 
            // ToolStripStatusLabel_Status
            // 
            this.ToolStripStatusLabel_Status.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.ToolStripStatusLabel_Status.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.ToolStripStatusLabel_Status.Name = "ToolStripStatusLabel_Status";
            this.ToolStripStatusLabel_Status.Size = new System.Drawing.Size(899, 19);
            this.ToolStripStatusLabel_Status.Spring = true;
            this.ToolStripStatusLabel_Status.Text = "ToolStripStatusLabel_Status";
            this.ToolStripStatusLabel_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToolStripStatusLabel_TotalUploadSpeed
            // 
            this.ToolStripStatusLabel_TotalUploadSpeed.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.ToolStripStatusLabel_TotalUploadSpeed.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.ToolStripStatusLabel_TotalUploadSpeed.Name = "ToolStripStatusLabel_TotalUploadSpeed";
            this.ToolStripStatusLabel_TotalUploadSpeed.Size = new System.Drawing.Size(108, 19);
            this.ToolStripStatusLabel_TotalUploadSpeed.Text = "TotalUploadSpeed";
            // 
            // ToolStripStatusLabel_TotalDownloadSpeed
            // 
            this.ToolStripStatusLabel_TotalDownloadSpeed.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.ToolStripStatusLabel_TotalDownloadSpeed.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.ToolStripStatusLabel_TotalDownloadSpeed.Name = "ToolStripStatusLabel_TotalDownloadSpeed";
            this.ToolStripStatusLabel_TotalDownloadSpeed.Size = new System.Drawing.Size(125, 19);
            this.ToolStripStatusLabel_TotalDownloadSpeed.Text = "TotalDownloadSpeed";
            // 
            // ToolStripStatusLabel_Total
            // 
            this.ToolStripStatusLabel_Total.Name = "ToolStripStatusLabel_Total";
            this.ToolStripStatusLabel_Total.Size = new System.Drawing.Size(33, 19);
            this.ToolStripStatusLabel_Total.Text = "Total";
            this.ToolStripStatusLabel_Total.TextChanged += new System.EventHandler(this.ToolStripStatusLabel_Total_TextChanged);
            // 
            // Button_Stop_Torrent
            // 
            this.Button_Stop_Torrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Stop_Torrent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Stop_Torrent.BackgroundImage")));
            this.Button_Stop_Torrent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Button_Stop_Torrent.Location = new System.Drawing.Point(920, 12);
            this.Button_Stop_Torrent.Name = "Button_Stop_Torrent";
            this.Button_Stop_Torrent.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.Button_Stop_Torrent.Size = new System.Drawing.Size(123, 23);
            this.Button_Stop_Torrent.TabIndex = 7;
            this.Button_Stop_Torrent.Text = "Stop Torrent";
            this.Button_Stop_Torrent.UseVisualStyleBackColor = true;
            this.Button_Stop_Torrent.Click += new System.EventHandler(this.Button_Stop_Torrent_Click);
            // 
            // Button_Resume_Torrent
            // 
            this.Button_Resume_Torrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Resume_Torrent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Resume_Torrent.BackgroundImage")));
            this.Button_Resume_Torrent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Button_Resume_Torrent.Location = new System.Drawing.Point(791, 12);
            this.Button_Resume_Torrent.Name = "Button_Resume_Torrent";
            this.Button_Resume_Torrent.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.Button_Resume_Torrent.Size = new System.Drawing.Size(123, 23);
            this.Button_Resume_Torrent.TabIndex = 6;
            this.Button_Resume_Torrent.Text = "Resume Torrent";
            this.Button_Resume_Torrent.UseVisualStyleBackColor = true;
            this.Button_Resume_Torrent.Click += new System.EventHandler(this.Button_Resume_Torrent_Click);
            // 
            // Button_Remove_Torrent
            // 
            this.Button_Remove_Torrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Remove_Torrent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Remove_Torrent.BackgroundImage")));
            this.Button_Remove_Torrent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Button_Remove_Torrent.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Button_Remove_Torrent.Location = new System.Drawing.Point(1049, 12);
            this.Button_Remove_Torrent.Name = "Button_Remove_Torrent";
            this.Button_Remove_Torrent.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.Button_Remove_Torrent.Size = new System.Drawing.Size(123, 23);
            this.Button_Remove_Torrent.TabIndex = 5;
            this.Button_Remove_Torrent.Text = "Remove Torrent";
            this.Button_Remove_Torrent.UseVisualStyleBackColor = true;
            this.Button_Remove_Torrent.Click += new System.EventHandler(this.Button_Detete_Torrent_Click);
            // 
            // Button_Get_List
            // 
            this.Button_Get_List.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Get_List.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Get_List.BackgroundImage")));
            this.Button_Get_List.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Button_Get_List.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Get_List.Location = new System.Drawing.Point(533, 12);
            this.Button_Get_List.Name = "Button_Get_List";
            this.Button_Get_List.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.Button_Get_List.Size = new System.Drawing.Size(123, 23);
            this.Button_Get_List.TabIndex = 3;
            this.Button_Get_List.Text = "Get List";
            this.Button_Get_List.UseVisualStyleBackColor = true;
            this.Button_Get_List.Click += new System.EventHandler(this.Button_Get_List_Click);
            // 
            // Button_Add_Torrent
            // 
            this.Button_Add_Torrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Add_Torrent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Add_Torrent.BackgroundImage")));
            this.Button_Add_Torrent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Button_Add_Torrent.Location = new System.Drawing.Point(662, 12);
            this.Button_Add_Torrent.Name = "Button_Add_Torrent";
            this.Button_Add_Torrent.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.Button_Add_Torrent.Size = new System.Drawing.Size(123, 23);
            this.Button_Add_Torrent.TabIndex = 1;
            this.Button_Add_Torrent.Text = "Add Torrent";
            this.Button_Add_Torrent.UseVisualStyleBackColor = true;
            this.Button_Add_Torrent.Click += new System.EventHandler(this.Button_Add_Torrent_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "NotifyIcon";
            this.NotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.Button_Stop_Torrent);
            this.Controls.Add(this.Button_Resume_Torrent);
            this.Controls.Add(this.Button_Remove_Torrent);
            this.Controls.Add(this.StatusStrip_Status);
            this.Controls.Add(this.Button_Get_List);
            this.Controls.Add(this.DataGridView_List);
            this.Controls.Add(this.Button_Add_Torrent);
            this.Controls.Add(this.Button_Test);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Tribler UI";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.Deactivate += new System.EventHandler(this.Main_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Test_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.LocationChanged += new System.EventHandler(this.Main_LocationChanged);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Test_ControlAdded);
            this.Leave += new System.EventHandler(this.Main_Leave);
            this.Move += new System.EventHandler(this.Main_Move);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.StyleChanged += new System.EventHandler(this.Main_StyleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_List)).EndInit();
            this.StatusStrip_Status.ResumeLayout(false);
            this.StatusStrip_Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Test;
        private System.Windows.Forms.Button Button_Add_Torrent;
        private System.Windows.Forms.DataGridView DataGridView_List;
        private System.Windows.Forms.Button Button_Get_List;
        private System.Windows.Forms.StatusStrip StatusStrip_Status;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel_Total;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel_Status;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel_RunningTIme;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel_TotalUploadSpeed;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel_TotalDownloadSpeed;
        private System.Windows.Forms.Button Button_Remove_Torrent;
        private System.Windows.Forms.Button Button_Resume_Torrent;
        private System.Windows.Forms.Button Button_Stop_Torrent;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
    }
}

