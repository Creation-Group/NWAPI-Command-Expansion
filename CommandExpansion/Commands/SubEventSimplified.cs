namespace CommandExpansion.Commands
{
	using CommandSystem;
	using CommandSystem.Commands.RemoteAdmin.ServerEvent;
	using System;

	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class SubEventSimplifier : ICommand
	{
		public string Command { get; } = "subevent";

		public string[] Aliases { get; } = new string[] { "sb" };

		public string Description { get; } = "Execute a server event";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			string subeventlist = "\n";

			ServerEventCommand eventCommand = new ServerEventCommand();


			//eventCommand.LoadGeneratedCommands();

			//Log.Info($"{}");

			response = subeventlist;
			return true;
		}
	}
}

// ServerEventCommand eventCommand = new ServerEventCommand();
//for (int i = 0; i < Enum.GetNames(typeof(ServerEventType)).Length; i++)
//{
//	subeventlist += $"[<color=green>{i}</color>] - {(ServerEventType)i}\n";
//}

//Array command = new Array();

//var args = arguments.Skip(1).ToArray();
//ArraySegment<string> myArrSegAll = new ArraySegment<string>(args);

//eventCommand.Command = myArrSegAll.Array[0];

//eventCommand.Execute(myArrSegAll, sender, out string commandresponse);

//Log.Info($"{myArrSegAll.Array[0]} {myArrSegAll.Array[1]}");
//Log.Info($"{eventCommand.Command}");
//Log.Info($"{eventCommand.Usage}");
//Log.Info($"{commandresponse}");