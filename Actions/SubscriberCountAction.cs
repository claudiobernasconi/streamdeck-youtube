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
            string subscriberCountStr;

            if( subscriberCount < 1000 )
            {
                subscriberCountStr = subscriberCount.ToString();
            }
            else if( subscriberCount == 1000)
            {
                subscriberCountStr = "1000";
            }
            else if (subscriberCount < 10_000 )
            {
                subscriberCountStr = subscriberCount.Value.ToString().Substring(0, 1) + "." + subscriberCount.Value.ToString().Substring(1, 2) + "K";
            }
            else if(subscriberCount < 100_000)
            {
                subscriberCountStr = subscriberCount.Value.ToString().Substring(0, 2) + "." + subscriberCount.Value.ToString().Substring(2, 1) + "K";
            }
            else if(subscriberCount < 1_000_000)
            {
                subscriberCountStr = subscriberCount.Value.ToString().Substring(0, 3) + "K";
            }
            else if(subscriberCount < 10_000_000)
            {
                subscriberCountStr = subscriberCount.Value.ToString().Substring(0, 1) + "." + subscriberCount.Value.ToString().Substring(1, 2) + "M";
            }
            else if(subscriberCount < 100_000_000)
            {
                subscriberCountStr = subscriberCount.Value.ToString().Substring(0, 2) + "." + subscriberCount.Value.ToString().Substring(2, 1) + "M";
            }
            else
            {
                subscriberCountStr = subscriberCount.Value.ToString().Substring(0, 3) + "M";
            }

            await Manager.SetTitleAsync(context, subscriberCountStr);
        }
    }
}
