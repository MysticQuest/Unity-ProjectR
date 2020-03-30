using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private IMoveVelocity moveInterface;
    private Vector3 moveVector;

    float moveX = 0f;
    float moveY = 0f;

    private void Awake()
    {
        moveInterface = GetComponent<IMoveVelocity>();
        moveVector = new Vector3(moveX, moveY);
    }

    private void Update()
    {
        Walk();
    }

    private void Walk()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveVector.x = moveX;
        moveVector.y = moveY;

        moveInterface.SetVelocity(moveVector);
    }
}