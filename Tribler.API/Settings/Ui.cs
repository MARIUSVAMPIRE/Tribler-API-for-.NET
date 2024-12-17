namespace Tribler.API
{
    public partial class Settings
    {
        public partial class UiClass
        {
            internal bool DevelopmentMode { get; init; }
            internal bool AskDownloadSettings { get; init; }
            internal string Language { get; init; }
        }
    }
}
