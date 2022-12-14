
# Command Expansion Plugin

This plugin provide Remote Admin custom commands for SCP-SL servers.

*[This solution is using the official server-side plugin system for SCP: Secret Laboratory game. NW-API](https://github.com/northwood-studios/NwPluginAPI)*

-----

## How to build the plugin without existing project:

1) Download the repository

2) Then integrate the **[NwPluginAPI](https://github.com/northwood-studios/NwPluginAPI)** folder

3) Run the NWAPI-Command-Expansion.sln

4) Open any file in the CommandExpansion namespace

5) Generate CommandExpansion

-----

## List of commands

### gamedetails [GetGameDetails.cs]

*Aliases :* gamestats, gd

*Description :* Returns details and stats of the current game.

Current details :
- Player Count
- Start round Timestamp
- Map Seed
- Number of SCP kills
- Number of SCP-049-2 made
- Number of SCP Alive
- Number of Chaos Insurgency Alive
- Number of Class D Alive
- Number of Mtf And Guards Alive
- Number of Zombies Alive
- Number of Escaped Class D
- Number of Escaped Scientists
- Number of Killed Players

-----
### serverdetails [GetServerDetails.cs]

*Aliases :* sd

*Description :* Returns details and stats of the server.

Current details :
- Server IP and port
- Server Max Players
- Number of Players

-----
### itemlist [ItemList.cs]

*Aliases :* itemdetails

*Description :* Returns the list of available items and their ID.

-----
### playerlist [PlayerList.cs]

*Aliases :* plyrlist

*Description :* Returns the list of players.
  
-----
### subeventlist [SubEventList.cs]

*Aliases :* subevents

*Description :* Returns the list of all server Sub\_Events.
  
-----
...
