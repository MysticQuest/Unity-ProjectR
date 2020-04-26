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
        Debug.Log("Collided with Object");
    }

    private void OnParticleCollision(GameObject other)
    {
        Damage();
        Debug.Log("Collided with Particle");
    }


    public void Damage()
    {
        health -= 5;
    }
}
