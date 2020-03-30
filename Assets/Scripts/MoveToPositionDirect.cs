using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPositionDirect : MonoBehaviour
{
    private IMoveVector moveInterface;

    private Vector3 movePosition;

    private void Start()
    {
        moveInterface = GetComponent<IMoveVector>();
    }

    public void SetMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
        moveInterface.SetVector(Vector3.zero, movePosition);
    }

}
