using System.Windows.Forms;

namespace Tribler.API.Test.WinFrom.DataGridViewProgress
{
    public class DataGridViewProgressColumn : DataGridViewImageColumn
    {
        public DataGridViewProgressColumn()
        {
            CellTemplate = new DataGridViewProgressCell();
        }
    }
}
