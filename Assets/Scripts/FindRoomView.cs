using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class FindRoomView : MonoBehaviour
{
    [SerializeField]
    ScrollRect sRectRoomList;
    [SerializeField]
    Button btnLeaveFindRoom;
    [SerializeField]
    Object srcRoomItem;

    void Awake()
    {
        btnLeaveFindRoom.onClick.AddListener(Launcher.instance.LeaveFindRoomViewClick);
    }

    void ClearRoomList()
    {
        foreach(GameObject go in sRectRoomList.content)
        {
            Destroy(go);
        }
    }
    
    public void FillRoomList(List<RoomInfo> rooms)
    {
        ClearRoomList();
        
        foreach(RoomInfo room in rooms)
        {
            GameObject go = (GameObject) Instantiate(srcRoomItem, sRectRoomList.content);
            RoomItem roomItem = go.GetComponent<RoomItem>();
            roomItem.SetRoomName(room.Name);
        }
    }
}
