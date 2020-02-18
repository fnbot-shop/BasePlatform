using System;
using System.Text;
using System.Threading.Tasks;
using fnbot.shop.Backend;
using fnbot.shop.Backend.Configuration;
using fnbot.shop.Backend.ItemTypes;

namespace BasePlatform
{
    public sealed class BasePlatform : IPlatform
    {
        // Can be null if no config is required
        public IConfig Config => null;

        // Respect the force argument and return a non-null item if true
        public async Task<PostResponse> PostItem(IItem item)
        {
            var builder = new StringBuilder("New data: ");
            switch (item)
            {
                case ItemText text:
                    builder.AppendLine(text.Text);
                    break;
                case ItemImage image:
                    builder.AppendLine($"{image.Type} Image ({image.Width}x{image.Height}): {image.Stream.Length} bytes");
                    builder.AppendLine(image.Caption);
                    break;
                case ItemAlbum album:
                    builder.AppendLine($"{album.Streams.Length} {album.Type} Image(s) ({album.Width}x{album.Height})");
                    builder.AppendLine(album.Caption);
                    break;
                case ItemGif gif:
                    builder.AppendLine($"{gif.Type} Image ({gif.Width}x{gif.Height}): {gif.Stream.Length} bytes, {gif.Frames} frames");
                    builder.AppendLine(gif.Caption);
                    break;
                case ItemVideo video:
                    builder.AppendLine($"{video.Type} Video ({video.Width}x{video.Height}): {video.Stream.Length} bytes, {video.FPS} FPS, {video.Duration} seconds");
                    builder.AppendLine(video.Caption);
                    break;
                default:
                    return PostResponse.UNSUPPORTED_TYPE;
            }
            Console.WriteLine(builder.ToString());
            return PostResponse.SUCCESS;
        }

        public void Dispose()
        {

        }
    }
}
