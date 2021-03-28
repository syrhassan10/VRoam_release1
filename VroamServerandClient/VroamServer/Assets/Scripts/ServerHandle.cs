using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerHandle
{
    public static void WelcomeReceived(int _fromClient, Packet _packet)
    {
        int _clientIdCheck = _packet.ReadInt();
        string _username = _packet.ReadString();

        Debug.Log($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
        if (_fromClient != _clientIdCheck)
        {
            Debug.Log($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
        }
        Server.clients[_fromClient].SendIntoGame(_username);
    }

    



    public static void PlayerPosition(int _fromClient, Packet _packet)
    {
        Vector3 _position = _packet.ReadVector3();

        Server.clients[_fromClient].player.playerPosition = _position;
    }
    public static void PlayerRotation(int _fromClient, Packet _packet)
    {
        Quaternion _rotation = _packet.ReadQuaternion();

        Server.clients[_fromClient].player.playerRotation = _rotation;
    }




}
