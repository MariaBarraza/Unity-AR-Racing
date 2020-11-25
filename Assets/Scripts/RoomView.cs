using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;

public class RoomView : MonoBehaviour
{
    [SerializeField]
    TMP_Text txtRoomName;
    [SerializeField]
    Button btnLeaveRoom;
    [SerializeField]
    RectTransform playerListContainer;
    [SerializeField]
    Object srcPlayerNickNameItem;
    [SerializeField]
    Button btnStartGame;

    void Awake()
    {
        btnLeaveRoom.onClick.AddListener(LeaveCurrentRoom);
        btnStartGame.onClick.AddListener(Launcher.instance.CreateGame);
    }

    public void SetRoomName(string roomName) => txtRoomName.text = roomName;

    void OnEnable()
    {
        SetRoomName(Launcher.instance.CurrentRoomName);
    }

    public void startGameVisible(bool visible) => btnStartGame.gameObject.SetActive(visible);

    void LeaveCurrentRoom()
    {
        SetRoomName(string.Empty);
        Launcher.instance.LeaveCurrentRoom();
    }

    void ClearPlayerListContainer()
    {
        foreach(GameObject go in playerListContainer)
        {
            Destroy(go);
        }
    }

    public void AddPlayerToListContainer(Player player)
    {
        GameObject go = (GameObject) Instantiate(srcPlayerNickNameItem, playerListContainer);
        TMP_Text playerNickNameItem = go.GetComponent<TMP_Text>();
        playerNickNameItem.text = player.NickName;
    }

    public void RemovePlayerInListContainer(Player player)
    {
        foreach(GameObject go in playerListContainer)
        {
            TMP_Text playerNickNameItem = go.GetComponent<TMP_Text>();
            if(playerNickNameItem.text == player.NickName)
            {
                Destroy(go);
            }
        }
    }

    public void FillPlayerListContainer(Player[] playerList)
    {
        ClearPlayerListContainer();
        foreach(Player p in playerList)
        {
            GameObject go = (GameObject) Instantiate(srcPlayerNickNameItem, playerListContainer);
            TMP_Text playerNickNameItem = go.GetComponent<TMP_Text>();
            playerNickNameItem.text = p.NickName;
        }
    }
}
