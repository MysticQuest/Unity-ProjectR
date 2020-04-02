using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocity : MonoBehaviour, IMoveVector
{
    [SerializeField] private float moveSpeed = 5f;

    private AnimationControl animControl;

    private Vector3 velocityVector;
    private Rigidbody2D rbody;

    private void Awake()
    {
        animControl = GetComponent<AnimationControl>();
        rbody = GetComponent<Rigidbody2D>();
    }

    public void SetVector(Vector3 keyVector, Vector3 mouseVector)
    {
        this.velocityVector = keyVector.normalized;
    }

    private void FixedUpdate()
    {
        MovePhysics();
        DetectMovement();
    }

    private void MovePhysics()
    {
        rbody.velocity = velocityVector * moveSpeed;
    }

    private void DetectMovement()
    {
        if (velocityVector != Vector3.zero)
        {
            animControl.isMoving();
        }
        else
        {
            animControl.isIdle();
        }
    }
}
