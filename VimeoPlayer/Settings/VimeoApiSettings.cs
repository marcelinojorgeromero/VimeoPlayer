
namespace VimeoPlayer.Settings
{
    internal class VimeoApiSettings
    {
        // API Client Settings
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AccessToken { get; set; }
        
        // Test Content Settings
        public long UserId { get; set; }
        public long AlbumId { get; set; }
        public long ChannelId { get; set; }
        public long VideoId { get; set; }
        public long TextTrackId { get; set; }
    }
}
