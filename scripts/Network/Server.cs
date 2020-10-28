using Godot;
using Network.Data;
using System;

namespace Network
{
    public class Network : Node, INetworkObject
    {
        public static Network main;
        public static SceneTree tree;
        public int port { get; }
        public int max_players { get; set; }
        public NetworkedMultiplayerENet peer { get; set; }
        //public PlayerData[] playerData;

        public Network(SceneTree _tree, int _port = 7777)
        {
            port = _port;
            tree = _tree;
        }

        public void StartServer(int _max_players = 32)
        {
            max_players = _max_players;

            peer = new NetworkedMultiplayerENet();
            peer.CreateServer(port, max_players);
            tree.NetworkPeer = peer;
            if(tree.NetworkPeer != null)
            {
                GD.Print("Successfully started server!");
            } else {
                throw new Exception("Failed to start server!");
            }
            main = this;

            //Intialize signal connects
            tree.Connect("network_peer_connected", this, "NetworkPeerConnected");
            tree.Connect("network_peer_disconnected", this, "NetworkPeerDisconnected");
        }

        public void StartClient(string host = "127.0.0.1")
        {
            peer = new NetworkedMultiplayerENet();
            peer.CreateClient(host, port);
            tree.NetworkPeer = peer;

            main = this;

            //Intialize signal connects
            tree.Connect("connected_to_server", this, "ConnectedToServer");
            tree.Connect("connection_failed", this, "ConnectionFailed");
            tree.Connect("server_disconnected", this, "ServerDisconnected");
        }

        public void NetworkPeerConnected(int id)
        {
            GD.Print("Player connected to the server!");
        }
        public void NetworkPeerDisconnected(int id)
        {
            GD.Print("Player left the server!");
        }
        public void ConnectedToServer()
        {
            GD.Print("Connected to server!");
            Rpc("RegisterPlayer", "Fred");
        }

        public void ConnectionFailed()
        {
            GD.Print("Failed to connect to server!");
        }

        public void ServerDisconnected()
        {
            GD.Print("Server disconnected!");
        }

        [Remote]
        public void RegisterPlayer(string name)
        {
            GD.Print($"Loaded {name}");
        }

        public void Close()
        {
            tree.NetworkPeer = null;
        }
    }
}