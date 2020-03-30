using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocity : MonoBehaviour, IMoveVector
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector3 velocityVector;
    private Rigidbody2D rbody;
    // private anim characterBase; animation stuff

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        // anim = GetComponent<Character_Base>();
    }

    public void SetVector(Vector3 keyVector, Vector3 mouseVector)
    {
        this.velocityVector = keyVector.normalized;
    }

    private void FixedUpdate()
    {
        rbody.velocity = velocityVector * moveSpeed;
        // anim.PlayMoveAnim(velocityVector);
    }
}
