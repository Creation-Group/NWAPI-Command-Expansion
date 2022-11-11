﻿
using CommandSystem;
using InventorySystem;
using InventorySystem.Items;
using InventorySystem.Items.Firearms;
using InventorySystem.Items.Firearms.Attachments;
using PluginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace CommandExpansion.Commands
{

	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class GivePredefinedInventory : ICommand, IUsageProvider
	{
		public string Command { get; } = "givepredefinedinventory";

		public string[] Aliases { get; } = new string[] { "gpi" };

		public string Description { get; } = "Give a predefined inventory to a player";

		public string[] Usage { get; } = new string[2] { "%player%", "%predefinedinventory%" };

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{


			if (!sender.CheckPermission(PlayerPermissions.GivingItems, out response))
			{
				return false;
			}

			if (arguments.Count >= 2)
			{
				string[] inventoryID;
				string itemslist = string.Empty;
				string arg = string.Empty;
				int num = 0;
				int num2 = 0;

				List<ReferenceHub> list = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out inventoryID);

				if (inventoryID == null || inventoryID.Length == 0)
				{
					response = "You must specify the inventory ID to give.";
					return false;
				}

				switch (inventoryID[0])
				{
					case "cards":
						itemslist = "1.2.3.4.5";
						break;
					case "scp":
						itemslist = "17.18.31.32.42.43.44.46";
						break;
					case "grenades":
						itemslist = "25.25.25.25.25.25.25.25";
						break;
				}

				ItemType[] array = ParseItems(itemslist).ToArray();
				if (array.Length == 0)
				{
					response = "You didn't input a valid inventoryID (example: gpi <playerID> testInventory).";
					return false;
				}

				Log.Info($"Giving the {inventoryID[0]} inventory to ({sender})");
				foreach (ReferenceHub item in list)
				{
					try
					{
						foreach (ItemType id in array)
						{
							AddItem(item, sender, id);
						}
					}
					catch (Exception ex)
					{
						num++;
						arg = ex.Message;
						continue;
					}

					num2++;
				}


				response = ((num == 0) ? string.Format("Done! The request affected {0} player{1}", num2, (num2 == 1) ? "!" : "s!") : $"Failed to execute the command! Failures: {num}\nLast error log:\n{arg}");
				return true;
			}

			response = "To execute this command provide at least 2 arguments!\nUsage: " + arguments.Array[0] + " " + this.DisplayCommandUsage();
			return false;
		}
		private IEnumerable<ItemType> ParseItems(string argument)
		{
			string[] array = argument.Split('.');
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (int.TryParse(array2[i], out var result) && Enum.IsDefined(typeof(ItemType), result))
				{
					yield return (ItemType)result;
				}
			}
		}

		private void AddItem(ReferenceHub ply, ICommandSender sender, ItemType id)
		{
			ItemBase itemBase = ply.inventory.ServerAddItem(id, 0);
			ServerLogs.AddLog(ServerLogs.Modules.Administrative, $"{sender.LogName} gave {id} to {ply.LoggedNameFromRefHub()}.", ServerLogs.ServerLogType.RemoteAdminActivity_GameChanging);
			if (itemBase == null)
			{
				throw new NullReferenceException($"Could not add {id}. Inventory is full or the item is not defined.");
			}

			Firearm firearm;
			if ((object)(firearm = itemBase as Firearm) != null)
			{
				if (AttachmentsServerHandler.PlayerPreferences.TryGetValue(ply, out var value) && value.TryGetValue(itemBase.ItemTypeId, out var value2))
				{
					firearm.ApplyAttachmentsCode(value2, reValidate: true);
				}

				FirearmStatusFlags firearmStatusFlags = FirearmStatusFlags.MagazineInserted;
				if (firearm.HasAdvantageFlag(AttachmentDescriptiveAdvantages.Flashlight))
				{
					firearmStatusFlags |= FirearmStatusFlags.FlashlightEnabled;
				}

				firearm.Status = new FirearmStatus(firearm.AmmoManagerModule.MaxAmmo, firearmStatusFlags, firearm.GetCurrentAttachmentsCode());
			}
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