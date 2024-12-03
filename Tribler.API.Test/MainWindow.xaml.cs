using Microsoft.UI.Xaml;
using System.Runtime.Versioning;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Test
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        [SupportedOSPlatform("windows")]
        public MainWindow()
        {
            this.InitializeComponent();

            if (System.OperatingSystem.IsWindows())
            {
#pragma warning disable CA1416 // 플랫폼 호환성 유효성 검사
                AppWindow.Resize(new Windows.Graphics.SizeInt32(1024, 800));
#pragma warning restore CA1416 // 플랫폼 호환성 유효성 검사
            }
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            //Tribler.API.Downloads downloads = new API.Downloads();
            //Tribler.API.Test.Downloads();
        }
    }
}
