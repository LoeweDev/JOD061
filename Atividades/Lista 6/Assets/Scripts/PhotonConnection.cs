using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnection : MonoBehaviourPunCallBacks
{
    public InputField inputField;
    public String gameVersion,roomName;
    public Button button;
    private byte maxPlayers;

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        gameVersion = "0.0.0.1";
        roomName = "First Game Room";
        maxPlayers = 10;
    }

    public void Connect()
    {   
        if (!PhotonNetwork.IsConnected)
        {
            input.interactable = false;
            button.interactable = false;
            PhotonNetwork.NickName = input.text;
            PhotonNetwork.GameVersion = this.gameVersion;
            PhotonNetwork.ConnectUsingSettings();
            return;
        }
        if (PhotonNetwork.CountOfRooms == 0)
        {
            button.interactable = false;
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = this.maxPlayers;
            PhotonNetwork.JoinOrCreateRoom(this.roomName, options, TypedLobby.Default);
            return;
        }

        PhotonNetwork.JoinRoom(this.roomName);
    }

    public override void OnConnectedToMaster()
    {
        button.interactable = true;
        button.GetComponentInChildren<Text>().text = "Jogar";
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }

    void Update()
    {
        
    }
}
