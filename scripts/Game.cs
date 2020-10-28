using Godot;
using Network;

public class Game : Node
{
    public static Network.Network network;
    public override void _Ready()
    {
        network = new Network.Network(GetTree());
        AddChild(network);
        
        if(OS.GetEnvironment("DEDICATED_SERVER") == "true" || OS.GetName() == "Server")
        {
            GD.Print("Attempting to start server...");
            network.StartServer();
        }
        else
        {
            GD.Print("Attempting to start client...");
            network.StartClient();
        }
    }
}