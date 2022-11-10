namespace CommandExpension
{
	using AdminToys;
	using CustomPlayerEffects;
	using InventorySystem.Items;
	using InventorySystem.Items.Firearms;
	using InventorySystem.Items.Radio;
	using InventorySystem.Items.Usables;
	using LiteNetLib;
	using MapGeneration.Distributors;
	using PlayerRoles;
	using PlayerStatsSystem;
	using PluginAPI.Core;
	using PluginAPI.Core.Attributes;
	using PluginAPI.Enums;
	using PluginAPI.Events;
	using System;
	using ItemPickupBase = InventorySystem.Items.Pickups.ItemPickupBase;

	public class MainClass
    {
        [PluginEntryPoint("CommandExpension", "1.0.0", "This plugin provide custom commands for SCP-SL servers.", "Majorfox")]
        void LoadPlugin()
        {
            Log.Info("Loaded CommandExpension...");
            EventManager.RegisterEvents(this);
			EventManager.RegisterEvents<EventHandlers>(this);
        }

        [PluginConfig]
        public Config PluginConfig;
    }
}
