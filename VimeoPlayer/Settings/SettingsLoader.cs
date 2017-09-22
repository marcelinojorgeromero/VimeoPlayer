using System;
using System.IO;
using Newtonsoft.Json;

namespace VimeoPlayer.Settings
{
    internal class SettingsLoader
    {
        private const string SETTINGS_FILE = "vimeoSettings.json";

        public static VimeoApiSettings LoadSettings()
        {
            var fromEnv = GetSettingsFromEnvVars();
            if (fromEnv.UserId != 0)
                return fromEnv;
            if (!File.Exists(SETTINGS_FILE))
            {
                // File was not found so create a new one with blanks 
                SaveSettings(new VimeoApiSettings());

                throw new Exception(string.Format("The file {0} was not found. A file was created, please fill in the information", SETTINGS_FILE));
            }
            var json = File.ReadAllText(SETTINGS_FILE);
            return JsonConvert.DeserializeObject<VimeoApiSettings>(json);
        }

        private static VimeoApiSettings GetSettingsFromEnvVars()
        {
            long.TryParse(Environment.GetEnvironmentVariable("VimeoUserId"), out long userId);
            long.TryParse(Environment.GetEnvironmentVariable("VimeoAlbumId"), out long albumId);
            long.TryParse(Environment.GetEnvironmentVariable("VimeoChannelId"), out long channelId);
            long.TryParse(Environment.GetEnvironmentVariable("VimeoVideoId"), out long videoId);
            long.TryParse(Environment.GetEnvironmentVariable("VimeoTextTrackId"), out long textTrackId);

            return new VimeoApiSettings
            {
                ClientId = Environment.GetEnvironmentVariable("VimeoClientId"),
                ClientSecret = Environment.GetEnvironmentVariable("VimeoClientSecret"),
                AccessToken = Environment.GetEnvironmentVariable("VimeoAccessToken"),
                UserId = userId,
                AlbumId = albumId,
                ChannelId = channelId,
                VideoId = videoId,
                TextTrackId = textTrackId
            };
        }

        public static void SaveSettings(VimeoApiSettings settings)
        {
            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(SETTINGS_FILE, json);
        }
    }
}
