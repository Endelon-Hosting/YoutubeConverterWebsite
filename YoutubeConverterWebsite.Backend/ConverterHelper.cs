using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YoutubeExplode;

namespace YoutubeConverterWebsite.Backend
{ 
    public class ConverterHelper
    {
        public static async Task<ConverterHelper> GetUrl(string youtubeUrl)
        {
            try
            {
                ConverterHelper x = new();
                // youtu.be links
                // https://youtu.be/UtF6Jej8yb4?t=2

                // youtube.com links
                // https://www.youtube.com/watch?v=UtF6Jej8yb4

                Uri uri = new(youtubeUrl);
                string id;
                var isYtBe = youtubeUrl.Contains("youtu.be");
                if (isYtBe)
                {
                    id = uri.Segments[1];
                }
                else
                {
                    id = HttpUtility.ParseQueryString(uri.Query)["v"];
                }
                var youtube = new YoutubeClient();

                var video = await youtube.Videos.GetAsync(youtubeUrl);

                x.title = video.Title;
                x.author = video.Author.Title;
                x.duration = (TimeSpan)video.Duration;
                x.thumbnailUrl = video.Thumbnails[video.Thumbnails.Count - 1].Url;

                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(id);

                streamManifest.GetMuxedStreams().ToList().ForEach(stream =>
                {
                    VideoResult video = new()
                    {
                        quality = stream.VideoQuality.Label,
                        size = stream.Size.MegaBytes.ToString(),
                        url = stream.Url,
                        type = stream.VideoCodec
                    };
                    x.videos.Add(video);
                });

                streamManifest.GetAudioStreams().ToList().ForEach(stream =>
                {
                    if (stream.AudioCodec == "opus")
                    {
                        AudioResult audio = new()
                        {
                            quality = stream.Bitrate.BitsPerSecond.ToString(),
                            size = stream.Size.MegaBytes.ToString(),
                            url = stream.Url,
                            type = stream.AudioCodec
                        };
                        x.audios.Add(audio);
                    }
                });

                return x;
            }
            catch (Exception)
			{
                return null;
			}
        }

        public string thumbnailUrl { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public TimeSpan duration { get; set; }
        public List<VideoResult> videos { get; set; } = new();
        public List<AudioResult> audios { get; set; } = new();
    }
}