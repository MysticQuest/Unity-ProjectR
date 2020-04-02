using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputKeys : MonoBehaviour
{
    private IMoveVector moveInterface;
    private AnimationControl animControl;
    private Vector3 moveVector;

    float moveX = 0f;
    float moveY = 0f;

    private bool isMoving;

    private void Awake()
    {
        moveInterface = GetComponent<IMoveVector>();
        animControl = GetComponent<AnimationControl>();
        moveVector = new Vector3(moveX, moveY);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveVector.x = moveX;
        moveVector.y = moveY;

        moveInterface.SetVector(moveVector, Vector3.zero);
    }
}