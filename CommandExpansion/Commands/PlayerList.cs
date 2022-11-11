namespace CommandExpansion.Commands
{
	using CommandSystem;
	using PluginAPI.Core;
	using PluginAPI.Core.Interfaces;
	using System;
	using System.Collections.Generic;

	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class PlayerList : ICommand
	{
		public string Command { get; } = "playerlist";

		public string[] Aliases { get; } = new string[] { "plyrlist" };

		public string Description { get; } = "Returns the list of players";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			string playerlist = "Nothing yet.";

			foreach (Player i in getList())
			{
				playerlist += $"[<color=green>{i}</color>]\n";
			}

			response = playerlist;
			return true;
		}
		public List<IPlayer> getList()
		{
			
			return Player.GetPlayers<IPlayer>();

		}
	}
}