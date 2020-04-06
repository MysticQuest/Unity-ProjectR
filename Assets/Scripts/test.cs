using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using Cinemachine;

public class test : MonoBehaviour
{
    // public CinemachineImpulseSource impulseSource;
    [SerializeField] private Shoot playerShoot;

    private void Start()
    {
        playerShoot.OnShoot += PlayerShoot_OnShoot;
    }

    private void PlayerShoot_OnShoot(object sender, Shoot.OnShootEventArgs e)
    {
        // Utilities.ShakeCamera(1f, 0.2f);
        Debug.DrawLine(e.gunEndPointPosition, e.shootPosition, Color.white, .1f);
        // impulseSource.GenerateImpulse();
    }
}


