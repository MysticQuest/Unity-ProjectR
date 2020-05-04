using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Transform objectThatAims;

    private Animator charAnimator;
    private Animator aimAnimator;

    public bool isMoving; //move this elsewhere at some point

    private void Awake()
    {
        if (!objectThatAims)
        {
            objectThatAims = transform.Find("aim");
        }

        charAnimator = GetComponent<Animator>();
        aimAnimator = objectThatAims.GetComponent<Animator>();
    }

    public void IsMoving()
    {
        charAnimator.SetBool("isMoving", true);
        isMoving = true;
    }

    public void IsIdle()
    {
        charAnimator.SetBool("isMoving", false);
        isMoving = false;
    }

    public void IsShooting()
    {
        aimAnimator.SetTrigger("Shoot");
    }

}
