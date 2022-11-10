namespace CommandExpension.Commands
{
	using CommandSystem;
	using PluginAPI.Core;
	using System;

	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class GameStats : ICommand
	{
		public string Command { get; } = "gamestats";

		public string[] Aliases { get; } = new string[] { "gamedetails" };

		public string Description { get; } = "Returns details and stats on the current game";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			response = $"There are {Player.Count-1} players currently.\n"
					 + $"<color=green>Round started :</color> {Statistics.CurrentRound.StartTimestamp}\n"
					 + $"<color=green>Map seed :</color> [<color=red>{Map.Seed}</color>]\n\n"
					 + $"<color=green>TotalScpKills :</color> {Statistics.CurrentRound.TotalScpKills} Kills\n"
					 + $"<color=green>TotalScp0492Made :</color> {Statistics.CurrentRound.TotalScp0492Made} SCP-049-2\n"
					 + $"<color=green>ScpsAlive :</color> {Statistics.CurrentRound.ScpsAlive} SCPs\n"
					 + $"<color=green>TotalEscapedClassD :</color> {Statistics.CurrentRound.TotalEscapedClassD} Class-D\n"
					 + $"<color=green>TotalEscapedScientists :</color> {Statistics.CurrentRound.TotalEscapedScientists} Scientists\n"
					 + $"<color=green>TotalKilledPlayers :</color> {Statistics.CurrentRound.TotalKilledPlayers} Players";
			return true;
		}
	}

}
