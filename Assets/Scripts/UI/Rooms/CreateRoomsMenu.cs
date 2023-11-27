using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoomsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;

    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }
    
    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        RoomOptions option = new RoomOptions();
        option.MaxPlayers = 4;
        //PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, option, TypedLobby.Default);
        
    }

    public void OnClick_CreatenojoinRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        RoomOptions option = new RoomOptions();
        option.MaxPlayers = 4;
        //PhotonNetwork.JoinOrCreateRoom(_roomName.text, option, TypedLobby.Default);
        PhotonNetwork.CreateRoom(_roomName.text, option, TypedLobby.Default);

    }


    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room successfully", this);
        _roomsCanvases.CurrentRoomsCanvas.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creations failed: "+ message, this);
    }
}
