using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tribler.API.Test.WinFrom;

public partial class Main
{
    private int marginWidth = 0;
    private int updateFlagIndex = 0;
    readonly SpinningCircles spinningCircles = new();
    private List<Downloads.Container.Information> dataList = [];
    System.Windows.Forms.Timer getListTimer = new() { Interval = 5000 };

    private void InitializeDataGridView_List()
    {
        typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, DataGridView_List, [true]);

        DataGridView_List.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Name", HeaderText = "Name", DataPropertyName = "Name" });
        DataGridView_List.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Size", HeaderText = "Size", DataPropertyName = "Size" });
        DataGridView_List.Columns.Add(new DataGridViewProgress.DataGridViewProgressColumn() { Name = "Progress", HeaderText = "Progress", DataPropertyName = "Progress", Width = 200, MinimumWidth = 100, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, SortMode = DataGridViewColumnSortMode.Automatic });
        DataGridView_List.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Ratio", HeaderText = "Ratio", DataPropertyName = "Ratio" });
        DataGridView_List.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Availability", HeaderText = "Availability", DataPropertyName = "Availability" });
        DataGridView_List.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Seeds", HeaderText = "Seeds", DataPropertyName = "Seeds" });
        DataGridView_List.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Peers", HeaderText = "Peers", DataPropertyName = "Peers" });
        DataGridView_List.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Speed down", HeaderText = "Speed down", DataPropertyName = "Speed down" });
        DataGridView_List.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Speed up", HeaderText = "Speed up", DataPropertyName = "Speed up" });
        DataGridView_List.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Addon", HeaderText = "Addon", DataPropertyName = "Addon" });
        DataGridView_List.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Destination", HeaderText = "Destination", DataPropertyName = "Destination" });
        DataGridView_List.Columns.Add(new DataGridViewProgressMap.DataGridViewProgressMapColumn() { Name = "Progress Map", HeaderText = "Progress Map", DataPropertyName = "Progress Map", Width = 250, MinimumWidth = 100, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
        DataGridView_List.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Hops", HeaderText = "Hops", DataPropertyName = "Hops" });
        DataGridView_List.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Infohash", HeaderText = "Infohash", DataPropertyName = "Infohash" });

        DataGridView_List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        marginWidth = Math.Max(0, this.Width - DataGridView_List.Columns.GetColumnsWidth(DataGridViewElementStates.None));

        spinningCircles.Name = "Loading";
        spinningCircles.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        spinningCircles.Location = new Point((DataGridView_List.Width - spinningCircles.Width) / 2, (DataGridView_List.Height - spinningCircles.Height) / 2);
        DataGridView_List.Controls.Add(spinningCircles);
        spinningCircles.Hide();
    }

    private async void LoadDataGridView_List()
    {
        DataGridView_List.Loading();

        Cursor.Current = Cursors.WaitCursor;
        await Task.Run(async () =>
        {
            if (await downloads.Get("", true, true, true))
            {
                dataList = downloads.LIST;

                long totalSize = 0, totalUpload = 0, totalDownload = 0;
                Hashtable statusCount = [];

                List<DataGridViewRow> rows = [];
                foreach (Downloads.Container.Information information in downloads.LIST)
                {
                    DataGridViewRow row = new();
                    row.CreateCells(DataGridView_List);
                    row.SetValues([information.Name, information.Size, new { information.Progress, information.Status.Label }, information.AllTime, information.Availability, String.Format("{0} ({1})", information.Seeds.Connected, information.Seeds.Count), String.Format("{0} ({1})", information.Peers.Connected, information.Peers.Count), information.Speed.Download, information.Speed.Upload, information.Time.Added, information.Destination, information.Pieces, information.Hops, information.InfoHash]);

                    row.ContextMenuStrip = new ContextMenuStrip
                    {
                        Tag = row
                    };
                    row.ContextMenuStrip.Opened += delegate (object sender, EventArgs e)
                    {
                        //DataGridView_List.ClearSelection();
                        //((DataGridViewRow)((ContextMenuStrip)sender).Tag).Selected = true;
                    };
                    row.ContextMenuStrip.Items.AddRange([
                        new ToolStripMenuItem("Resume", Properties.Resources.Resume, async delegate (object sender, EventArgs e) {
                            DataGridViewCellCollection currentCells = ((DataGridViewRow)((ToolStripMenuItem)sender).GetCurrentParent().Tag).Cells;
                            await downloads.Resume(currentCells["infohash"].Value.ToString());
                        }),
                        new ToolStripMenuItem("Stop", Properties.Resources.Stop, async delegate (object sender, EventArgs e) {
                            DataGridViewCellCollection currentCells = ((DataGridViewRow)((ToolStripMenuItem)sender).GetCurrentParent().Tag).Cells;
                            await downloads.Resume(currentCells["Infohash"].Value.ToString(), false);
                        }),
                        new ToolStripMenuItem("Remove", Properties.Resources.Remove, async delegate (object sender, EventArgs e) {
                            DataGridViewRow row = (DataGridViewRow)((ToolStripMenuItem)sender).GetCurrentParent().Tag;
                            if(MessageBox.Show(String.Format("Remove selected torrent?\r\n{0}", row.Cells["Name"].Value.ToString()), "Remove torrents", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                                DataGridViewCellCollection currentCells = row.Cells;
                                await downloads.Remove(currentCells["Infohash"].Value.ToString());
                            }
                        }),
                        new ToolStripMenuItem("Go To", null, delegate (object sender, EventArgs e) {
                            DataGridViewRow row = (DataGridViewRow)((ToolStripMenuItem)sender).GetCurrentParent().Tag;
                            string destination =Convert.ToString(row.Cells["Destination"].Value);
                            string name =Convert.ToString(row.Cells["Name"].Value);
                            System.Diagnostics.Process.Start(Path.Combine(destination, name));
                        })
                    ]);
                    rows.Add(row);

                    totalSize += information.Size;
                    totalDownload += information.Speed.Download;
                    totalUpload += information.Speed.Upload;
                    if (statusCount.ContainsKey(information.Status.Label)) statusCount[information.Status.Label] = (int)statusCount[information.Status.Label] + 1;
                    else statusCount[information.Status.Label] = 1;
                }
                DataGridView_List.BeginInvoke((MethodInvoker)delegate ()
                {
                    DataGridView_List.Loading(false);
                    Application.DoEvents();
                    DataGridView_List.Rows.Clear();
                    DataGridView_List.Rows.AddRange([.. rows]);
                    DataGridView_List.Sort(DataGridView_List.Columns["Addon"], ListSortDirection.Ascending);
                    DataGridView_List.ClearSelection();
                    DataGridView_List_DataBindingComplete(DataGridView_List, new DataGridViewBindingCompleteEventArgs(ListChangedType.ItemAdded));
                    UpdateDataGridView_List();
                });
                List<string> statusList = [];
                foreach (string key in statusCount.Keys) { statusList.Add(String.Format("{0} {1}", key, statusCount[key])); }

                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    ToolStripStatusLabel_Status.Text = String.Join(" | ", statusList);
                    ToolStripStatusLabel_Total.Text = String.Format("Total: {0}({1})", downloads.LIST.Count, totalSize.SizeString());
                    ToolStripStatusLabel_TotalDownloadSpeed.Text = String.Format("Download: {0}/s", totalDownload.SizeString());
                    ToolStripStatusLabel_TotalUploadSpeed.Text = String.Format("Upload: {0}/s", totalUpload.SizeString());
                    SetNotifyIconText(new { TotalSize = totalSize, TotalCount = downloads.LIST.Count, DownloadSpeed = totalDownload, UploadSpeed = totalUpload });
                });
            }
            else
            {
                DataGridView_List.BeginInvoke((MethodInvoker)delegate ()
                {
                    DataGridView_List.Rows.Clear();
                });
            }
        });
    }

    private void UpdateDataGridView_List()
    {
        getListTimer.Tick += async delegate (object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                if (await downloads.Get("", true, true, true))
                {
                    List<DataGridViewRow> notExistRowList = [];
                    for (int index = 0; index < DataGridView_List.Rows.Count; index++)
                    {
                        DataGridViewRow currentRow = DataGridView_List.Rows[index];
                        if (!downloads.LIST.Exists(information => String.Equals(currentRow.Cells["Infohash"].Value, information.InfoHash))) notExistRowList.Add(currentRow);
                    }
                    DataGridView_List.BeginInvoke((MethodInvoker)delegate ()
                    {
                        DataGridView_List.DeleteRow(notExistRowList);
                    });

                    long totalSize = 0, totalUpload = 0, totalDownload = 0;
                    Hashtable statusCount = [];
                    foreach (Downloads.Container.Information information in downloads.LIST)
                    {
                        totalSize += information.Size;
                        totalDownload += information.Speed.Download;
                        totalUpload += information.Speed.Upload;
                        if (statusCount.ContainsKey(information.Status.Label)) statusCount[information.Status.Label] = (int)statusCount[information.Status.Label] + 1;
                        else statusCount[information.Status.Label] = 1;
                    }
                    List<string> statusList = [];
                    foreach (string key in statusCount.Keys) { statusList.Add(String.Format("{0} {1}", key, statusCount[key])); }

                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        ToolStripStatusLabel_Status.Text = String.Join(" | ", statusList);
                        ToolStripStatusLabel_Total.Text = String.Format("Total: {0}({1})", downloads.LIST.Count, totalSize.SizeString());
                        ToolStripStatusLabel_TotalDownloadSpeed.Text = String.Format("Download: {0}/s", totalDownload.SizeString());
                        ToolStripStatusLabel_TotalUploadSpeed.Text = String.Format("Upload: {0}/s", totalUpload.SizeString());
                        SetNotifyIconText(new { TotalSize = totalSize, TotalCount = downloads.LIST.Count, DownloadSpeed = totalDownload, UploadSpeed = totalUpload });
                    });

                    dataList = downloads.LIST;
                }
            });
        };
        getListTimer.Start();

        System.Windows.Forms.Timer refreshTimer = new() { Interval = 99, Tag = false };
        refreshTimer.Tick += delegate (object sender, EventArgs e)
        {
            if (downloads.LIST != null && !(bool)refreshTimer.Tag)
            {
                refreshTimer.Tag = true;
                if (downloads.LIST.Count() <= updateFlagIndex) updateFlagIndex = 0;
                foreach (var item in downloads.LIST.Select((information, index) => new { Index = index, Value = information }).Where(item => item.Index >= updateFlagIndex && item.Index < updateFlagIndex + 1))
                {
                    DataGridView_List.BeginInvoke((MethodInvoker)delegate ()
                    {
                        DataGridView_List.AddOrUpdateRow(item.Value);
                    });
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
                updateFlagIndex += 1;
                refreshTimer.Tag = false;
            }
        };
        refreshTimer.Start();
    }

    private void DataGridView_List_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
        if (e.Column.Name == "Progress")
        {
            var progress1 = e.CellValue1;
            var progress2 = e.CellValue2;
            e.SortResult = Convert.ToDouble(progress1.GetPropertyValue("Progress")).CompareTo(Convert.ToDouble(progress2.GetPropertyValue("Progress")));
            e.Handled = true;
        }
        else if (e.Column.Name == "Ratio")
        {
            var ratio1 = Convert.ToDouble(e.CellValue1.GetPropertyValue("Ratio"));
            var ratio2 = Convert.ToDouble(e.CellValue2.GetPropertyValue("Ratio"));
            e.SortResult = (ratio1 == -1.0 ? double.MaxValue : ratio1).CompareTo(ratio2 == -1.0 ? double.MaxValue : ratio2);
            e.Handled = true;
        }
    }

    private void DataGridView_List_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value != null)
        {
            if (((DataGridView)sender).Columns[e.ColumnIndex].Name == "Size")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                e.Value = ((long)e.Value).SizeString();
            }
            else if ((new List<string>(["Seeds", "Peers"])).Contains(((DataGridView)sender).Columns[e.ColumnIndex].Name))
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            else if ((new List<string>(["Speed down", "Speed up"])).Contains(((DataGridView)sender).Columns[e.ColumnIndex].Name))
            {
                e.Value = String.Format("{0}/s", ((long)e.Value).SizeString());
            }
            else if (e.Value != null && ((DataGridView)sender).Columns[e.ColumnIndex].Name == "Ratio")
            {
                float ratio = (float)e.Value.GetPropertyValue("Ratio");
                e.Value = string.Format("{0} ({1} upload; {2} download)", ratio < 0 ? "∞" : ratio.ToString("0.00"), ((long)e.Value.GetPropertyValue("Upload")).SizeString(), ((long)e.Value.GetPropertyValue("Download")).SizeString());
            }
        }
    }

    private void DataGridView_List_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        SetWidth();
        Cursor.Current = Cursors.Default;
    }

    private void DataGridView_List_SizeChanged(object sender, EventArgs e)
    {

    }

    private void DataGridView_List_Sorted(object sender, EventArgs e)
    {
        DataGridView_List.SetRowNumber();
    }

    private void DataGridView_List_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
    {
    }

    private void DataGridView_List_Resize(object sender, EventArgs e)
    {
        spinningCircles.Location = new Point((DataGridView_List.Width - spinningCircles.Width) / 2, (DataGridView_List.Height - spinningCircles.Height) / 2);
    }

    private void DataGridView_List_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {

    }

    private void DataGridView_List_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        DataGridViewRow row = ((DataGridView)sender).Rows[e.RowIndex];
        Color rowBackgroundColor = row.DefaultCellStyle.BackColor;
        var Progress = row.Cells["Progress"].Value;
        if (Convert.ToDouble(Progress.GetPropertyValue("Progress")) == 1.0) rowBackgroundColor = Color.LightBlue;
        else if (OverMinimumRunningTime && DateTime.Now - Convert.ToDateTime(row.Cells["Addon"].Value) > new TimeSpan(31, 30, 29, 28, 27))
        {
            if (Convert.ToDouble(row.Cells["Availability"].Value) < 1.0) { rowBackgroundColor = Color.Red; }
            else { rowBackgroundColor = DateTime.Now - Convert.ToDateTime(row.Cells["Addon"].Value) > new TimeSpan(99, 98, 97, 96, 95) ? Color.Red : Color.LightGray; }
        }
        row.DefaultCellStyle.BackColor = rowBackgroundColor;
    }

    private void DataGridView_List_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewRow row = DataGridView_List.Rows[e.RowIndex];
        string destination = Convert.ToString(row.Cells["Destination"].Value);
        string name = Convert.ToString(row.Cells["Name"].Value);
        System.Diagnostics.Process.Start(Path.Combine(destination, name));
    }

    private void DataGridView_List_Scroll(object sender, ScrollEventArgs e)
    {
    }

    private void DataGridView_List_DoubleClick(object sender, EventArgs e)
    {
        
    }
}

public static class DataGridViewExtension
{
    public static DataGridViewRow AddOrUpdateRow(this DataGridView thisDataGridView, Downloads.Container.Information information)
    {
        var rowInformation = new Object[] { information.Name, information.Size, new { information.Progress, information.Status.Label }, information.AllTime, information.Availability, String.Format("{0} ({1})", information.Seeds.Connected, information.Seeds.Count), String.Format("{0} ({1})", information.Peers.Connected, information.Peers.Count), information.Speed.Download, information.Speed.Upload, information.Time.Added, information.Destination, information.Pieces, information.Hops, information.InfoHash };
        if (thisDataGridView.Rows.Cast<DataGridViewRow>().Any(row => { return row.Cells["Infohash"].Value.ToString() == information.InfoHash; }))
        {
            int rowIndex = thisDataGridView.Rows.Cast<DataGridViewRow>().ToList().FindIndex(row => { return row.Cells["Infohash"].Value.ToString() == information.InfoHash; });
            return thisDataGridView.Rows[rowIndex].SetValues(rowInformation) ? thisDataGridView.Rows[rowIndex] : null;
        }
        else
        {
            int addedIndex = thisDataGridView.Rows.Add(rowInformation);
            thisDataGridView.SetRowNumber();
            return thisDataGridView.Rows[addedIndex];
        }
    }

    public static void Loading(this DataGridView thisDataGridView, bool isLoading = true)
    {
        Control loadingControl = thisDataGridView.Controls.Find("Loading", false)[0];
        if (isLoading)
        {
            thisDataGridView.Controls.SetChildIndex(loadingControl, thisDataGridView.Controls.Count - 1);
            loadingControl.Show();
        }
        else
        {
            thisDataGridView.Controls.SetChildIndex(loadingControl, thisDataGridView.Controls.GetChildIndex(loadingControl) - 1);
            loadingControl.Hide();
        }
    }

    public static void DeleteRow(this DataGridView thisDataGridView, List<DataGridViewRow> rowList)
    {
        if (rowList.Count > 0)
        {
            rowList.ForEach(row => thisDataGridView.Rows.Remove(row));
            thisDataGridView.SetRowNumber();
        }
    }

    public static void SetRowNumber(this DataGridView thisDataGridView)
    {
        foreach (DataGridViewRow row in thisDataGridView.Rows)
        {
            row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
        }
    }
}