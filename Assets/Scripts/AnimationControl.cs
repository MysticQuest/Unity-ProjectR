using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator charAnimator;
    private Transform aimTransform;
    private Animator aimAnimator;

    private void Awake()
    {
        charAnimator = GetComponent<Animator>();
        aimTransform = transform.Find("Aim");
        aimAnimator = aimTransform.GetComponent<Animator>();
    }

    public void isMoving()
    {
        charAnimator.SetBool("isMoving", true);
    }

    public void isIdle()
    {
        charAnimator.SetBool("isMoving", false);
    }

    public void isShooting()
    {
        aimAnimator.SetTrigger("Shoot");
    }

}
