using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateRoomView : MonoBehaviour
{
    [SerializeField]
    TMP_InputField roomNameField;
    [SerializeField]
    Button btnCreateNewRoom;
    [SerializeField]
    Button btnCancelCreateNewRoom;

    void Awake()
    {
        btnCreateNewRoom.onClick.AddListener(CreateNewRoom);
        btnCancelCreateNewRoom.onClick.AddListener(GoBack);
    }

    string RoomName => roomNameField.text;

    bool RoomNameIsEmpty => string.IsNullOrEmpty(RoomName);

    void CreateNewRoom()
    {
        if(RoomNameIsEmpty) return;
        Launcher.instance.CreateNewRoom(RoomName);
    }

    void GoBack()
    {
        Launcher.instance.CancelCreateNewRoom();
    }
}
