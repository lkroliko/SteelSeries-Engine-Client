# Game Sense Client

SteelSeries GameSense client in C#

#### Create client
```c#
GSClient client = new GSClient("PROGRAM_NAME");
```
#### Register program in SteelSeries Engine 3
```c#
client.SendCommand(builder => builder.Program.Register("Developer Name", "Display Name"));
```
#### Register event
```c#
client.SendCommand(builder => builder.Event.Register("EVENT_NAME"));
```
#### Fire event
```c#
client.SendCommand(builder => builder.Event.Fire("EVENT_NAME", value));
```
