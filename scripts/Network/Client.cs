using Godot;

namespace Network
{
    public class Client : Node, INetworkObject
    {
        public static Client main;
        public static SceneTree tree;
        public int port { get; }
        public NetworkedMultiplayerENet peer { get; set; }

        public Client(SceneTree _tree, string host, int _port = 7777)
        {
            Name = "Network";
            if (tree == null)
                tree = _tree;
            port = _port;

            peer = new NetworkedMultiplayerENet();
            peer.CreateClient(host, port);
            tree.NetworkPeer = peer;

            main = this;

            //Intialize signal connects
            tree.Connect("connected_to_server", this, "ConnectedToServer");
            tree.Connect("connection_failed", this, "ConnectionFailed");
            tree.Connect("server_disconnected", this, "ServerDisconnected");
        }
        public void RegisterPlayer(string name)
        {
            Rpc("RegisterPlayer", "Fred");
        }

        public void ConnectedToServer()
        {
            GD.Print("Connected to server!");
            RegisterPlayer("Bro");
        }

        public void ConnectionFailed()
        {
            GD.Print("Failed to connect to server!");
        }

        public void ServerDisconnected()
        {
            GD.Print("Server disconnected!");
        }

        public void Close()
        {
            tree.NetworkPeer = null;
        }
    }
}