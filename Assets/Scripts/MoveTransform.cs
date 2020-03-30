using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransform : MonoBehaviour, IMoveVector
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector3 keyVector;
    private Vector3 mouseVector;
    // private Character_Base characterBase; animation stuff

    private void Awake()
    {
        // characterBase = GetComponent<Character_Base>();
    }

    public void SetVector(Vector3 keyVector, Vector3 mouseVector)
    {
        this.keyVector = keyVector;
        this.mouseVector = mouseVector;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, mouseVector, moveSpeed * Time.deltaTime);
        transform.position += keyVector.normalized * moveSpeed * Time.deltaTime;
    }
}
