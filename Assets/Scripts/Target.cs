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
        health -= 5;
    }
}
