using System.Windows.Forms;

namespace VimeoPlayer
{
    public partial class FrmVideoPlayer : Form
    {
        // https://player.vimeo.com/video/
        // Para sacar el link del VimeoPlayerBaseUrl visité
        // https://player.vimeo.com/video/92368160 y vi el código fuente de la página.
        // Luego lo formateé y dentro había un JSON donde una rama decía "urls" y ahí
        // había la llave "moog" con el siguiente url
        private static string VimeoPlayerUrl(string id)
        {
            return $"https://f.vimeocdn.com/p/flash/moogaloop/6.4.5/moogaloop.swf?clip_id={id}&autoplay=1";
        }

        public FrmVideoPlayer(string videoId)
        {
            InitializeComponent();
            FlashVideo.Movie = VimeoPlayerUrl(videoId);
            // FlashVideo.Playing = true;
            // FlashVideo.Play();
        }
    }
}
