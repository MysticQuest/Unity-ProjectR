using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Blood Preset", menuName = "Blood Preset")]
public class BloodPresets : ScriptableObject
{
    public Vector3 position;
    public Vector3 direction;
    public Vector3 quadSize = new Vector3(.4f, .4f);

    public float moveSpeed;
    public float rotation;

    public int uvIndex;
    public int uvIndexMin;
    public int uvIndexMax;

    private void OnEnable()
    {
        uvIndex = Random.Range(uvIndexMin, uvIndexMax);
        direction = Quaternion.Euler(0, 0, Random.Range(-45f, 45f)) * -Vector3.up;
        moveSpeed = Random.Range(10f, 20f);
        rotation = Random.Range(0, 360f);
    }
}
