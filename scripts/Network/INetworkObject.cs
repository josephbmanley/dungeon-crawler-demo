using Godot;

namespace Network
{
    public interface INetworkObject
    {
        int port { get; }
        NetworkedMultiplayerENet peer { get; set; }
        void Close();
    }
}