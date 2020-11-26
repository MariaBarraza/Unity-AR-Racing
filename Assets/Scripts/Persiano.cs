using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun;

public class Persiano : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float runSpeed;
    Animator anim;

    GameObject right, left, up, down;
    Button sprint;

    Vector3 Axis = Vector3.zero;

    bool run = true;
    PhotonView photonView;

    void Awake()
    {
        right = GameObject.Find("Canvas/Right");
        left = GameObject.Find("Canvas/Left");
        up = GameObject.Find("Canvas/Up");
        down = GameObject.Find("Canvas/Down");
        sprint = GameObject.Find("Canvas/Sprint").GetComponent<Button>();
        anim = GetComponent<Animator>();
        sprint.onClick.AddListener(Sprint);
        photonView = GetComponent<PhotonView>();
    }

    void Start()
    {
        //right
        EventTrigger rightTrigger = right.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener( (eventData) => { Axis.x += 1; } );
        rightTrigger.triggers.Add(entry);
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener( (eventData) => { Axis.x -= 1; } );
        rightTrigger.triggers.Add(entry);
        //left
        EventTrigger leftTrigger = left.GetComponent<EventTrigger>();
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener( (eventData) => { Axis.x -= 1; } );
        leftTrigger.triggers.Add(entry);
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener( (eventData) => { Axis.x += 1; } );
        leftTrigger.triggers.Add(entry);
        //up
        EventTrigger upTrigger = up.GetComponent<EventTrigger>();
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener( (eventData) => { Axis.z += 1; } );
        upTrigger.triggers.Add(entry);
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener( (eventData) => { Axis.z -= 1; } );
        upTrigger.triggers.Add(entry);
        //down
        EventTrigger downTrigger = down.GetComponent<EventTrigger>();
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener( (eventData) => { Axis.z -= 1; } );
        downTrigger.triggers.Add(entry);
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener( (eventData) => { Axis.z += 1; } );
        downTrigger.triggers.Add(entry);
    }

    void Update()
    {
        if(!photonView.IsMine) return;

        transform.Translate(Axis.normalized.magnitude * Vector3.forward * moveSpeed * Time.deltaTime);

        if(Axis != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Axis.normalized);
        }
        anim.SetFloat("move", Mathf.Abs(Axis.normalized.magnitude));
    }

    IEnumerator Run()
    {
        float temp = moveSpeed;
        moveSpeed = runSpeed;
        anim.SetBool("run", true);
        yield return new WaitForSeconds(1f);
        moveSpeed = temp;
        anim.SetBool("run", false);
        yield return new WaitForSeconds(3f);
        run = true;
    }

    public void RightDown()
    {
        Axis.x += 1;
    }

    public void RightUp()
    {
        Axis.x -= 1;
    }

    public void LeftDown()
    {
        Axis.x -= 1;
    }

    public void LeftUp()
    {
        Axis.x += 1;
    }

    public void UpDown()
    {
        Axis.z += 1;
    }

    public void UpUp()
    {
        Axis.z -= 1;
    }

    public void DownDown()
    {
        Axis.z -= 1;
    }

    public void DownUp()
    {
        Axis.z += 1;
    }

    void Sprint()
    {
        if(run)
        {
            StartCoroutine(Run());
            run = false;
        }
    }
}
