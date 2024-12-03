using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tribler.API.Test.WinFrom.DataGridViewProgressMap
{
    class DataGridViewProgressMapCell : DataGridViewImageCell
    {
        private static readonly Image EmptyImage;
        static DataGridViewProgressMapCell()
        {
            EmptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        public DataGridViewProgressMapCell()
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
                Downloads.Container.Information.PiecesBase PieceInformation = (Downloads.Container.Information.PiecesBase)value;
                byte[] pieceString = Convert.FromBase64String(/*new Regex(@"\=+$").Replace(*/PieceInformation.Detail/*, "")*/);

                List<bool> pieces = [];
                for (int i = 0; i < Math.Min(PieceInformation.Total, pieceString.Length); ++i)
                {
                    char pieceNumber = Convert.ToChar(pieceString[i]);
                    for (int j = 8 - 1; j >= 0; --j)
                    {
                        pieces.Add(Convert.ToBoolean(pieceNumber & 1 << j));
                    }
                }
                base.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));
                using Bitmap ProgressBitMap = new(Math.Min(pieces.Count, PieceInformation.Total), cellBounds.Height - 1);
                using Graphics ProgressGraphics = Graphics.FromImage(ProgressBitMap);
                foreach (var pieceInformation in pieces.Select((value, index) => new { Index = index, Value = value }))
                {
                    ProgressGraphics.DrawRectangle(new Pen(new SolidBrush(pieceInformation.Value ? Main.BaseColor : Color.White)), new Rectangle(pieceInformation.Index, 0, 1, cellBounds.Height - 1));
                }

                g.DrawImage(ProgressBitMap, new Rectangle(cellBounds.X, cellBounds.Y, cellBounds.Width - 1, cellBounds.Height - 1), new Rectangle(0, 0, ProgressBitMap.Size.Width, ProgressBitMap.Size.Height), GraphicsUnit.Pixel);
            }
            catch { }
        }
    }
}
