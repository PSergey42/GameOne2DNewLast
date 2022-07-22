using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public bool isOpen;
    private Animator animations;
    void Start()
    {
        animations = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        Debug.Log("daaaa");
        isOpen = !isOpen;
        GetComponent<PolygonCollider2D>().enabled = !isOpen;
        if(isOpen)
            animations.SetTrigger("isOpen");
        else
            animations.SetTrigger("isClose");

    }
}
