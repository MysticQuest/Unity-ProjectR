using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //Scriptable Object test
    // public BloodPresets bloodPreset;  

    public int health = 100;

    private Rigidbody2D rbody;
    public Vector3 rbodyVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // rbodyVelocity = rbody.velocity;
        rbodyVelocity = transform.position;
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     Damage();
    //     Debug.Log("Object Collision");
    // }

    private void OnParticleCollision(GameObject other)
    {
        ParticleSystem ps = other.GetComponent<ParticleSystem>();
        List<ParticleCollisionEvent> collisionEvents;
        collisionEvents = new List<ParticleCollisionEvent>();
        int test = ps.GetCollisionEvents(this.gameObject, collisionEvents);
        Vector3 pointOfHit = collisionEvents[0].intersection;
        Vector3 splatterDir = (pointOfHit - other.transform.position).normalized;

        Damage(pointOfHit, splatterDir);
        // Debug.Log("Particle Collision at " + pointOfHit);
    }


    public void Damage(Vector3 pointOfHit, Vector3 splatterDir)
    {
        health -= 5;

        float bloodRotation = Random.Range(-45f, 45f);
        Vector3 bloodDir = Quaternion.Euler(0, 0, bloodRotation) * -Vector3.up;
        Vector3 bloodDirCol = splatterDir * 5f;
        Vector3 quadSize = new Vector3(.4f, .4f);
        Vector3 woundQuadSize = new Vector3(.3f, .3f);
        float moveSpeed = Random.Range(30f, 60f);
        float rotation = Random.Range(0, 360f);
        int uvIndex = Random.Range(0, 8);


        Vector3 pointOfHitLocal = transform.InverseTransformPoint(pointOfHit);
        if (pointOfHitLocal.x > 0)
        {
            pointOfHitLocal.x -= Random.Range(.05f, .2f);
        }
        else { pointOfHitLocal.x += Random.Range(.05f, .2f); }
        if (pointOfHitLocal.y > 0)
        {
            pointOfHitLocal.y -= Random.Range(.05f, .2f);
        }
        else { pointOfHitLocal.y += Random.Range(.05f, .2f); }

        //blood wound
        WoundParticleSystemHandler.Instance.SpawnWound(pointOfHitLocal, Vector3.zero, woundQuadSize, false, 0f, rotation, uvIndex);

        //blood pool
        // BloodParticleSystemHandler.Instance.SpawnBlood(pointOfHit, Vector3.zero, quadSize, false, true, 0f, rotation, uvIndex);

        // blood splatter
        BloodParticleSystemHandler.Instance.SpawnBlood(pointOfHit, splatterDir, quadSize, false, false, moveSpeed, rotation, uvIndex);
    }
}
