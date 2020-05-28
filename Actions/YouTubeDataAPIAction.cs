using Google;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Logging;
using StreamDeckLib;
using StreamDeckLib.Messages;
using System;
using System.Threading.Tasks;

namespace streamdeckyoutube.Actions
{
    public abstract class YouTubeDataAPIAction : BaseStreamDeckActionWithSettingsModel<Models.YouTubeModel>
    {
        protected abstract Task OnChannelStatisticsReceived(string context, ChannelListResponse channelData);

        private async Task ReceiveChannelStatistics(StreamDeckEventPayload args)
        {
            if (string.IsNullOrEmpty(SettingsModel.ApiKey))
            {
                await Manager.SetTitleAsync(args.context, "E1");
                Logger.LogError("No YouTube API key provided.");
                return;
            }

            try
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
                        await OnChannelStatisticsReceived(args.context, channelData);
                    }
                    catch (GoogleApiException e)
                    {
                        await Manager.SetTitleAsync(args.context, "?");
                        await Manager.SetTitleAsync(args.context, "E2");
                        Logger.LogError(e.Message, "Error fetching data from the YouTube API.");
                    }
                }
            }
            catch (Exception e)
            {
                await Manager.ShowAlertAsync(e.Message);
                await Manager.SetTitleAsync(args.context, "E3");
                Logger.LogError(e.Message, "Unknown error.");
            }
        }

        public override async Task OnKeyUp(StreamDeckEventPayload args)
        {
            await ReceiveChannelStatistics(args);
            await Manager.SetSettingsAsync(args.context, SettingsModel);
        }

        public override async Task OnDidReceiveSettings(StreamDeckEventPayload args)
        {
            await base.OnDidReceiveSettings(args);
            await ReceiveChannelStatistics(args);
        }

        public override async Task OnWillAppear(StreamDeckEventPayload args)
        {
            await base.OnWillAppear(args);
            await ReceiveChannelStatistics(args);
        }
    }
}
