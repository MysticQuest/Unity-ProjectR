using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Transform objectThatAims;

    private Animator charAnimator;
    private Animator aimAnimator;

    private void Awake()
    {
        if (!objectThatAims)
        {
            objectThatAims = transform.Find("aim");
        }

        charAnimator = GetComponent<Animator>();
        aimAnimator = objectThatAims.GetComponent<Animator>();
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
