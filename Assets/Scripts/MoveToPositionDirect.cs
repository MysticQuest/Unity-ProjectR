using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPositionDirect : MonoBehaviour
{
    private Vector3 movePosition;
    private IMoveVelocity moveInterface;
    public bool wasUpdated = false;
    public void SetMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
        moveInterface.SetVelocity(movePosition);
    }

    private void Start()
    {
        moveInterface = GetComponent<IMoveVelocity>();
    }

    // Update is called once per frame
    // private void Update()
    // {
    //     Vector3 moveTo = (movePosition - transform.position);
    //     // Debug.Log(Vector3.Distance(movePosition, this.transform.position));
    //     // if (Vector3.Distance(movePosition, this.transform.position) > 0.01f)
    //     moveInterface.SetVelocity(movePosition);
    // }
}
