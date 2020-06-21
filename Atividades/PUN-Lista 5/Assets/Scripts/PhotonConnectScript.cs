using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnectScript : MonoBehaviourPunCallbacks
{

    string gameVersion = "0.0.1";
    string roomName = "JOD061";
    string nickName;

    // Start is called before the first frame update
    void Start()
    {
        nickName = "Player";
        Debug.Log ("Conectando no servidor...",this);
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.NickName = nickName + Random.Range(0, 9999);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() 
    {
        RoomOptions options = new RoomOptions();

        Debug.Log("Conectado!", this);
        if (PhotonNetwork.CountOfRooms == 0) 
        {
            options.MaxPlayers = 4;
            PhotonNetwork.JoinOrCreateRoom(roomName, options, TypedLobby.Default);
        } else {
            PhotonNetwork.JoinRoom(roomName);
        }
    }

    public override void OnCreatedRoom() 
    {
        Debug.Log("Criada a sala " + roomName);
    }

    void OnPlayerEnteredRoom()
    {
         Debug.Log("Jogador " + PhotonNetwork.LocalPlayer.NickName + " entrou na sala " + roomName + "(" + PhotonNetwork.CurrentRoom.PlayerCount + ")");
    }

    void OnPlayerLeftRoom()
    {
         Debug.Log("Jogador " + PhotonNetwork.LocalPlayer.NickName + " saiu da sala " + roomName + "(" + PhotonNetwork.CurrentRoom.PlayerCount + ")");
    }

    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause) 
    {
        Debug.Log("Desconectado!");
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
