using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PlayerInputMouse : MonoBehaviour
{
    private GoToTarget moveTo;
    public RaycastHit hitInfo;

    private void Awake()
    {
        moveTo = GetComponent<GoToTarget>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            moveTo.SetMovePosition(Utilities.GetMousePosition());
        }
    }
}
