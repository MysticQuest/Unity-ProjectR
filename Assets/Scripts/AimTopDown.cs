using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class AimTopDown : MonoBehaviour
{
    public Transform objectThatAims;
    public GameObject aimTarget;

    private Vector3 aimTargetTransform;
    private Vector3 aimDirection;
    private bool isPlayer = false;

    private float angle;
    private Vector3 rotationVector;

    private void Awake()
    {
        rotationVector = Vector3.zero;

        if (objectThatAims == null || aimTarget == null && this.name != "Player")
        {
            Debug.LogError("Please assign an object to rotate/target for " + this);
        }

        if (this.name == "Player")
        {
            isPlayer = true;
        }
    }

    private void Update()
    {
        Aim();
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
        rotationVector.z = angle;
        objectThatAims.eulerAngles = rotationVector;
    }
}
