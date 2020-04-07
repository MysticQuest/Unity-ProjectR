using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using Cinemachine;

public class test : MonoBehaviour
{
    // public CinemachineImpulseSource impulseSource;
    [SerializeField] private Shoot playerShoot;
    private CinemachineImpulseSource impulseSource;

    private void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();

        playerShoot.OnShoot += Player_OnShoot;
    }

    private void Player_OnShoot(object sender, Shoot.OnShootEventArgs e)
    {
        impulseSource.GenerateImpulse();


        playerShoot.bulletFX.Emit(1);
        // WeaponTracer(e.gunEndPointPosition, e.shootPosition);
        Debug.DrawLine(e.gunEndPointPosition, e.shootPosition, Color.white, .1f);
    }

    // private void WeaponTracer(Vector3 fromPosition, Vector3 targetPosition)
    // {
    //     Vector3 dir = (targetPosition - fromPosition).normalized;
    // }
}


