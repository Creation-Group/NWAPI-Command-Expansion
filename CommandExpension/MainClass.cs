namespace CommandExpension
{
	using PluginAPI.Core;
	using PluginAPI.Core.Attributes;
	using PluginAPI.Events;

	public class MainClass
	{
		[PluginEntryPoint("CommandExpension", "1.0.0", "This plugin provide custom commands for SCP-SL servers.", "Majorfox")]
		void LoadPlugin()
		{
			Log.Info("Loaded CommandExpension...");
			EventManager.RegisterEvents(this);
			EventManager.RegisterEvents<EventHandlers>(this);
		}

		[PluginConfig]
		public Config PluginConfig;
	}
}
