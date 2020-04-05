using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class test : MonoBehaviour
{
    [SerializeField] private Shoot playerShoot;

    private void Start()
    {
        playerShoot.OnShoot += PlayerShoot_OnShoot;
    }

    private void PlayerShoot_OnShoot(object sender, Shoot.OnShootEventArgs e)
    {
        // Utilities.ShakeCamera(1f, 0.2f);
        Debug.Log("Shoot");

    }
}


