namespace CommandExpansion.Commands
{
	using CommandSystem;
	using CommandSystem.Commands.RemoteAdmin.ServerEvent;
	using PluginAPI.Enums;
	using System;

	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class SubEventList : ICommand
	{
		public string Command { get; } = "subeventlist";

		public string[] Aliases { get; } = new string[] { "subevents" };

		public string Description { get; } = "Returns the list of all server Sub_Events";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			string subeventlist = "\n";

			ServerEventCommand eventCommand = new ServerEventCommand();

			for (int i = 0; i < Enum.GetNames(typeof(ServerEventType)).Length; i++)
			{
				subeventlist += $"[<color=green>{i}</color>] - {(ServerEventType)i}\n";
			}

			response = subeventlist;
			return true;
		}
	}
}