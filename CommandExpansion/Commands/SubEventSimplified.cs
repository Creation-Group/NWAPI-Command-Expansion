namespace CommandExpansion.Commands
{
	using CommandSystem;
	using CommandSystem.Commands.RemoteAdmin.Decontamination;
	using CommandSystem.Commands.RemoteAdmin.ServerEvent;
	using InventorySystem;
	using PluginAPI.Core;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Utils;
	using YamlDotNet.Core;

	/// <summary>
	/// Execute a server event
	/// - CommandExpansion Command x
	/// </summary>
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

			ArraySegment<string> subcommand = new ArraySegment<string>(arguments.Skip(1).ToArray());

			eventCommand.Execute(subcommand, sender, out response);

			Log.Info($"An event was triggered : {response} (1 {arguments.Skip(1).ToArray()[0]} 2 {subcommand.ToArray()[0]} 3 {subcommand.ToArray()[1]})");
			
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