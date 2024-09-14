using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Connection : MonoBehaviourPunCallbacks
{
    private const int MAX_PLAYERS = 4;

    public override void OnConnectedToMaster()
    {
       Debug.Log("We are connected");
       // The master server handles all the room information
       PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Room currentRoom = PhotonNetwork.CurrentRoom;
        Debug.Log($"Joined a room: {currentRoom.Name}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"Failed to join a room: {message}");
        Debug.Log($"Create a room instead..");
        // If no rooms are available (all rooms are full or there are no rooms at all)..
        // Create own room
        PhotonNetwork.CreateRoom(
            roomName: null,
            roomOptions: new RoomOptions{
                MaxPlayers = MAX_PLAYERS
            });
    }

    public void Connect()
    {
        if(PhotonNetwork.IsConnected){
            Debug.Log("Already connected");
            return;
        }

        // Connect to photon network
        PhotonNetwork.ConnectUsingSettings();
    }
}
