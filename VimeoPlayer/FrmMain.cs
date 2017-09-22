using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using VimeoDotNet;
using VimeoDotNet.Authorization;
using VimeoPlayer.Settings;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using VimeoDotNet.Models;
using Size = System.Drawing.Size;

namespace VimeoPlayer
{
    public partial class FrmMain : Form
    {
        private readonly VimeoApiSettings _vimeoSettings;
        private VimeoClient _vimeoClient;
        private Paginated<Video> _videos;
        public FrmMain()
        {
            InitializeComponent();
            ToolStripStatusLbMain.Text = string.Empty;
            _vimeoSettings = SettingsLoader.LoadSettings();
        }

        private VimeoClient CreateAuthenticatedClient()
        {
            return new VimeoClient(_vimeoSettings.AccessToken);
        }

        private async Task<VimeoClient> CreateUnauthenticatedClient()
        {
            var authorizationClient = new AuthorizationClient(_vimeoSettings.ClientId, _vimeoSettings.ClientSecret);
            var unauthenticatedToken = await authorizationClient.GetUnauthenticatedTokenAsync();
            return new VimeoClient(unauthenticatedToken.access_token);
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LstView.Clear();
            
            try
            {
                _videos = await _vimeoClient.SearchVideos(TxtSearchTerm.Text, filter: VimeoDotNet.Enums.FilterType.Categories);

                var smallImgLst = new ImageList
                {
                    ImageSize = new Size(64, 64),
                    ColorDepth = ColorDepth.Depth32Bit
                };
                var largeImgLst = new ImageList
                {
                    ImageSize = new Size(128, 128),
                    ColorDepth = ColorDepth.Depth32Bit
                };
                
                foreach (var video in _videos.data)
                {
                    var thumbnailSmall = await ImageFromUrl(video.pictures.sizes[0].link);
                    var thumbnailBig = await ImageFromUrl(video.pictures.sizes[1].link);
                    smallImgLst.Images.Add(video.pictures.resource_key, thumbnailSmall);
                    largeImgLst.Images.Add(video.pictures.resource_key, thumbnailBig);
                }
                LstView.SmallImageList = smallImgLst;
                LstView.LargeImageList = largeImgLst;
                foreach (var video in _videos.data)
                {
                    LstView.Items.Add(new ListViewItem
                    {
                        ImageKey = video.pictures.resource_key,
                        Text = video.name,
                        ToolTipText = $"{video.name}"
                    }); //{video.pictures.sizes[1].link}
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"{ex.Message} Inner Exception: {ex.InnerException}", @"Error");
                Cursor.Current = Cursors.Default;
            }
        }

        //public Bitmap ImageFromUrl(string imageUrl, string filename, ImageFormat imgFormatType)
        //{
        //    using (var webClient = new WebClient())
        //    using (var stream = webClient.OpenRead(imageUrl))
        //    {
        //        var bitmap = new Bitmap(stream);
        //        var imgFileFormat = imgFormatType.ToString().ToLower();
        //        var sanitizedFilename = @"C:\Dev\VimeoPlayer\test\" + SanitizeFilename(filename) + "." + imgFileFormat;
        //        bitmap?.Save(sanitizedFilename, imgFormatType);
        //        return bitmap;
        //    }
        //}

        public async Task<Bitmap> ImageFromUrl(string imageUrl)
        {
            using (var webClient = new WebClient())
            using (var stream = await webClient.OpenReadTaskAsync(new Uri(imageUrl)))
            {
                var bitmap = new Bitmap(stream);
                return bitmap;
            }
        }

        private string SanitizeFilename(string filename)
        {
            return Path.GetInvalidFileNameChars().Aggregate(filename, (current, c) => current.Replace(c.ToString(), string.Empty));
        }
        
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _vimeoClient = CreateAuthenticatedClient();
        }

        private static string ExtractVideoId(string videoUri)
        {
            var regex = new Regex(@"\d+$");
            var match = regex.Match(videoUri);
            return match.Success ? match.Value : string.Empty;
        }

        private void LstView_ItemActivate(object sender, EventArgs e)
        {
            
            if (LstView.SelectedItems.Count == 0)
            {
                return;
            }
            //var itemsLink = new StringBuilder();
            //foreach (var selectedItem in LstView.SelectedItems)
            //{
            //    var item = (ListViewItem) selectedItem;
            //    itemsLink.AppendLine(item.ToolTipText);
            //}
            //MessageBox.Show(itemsLink.ToString(), @"Url");
            var selectedVideo = FindVideo(LstView.SelectedItems[0].ImageKey);
            if (selectedVideo == null)
            {
                MessageBox.Show(@"Couldn't find video!", @"Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var videoId = ExtractVideoId(selectedVideo.uri);
            var formVideoPlayer = new FrmVideoPlayer(videoId);
            formVideoPlayer.ShowDialog(this);
        }

        private Video FindVideo(string resourceKey)
        {
            return _videos.data.SingleOrDefault(item => item.pictures.resource_key == resourceKey);
        }

        private void LstView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (LstView.SelectedItems.Count == 0)
            {
                return;
            }
            var selectedVideo = FindVideo(LstView.SelectedItems[0].ImageKey);
            if (selectedVideo == null)
            {
                MessageBox.Show(@"Couldn't find video!", @"Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ToolStripStatusLbMain.Text = selectedVideo.uri;
        }
    }
}
