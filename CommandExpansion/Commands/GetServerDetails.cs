namespace CommandExpansion.Commands
{
	using CommandSystem;
	using PluginAPI.Core;
	using System;

	/// <summary>
	/// Returns details and stats of the server
	/// - CommandExpansion Command
	/// </summary>
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class GetServerDetails : ICommand
	{
		public string Command { get; } = "serverdetails";

		public string[] Aliases { get; } = new string[] { "sd" };

		public string Description { get; } = "Returns details and stats of the server";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			response = "\n"
					 + $"<color=green>Server IP :</color> {Server.ServerIpAddress.ToString()}:{Server.Port.ToString()}\n"
					 + $"<color=green>Server Max Players :</color> {Server.MaxPlayers} players\n"
					 + $"<color=green>Number of Players :</color> {Player.Count-1} player{(Player.Count-1 < 2 ? "" : "s")}";
			return true;
		}
	}

}
