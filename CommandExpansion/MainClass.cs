namespace CommandExpansion
{
	using PluginAPI.Core;
	using PluginAPI.Core.Attributes;
	using PluginAPI.Events;

	public class MainClass
	{
		[PluginEntryPoint("CommandExpansion", "1.0.0", "This plugin provide Remote Admin custom commands for SCP-SL servers.", "Majorfox")]
		void LoadPlugin()
		{
			Log.Info("Loaded CommandExpansion...");
			EventManager.RegisterEvents(this);
			EventManager.RegisterEvents<EventHandlers>(this);
		}

		[PluginConfig]
		public Config PluginConfig;
	}
}
