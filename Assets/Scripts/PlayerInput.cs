using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private IMoveVelocity moveVelocity;

    float moveX = 0f;
    float moveY = 0f;

    private void Awake()
    {
        moveVelocity = GetComponent<IMoveVelocity>();
    }

    private void Update()
    {
        Walk();
    }

    private void Walk()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveVector = new Vector2(moveX, moveY).normalized;
        moveVelocity.SetVelocity(moveVector);
    }
}
