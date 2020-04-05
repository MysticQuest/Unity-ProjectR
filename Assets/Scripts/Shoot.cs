using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Shoot : MonoBehaviour
{

    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }

    public Transform gunEndPointTransform;

    private AnimationControl animControl;

    private void Awake()
    {
        if (!gunEndPointTransform)
        {
            gunEndPointTransform = transform.Find("aim/endPoint");
        }

        animControl = GetComponent<AnimationControl>();
    }

    private void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButton(0))
        {
            animControl.isShooting();

            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                gunEndPointPosition = gunEndPointTransform.position,
                shootPosition = Utilities.GetMousePosition()
            });
        }
    }
}
