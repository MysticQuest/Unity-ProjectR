using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class AimTopDown : MonoBehaviour
{
    [Header("Aim Options")]
    public Transform objectThatAims;
    public GameObject aimTarget;

    private Vector3 aimTargetTransform;
    private Vector3 aimDirection;
    private bool isPlayer = false;

    private float angle;

    private Transform mainBody;

    private void Awake()
    {
        mainBody = transform.Find("main"); //used only in the flip placeholder function

        if (!objectThatAims)
        {
            objectThatAims = transform.Find("aim");
        }

        if (this.name == "Player")
        {
            isPlayer = true;
        }
    }

    private void Update()
    {
        Aim();
        Flip();
    }

    private void Aim()
    {
        if (isPlayer)
        {
            aimTargetTransform = Utilities.GetMousePosition();
        }
        else
        {
            aimTargetTransform = aimTarget.transform.position;
        }


        aimDirection = (aimTargetTransform - transform.position).normalized;
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        Vector3 rotationVector = Vector3.zero;
        rotationVector.z = angle;
        objectThatAims.eulerAngles = rotationVector;
    }

    private void Flip()
    {
        Vector3 lookDir = Vector3.one;
        lookDir.x = Mathf.Sign(aimTargetTransform.x - transform.position.x);
        if (lookDir.x == 0) { return; }
        mainBody.localScale = lookDir;

        Vector3 weaponDir = Vector3.one;
        weaponDir.y = lookDir.x;
        objectThatAims.localScale = weaponDir;
    }
}