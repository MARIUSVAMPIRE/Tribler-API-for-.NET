using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Tribler.API.Test.WinFrom.DataGridViewProgress
{
    class DataGridViewProgressCell : DataGridViewImageCell
    {
        public const int PATINVERT = 0x005A0049;
        [DllImport("gdi32.dll")]
        public static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, int dwRop);
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateSolidBrush(int crColor);
        private static readonly Image EmptyImage;
        static DataGridViewProgressCell()
        {
            EmptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        public DataGridViewProgressCell()
        {
            this.ValueType = typeof(int);
        }
        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            return EmptyImage;
        }
        protected override void Paint(Graphics g, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                base.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                float percentage = (float)Convert.ToDouble(value.GetPropertyValue("Progress"));
                double progressVal = Convert.ToDouble(percentage) * 100.0;
                string statusLabel = Convert.ToString(value.GetPropertyValue("Label"));
                Brush foreColorBrush = new SolidBrush(cellStyle.ForeColor);
                using (var backColorBrush = new SolidBrush(Color.White)) g.FillRectangle(backColorBrush, cellBounds.X, cellBounds.Y, cellBounds.Width - 1, cellBounds.Height - 1);
                TextRenderer.DrawText(g, statusLabel.FirstCharToUpper() + " " + progressVal.ToString("0.000") + "%", cellStyle.Font, cellBounds, Main.BaseColor);
                var hdc = g.GetHdc();
                var barColor = Color.FromArgb(Main.BaseColor.ToArgb() ^ 0xffffff);
                var hbrush = CreateSolidBrush(((barColor.R | (barColor.G << 8)) | (barColor.B << 16)));
                var phbrush = SelectObject(hdc, hbrush);
                PatBlt(hdc, cellBounds.Left, cellBounds.Y, (Convert.ToInt32(progressVal) * cellBounds.Width / 100) - 1, cellBounds.Height - 1, PATINVERT);
                SelectObject(hdc, phbrush);
                DeleteObject(hbrush);
                g.ReleaseHdc(hdc);
            }
            catch { }
        }
    }
}
