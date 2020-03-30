using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PlayerInputMouse : MonoBehaviour
{
    private MoveToPositionDirect moveTo;

    private void Awake()
    {
        moveTo = GetComponent<MoveToPositionDirect>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            moveTo.wasUpdated = true;
            moveTo.SetMovePosition(Utilities.GetMousePosition());
        }
    }
}
