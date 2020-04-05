using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] private Transform pfBullet;
    private AnimationControl animControl;

    private void Awake()
    {
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
        }
    }
}
