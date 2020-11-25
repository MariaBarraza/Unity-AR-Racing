using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    [SerializeField]
    Button btnCreateRoom;
    [SerializeField]
    Button btnFindRoom;

    void Awake() 
    {
        btnCreateRoom.onClick.AddListener(CreateRoomClick);
        btnFindRoom.onClick.AddListener(FindRoomClick);
    }

    void CreateRoomClick()
    {
        Launcher.instance.CreateRoom();
        Debug.Log("Create Room View");
    }

    void FindRoomClick()
    {
        Launcher.instance.FindRoomViewClick();
        Debug.Log("Back to MenuView");
    }
}
