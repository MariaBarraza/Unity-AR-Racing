using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{

    public static Launcher instance;

    [SerializeField]
    GameObject loading;
    [SerializeField]
    GameObject menuView;
    [SerializeField]
    GameObject createRoomView;
    [SerializeField]
    GameObject roomView;
    [SerializeField]
    RoomView roomViewObj;
    [SerializeField]
    GameObject setNickNameView;
    [SerializeField]
    GameObject findRoomView;
    [SerializeField] 
    FindRoomView findRoomViewObj;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        loading.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connection starting");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master server");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        roomViewObj.startGameVisible(PhotonNetwork.IsMasterClient);
    }

    public override void OnJoinedLobby()
    {
        loading.SetActive(false);
        if(string.IsNullOrEmpty(PhotonNetwork.NickName))
        {
            setNickNameView.SetActive(true);
        }
        else
        {
            menuView.SetActive(true);
        }
        //menuView.SetActive(true);
        Debug.Log("Joined to lobby");
    }

    public void CreateRoom()
    {
        menuView.SetActive(false);
        createRoomView.SetActive(true);
    }

    public void CreateNewRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
        createRoomView.SetActive(false);
        loading.SetActive(true);
    }

    public void CancelCreateNewRoom()
    {
        createRoomView.SetActive(false);
        menuView.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        loading.SetActive(false);
        roomView.SetActive(true);
        Debug.Log($"Joined to: {PhotonNetwork.CurrentRoom.Name}");
        roomViewObj.FillPlayerListContainer(PhotonNetwork.PlayerList);
        roomViewObj.startGameVisible(PhotonNetwork.IsMasterClient);
    }

    public override void OnPlayerEnteredRoom(Player player)
    {
        roomViewObj.AddPlayerToListContainer(player);
    }

    public override void OnPlayerLeftRoom(Player player)
    {
        roomViewObj.RemovePlayerInListContainer(player);
    }

    public void LeaveCurrentRoom()
    {
        PhotonNetwork.LeaveRoom();
        roomView.SetActive(false);
        loading.SetActive(true);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Exited form room");
    }

    public string CurrentRoomName => PhotonNetwork.CurrentRoom.Name;

    public void SetNickName(string nickName)
    {
        PhotonNetwork.NickName = nickName;
        setNickNameView.SetActive(false);
        menuView.SetActive(true);
    }

    public void FindRoomViewClick()
    {
        menuView.SetActive(false);
        findRoomView.SetActive(true);
    }
    public void LeaveFindRoomViewClick()
    {
        findRoomView.SetActive(false);
        menuView.SetActive(true);
    }

    public void JoinRoomClick(string roomName)
    {
        findRoomView.SetActive(false);
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnRoomListUpdate(List<RoomInfo> rooms)
    {
        findRoomViewObj.FillRoomList(rooms);
    }

    public void CreateGame()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
