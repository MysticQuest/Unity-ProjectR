using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class MouseObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Utilities.GetMousePosition() * 0.8f;
    }
}
