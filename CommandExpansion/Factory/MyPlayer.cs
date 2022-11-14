namespace CommandExpansion.Factory
{
	using PluginAPI.Core;
	using PluginAPI.Core.Interfaces;

	public class MyPlayer : Player
	{
		public MyPlayer(IGameComponent component) : base(component)
		{
		}
	}
}
