using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocity : MonoBehaviour, IMoveVelocity
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

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    private void FixedUpdate()
    {
        rbody.velocity = velocityVector * moveSpeed;
        // anim.PlayMoveAnim(velocityVector);
    }
}
