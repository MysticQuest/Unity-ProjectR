using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        Damage();
        Debug.Log("Object Collision");
    }

    private void OnParticleCollision(GameObject other)
    {
        Damage();
        Debug.Log("Particle Collision");
    }


    public void Damage()
    {
        float bloodRotation = Random.Range(-45f, 45f);
        Vector3 bloodDir = Quaternion.Euler(0, 0, bloodRotation) * -Vector3.up;
        Vector3 bloodPos = transform.position + new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f));
        BloodParticleSystemHandler.Instance.SpawnBlood(bloodPos, bloodDir);
        health -= 5;
    }
}
