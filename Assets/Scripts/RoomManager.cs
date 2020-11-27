using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager instance;
    void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }    
        else
        {
            Destroy(gameObject);
        }
    }

    public override void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex == 1) // osea que si es el juego ya cargado
        {
            PhotonNetwork.Instantiate(Path.Combine("photon", "Persiano"), new Vector3(Random.Range(-0.2f, 0.5f), -3.594f, Random.Range(-1.0f, 0.0f)), Quaternion.identity);
        }
    }
}
