using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    bool isGameEnded;
    [SerializeField]
    GameObject panel;

    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            //isMoving = false;
            isGameEnded = true;
            panel.SetActive(true);
        }
    }
}
