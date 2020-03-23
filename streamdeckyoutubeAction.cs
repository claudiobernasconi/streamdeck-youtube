using StreamDeckLib;
using StreamDeckLib.Messages;
using System.Threading.Tasks;

namespace streamdeckyoutube
{
  [ActionUuid(Uuid= "ch.claudiobernasconi.streamdeckyoutube.SubscriberCount.DefaultPluginAction")]
  public class streamdeckyoutubeAction : BaseStreamDeckActionWithSettingsModel<Models.YouTubeModel>
  {
	public override async Task OnKeyUp(StreamDeckEventPayload args)
	{
	  SettingsModel.SubscriberCount = SettingsModel.SubscriberCount * 2;

	  await Manager.SetTitleAsync(args.context, SettingsModel.SubscriberCount.ToString());
	  await Manager.SetSettingsAsync(args.context, SettingsModel);
	}

	public override async Task OnDidReceiveSettings(StreamDeckEventPayload args)
	{
	  await base.OnDidReceiveSettings(args);
	  await Manager.SetTitleAsync(args.context, SettingsModel.SubscriberCount.ToString());
	}

	public override async Task OnWillAppear(StreamDeckEventPayload args)
	{
	  await base.OnWillAppear(args);
	  await Manager.SetTitleAsync(args.context, SettingsModel.SubscriberCount.ToString());
	}
  }
}
