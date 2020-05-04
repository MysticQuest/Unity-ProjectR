using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocity : MonoBehaviour, IMoveVector
{
    [SerializeField] private float moveSpeed = 5f;

    public Vector3 velocityVector;
    private Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    public void SetVector(Vector3 keyVector, Vector3 mouseVector)
    {
        this.velocityVector = keyVector.normalized;
    }

    private void FixedUpdate()
    {
        MovePhysics();
    }

    private void MovePhysics()
    {
        rbody.velocity = velocityVector * moveSpeed;
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public Vector3 GetDirection()
    {
        return velocityVector;
    }
}
