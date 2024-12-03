using System.Windows.Forms;

namespace Tribler.API.Test.WinFrom.DataGridViewProgressMap
{
    public class DataGridViewProgressMapColumn : DataGridViewImageColumn
    {
        public DataGridViewProgressMapColumn()
        {
            CellTemplate = new DataGridViewProgressMapCell();
        }
    }
}
