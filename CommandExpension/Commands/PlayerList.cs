namespace CommandExpension.Commands
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

			//List<IPlayer> allPlayers =
			Player.GetPlayers<IPlayer>();
			/*
			foreach (Player i in allPlayers)
			{
				playerlist += $"[<color=green>{allPlayers}</color>]\n";
			}
			*/
			response = playerlist;
			return true;
		}
	}
}