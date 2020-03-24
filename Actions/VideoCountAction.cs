using Google.Apis.YouTube.v3.Data;
using StreamDeckLib;
using System.Threading.Tasks;

namespace streamdeckyoutube.Actions
{
    [ActionUuid(Uuid = "ch.claudiobernasconi.streamdeckyoutube.VideoCountAction")]
    public class VideoCountAction : YouTubeDataAPIAction 
    { 
        protected override async Task OnChannelStatisticsReceived(string context, ChannelListResponse channelData)
        {
            var subscriberCount = channelData.Items[0].Statistics.VideoCount;
            await Manager.SetTitleAsync(context, subscriberCount.ToString());
        }
    }
}
