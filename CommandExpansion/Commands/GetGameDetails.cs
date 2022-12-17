namespace CommandExpansion.Commands
{
	using CommandSystem;
	using PluginAPI.Core;
	using System;

	/// <summary>
	/// Returns details and stats of the current game
	/// - CommandExpansion Command
	/// </summary>
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class GameStats : ICommand
	{
		public string Command { get; } = "gamedetails";

		public string[] Aliases { get; } = new string[] { "gamestats", "gd" };

		public string Description { get; } = "Returns details and stats of the current game";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			response = "\n"
					 + $"There are {Player.Count-1} player{(Player.Count-1 < 2 ? "" : "s")} currently.\n"
					 + $"<color=green>Round started :</color> {Statistics.CurrentRound.StartTimestamp}\n"
					 + $"<color=green>Map seed :</color> [<color=red>{Map.Seed}</color>]\n\n"
					 + $"<color=green>TotalScpKills :</color> {Statistics.CurrentRound.TotalScpKills} Kill{(Statistics.CurrentRound.TotalScpKills < 2 ? "" : "s")}\n"
					 + $"<color=green>ZombiesChanged :</color> {Statistics.CurrentRound.ZombiesChanged} SCP-049-2\n"
					 + $"<color=green>ScpsAlive :</color> {Statistics.CurrentRound.ScpsAlive} SCP{(Statistics.CurrentRound.ScpsAlive < 2 ? "" : "s")}\n"
					 + $"<color=green>ChaosInsurgencyAlive :</color> {Statistics.CurrentRound.ChaosInsurgencyAlive} SCP{(Statistics.CurrentRound.ChaosInsurgencyAlive < 2 ? "" : "s")}\n"
					 + $"<color=green>ClassDAlive :</color> {Statistics.CurrentRound.ClassDAlive} SCP{(Statistics.CurrentRound.ClassDAlive < 2 ? "" : "s")}\n"
					 + $"<color=green>MtfAndGuardsAlive :</color> {Statistics.CurrentRound.MtfAndGuardsAlive} SCP{(Statistics.CurrentRound.MtfAndGuardsAlive < 2 ? "" : "s")}\n"
					 + $"<color=green>ZombiesAlive :</color> {Statistics.CurrentRound.ZombiesAlive} SCP{(Statistics.CurrentRound.ZombiesAlive < 2 ? "" : "s")}\n"
					 + $"<color=green>ClassDEscaped :</color> {Statistics.CurrentRound.ClassDEscaped} Class-D{(Statistics.CurrentRound.ClassDEscaped < 2 ? "" : "s")}\n"
					 + $"<color=green>ScientistsEscaped :</color> {Statistics.CurrentRound.ScientistsEscaped} Scientist{(Statistics.CurrentRound.ScientistsEscaped < 2 ? "" : "s")}\n"
					 + $"<color=green>TotalKilledPlayers :</color> {Statistics.CurrentRound.TotalKilledPlayers} Player{(Statistics.CurrentRound.TotalKilledPlayers < 2 ? "" : "s")}";
			return true;
		}
	}

}
