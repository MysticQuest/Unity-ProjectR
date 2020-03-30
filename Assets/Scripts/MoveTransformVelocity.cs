using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransformVelocity : MonoBehaviour, IMoveVelocity
{
    [SerializeField] private float moveSpeed = 5f;
    //
    MoveToPositionDirect moveDirectScript;
    //
    private Vector3 velocityVector;
    // private anim characterBase; animation stuff

    private void Awake()
    {
        // anim = GetComponent<Character_Base>();
        moveDirectScript = GetComponent<MoveToPositionDirect>();
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }
    //pandora stuff
    float timeAccum = 0;
    float totalTravelTimeRequired = 0;
    Vector3 startPos;
    private void Update()
    {
        //pandora  stuff
        if (moveDirectScript.wasUpdated)
        {
            timeAccum = 0;
            totalTravelTimeRequired = Vector3.Distance(transform.position, velocityVector) / moveSpeed;
            startPos = transform.position;
            moveDirectScript.wasUpdated = false;
        }
        timeAccum += Time.deltaTime;
        if (timeAccum >= totalTravelTimeRequired)
        {
            timeAccum = totalTravelTimeRequired;
        }
        if (totalTravelTimeRequired != 0)
            transform.position = Vector3.Lerp(startPos, velocityVector, timeAccum / totalTravelTimeRequired);
        //end
        // transform.position = Vector3.Lerp(0, 1, 0.9);
        // anim.PlayMoveAnim(velocityVector);
    }
}
