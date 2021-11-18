using Google.Apis.YouTube.v3.Data;
using StreamDeckLib;
using System.Threading.Tasks;

namespace streamdeckyoutube.Actions
{
    [ActionUuid(Uuid = "ch.claudiobernasconi.youtubestats.viewcount")]
    public class ViewCountAction : YouTubeDataAPIAction 
    { 
        protected override async Task OnChannelStatisticsReceived(string context, ChannelListResponse channelData)
        {
            var viewCount = channelData.Items[0].Statistics.ViewCount;

            var numberFormatter = new NumberFormatter();
            var viewCountStr = numberFormatter.FormatNumber(viewCount);

            await Manager.SetTitleAsync(context, viewCountStr);
        }
    }
}
