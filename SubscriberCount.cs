using Google;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using StreamDeckLib;
using StreamDeckLib.Messages;
using System;
using System.Threading.Tasks;

namespace streamdeckyoutube
{
    [ActionUuid(Uuid = "ch.claudiobernasconi.streamdeckyoutube.SubscriberCount.DefaultPluginAction")]
    public class SubscriberCount : BaseStreamDeckActionWithSettingsModel<Models.YouTubeModel>
    {
        public override async Task OnKeyUp(StreamDeckEventPayload args)
        {
            await ReadSubscriberCount(args);
            await Manager.SetSettingsAsync(args.context, SettingsModel);
        }

        public override async Task OnDidReceiveSettings(StreamDeckEventPayload args)
        {
            await base.OnDidReceiveSettings(args);
            await ReadSubscriberCount(args);
        }

        public override async Task OnWillAppear(StreamDeckEventPayload args)
        {
            await base.OnWillAppear(args);
            await ReadSubscriberCount(args);
        }

        private async Task ReadSubscriberCount(StreamDeckEventPayload args)
        {
            using (var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = SettingsModel.ApiKey
            }))
            {
                var channelRequest = youtubeService.Channels.List("statistics");
                channelRequest.Id = SettingsModel.ChannelId;

                try
                {
                    var channelData = await channelRequest.ExecuteAsync();
                    var subscriberCount = channelData.Items[0].Statistics.SubscriberCount;
                    await Manager.SetTitleAsync(args.context, subscriberCount.ToString());
                }
                catch (GoogleApiException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
