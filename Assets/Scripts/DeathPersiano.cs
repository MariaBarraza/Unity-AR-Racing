using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPersiano : MonoBehaviour
{
    [SerializeField]
    Transform startPosition;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.transform.position = startPosition.position;
            collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
