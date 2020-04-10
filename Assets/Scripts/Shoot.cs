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
    public ParticleSystem bulletFX;

    private AnimationControl animControl;

    [Header("Crosshair Options")]
    [SerializeField] private bool EnableCrosshair;
    [SerializeField] private Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        if (!gunEndPointTransform)
        {
            gunEndPointTransform = transform.Find("aim/endPoint");
        }

        animControl = GetComponent<AnimationControl>();
        bulletFX = transform.Find("aim/gun/mask/bulletFX").GetComponent<ParticleSystem>();

        if (EnableCrosshair)
        {
            hotSpot = new Vector2(cursorTexture.width / 2f, cursorTexture.height / 2f);
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
    }

    private void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animControl.isShooting();

            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                gunEndPointPosition = gunEndPointTransform.position,
                shootPosition = Utilities.GetMousePosition(),
            });
        }
    }
}
