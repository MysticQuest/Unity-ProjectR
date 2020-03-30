using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PlayerInputMouse : MonoBehaviour
{
    private MoveToPositionDirect moveTo;
    public RaycastHit hitInfo;

    private void Awake()
    {
        moveTo = GetComponent<MoveToPositionDirect>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            moveTo.SetMovePosition(Utilities.GetMousePosition());
        }
    }
}
