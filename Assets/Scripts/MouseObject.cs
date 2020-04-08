using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class MouseObject : MonoBehaviour
{
    void Update()
    {
        transform.position = Utilities.GetMousePosition() * 0.8f;
    }
}
