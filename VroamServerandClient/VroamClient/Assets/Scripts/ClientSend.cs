using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    /// <summary>Sends a packet to the server via TCP.</summary>
    /// <param name="_packet">The packet to send to the sever.</param>
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    /// <summary>Sends a packet to the server via UDP.</summary>
    /// <param name="_packet">The packet to send to the sever.</param>
    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets
    /// <summary>Lets the server know that the welcome message was received.</summary>
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(UIManager.instance.usernameField.text);

            SendTCPData(_packet);
        }
    }

    /// <summary>Sends player input to the server.</summary>
    /// <param name="_inputs"></param>



    public static void playerPosition(Vector3 _playerPos)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerPosition))
        {
            _packet.Write(_playerPos);


            SendTCPData(_packet);
        }
    }
    public static void playerRotation(Quaternion _playerRot)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerRotation))
        {
            _packet.Write(_playerRot);


            SendTCPData(_packet);
        }
    }   
    



}

    #endregion

