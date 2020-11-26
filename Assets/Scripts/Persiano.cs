using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Persiano : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float runSpeed;
    Animator anim;
    [SerializeField]
    Button sprint;

    Vector3 Axis = Vector3.zero;

    bool run = true;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sprint.onClick.AddListener(Sprint);
    }

    void Update()
    {
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
