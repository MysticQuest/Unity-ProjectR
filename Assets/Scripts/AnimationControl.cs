using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator anim;

    void Start()
    {

    }

    void Update()
    {

    }

    public void isMoving()
    {
        anim.SetBool("isMoving", true);
    }

    public void isIdle()
    {
        anim.SetBool("isMoving", false);
    }
}
