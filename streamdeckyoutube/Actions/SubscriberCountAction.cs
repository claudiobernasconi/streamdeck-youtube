using Google.Apis.YouTube.v3.Data;
using StreamDeckLib;
using System.Threading.Tasks;

namespace streamdeckyoutube.Actions
{
    [ActionUuid(Uuid = "ch.claudiobernasconi.youtubestats")]
    public class SubscriberCountAction : YouTubeDataAPIAction 
    { 
        protected override async Task OnChannelStatisticsReceived(string context, ChannelListResponse channelData)
        {
            var subscriberCount = channelData.Items[0].Statistics.SubscriberCount;

            var numberFormatter = new NumberFormatter();
            var subscriberCountStr = numberFormatter.FormatNumber(subscriberCount);

            await Manager.SetTitleAsync(context, subscriberCountStr);
        }
    }
}
