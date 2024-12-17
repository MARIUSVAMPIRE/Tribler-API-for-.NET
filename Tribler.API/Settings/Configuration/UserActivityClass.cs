namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Configuration
        {
            public class UserActivityClass
            {
                public bool Enabled { get; init; }
                public int Max_query_history { get; init; }
                public float Health_check_interval { get; init; }
            }
        }
    }
}