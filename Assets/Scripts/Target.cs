using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //Scriptable Object test
    // public BloodPresets bloodPreset;  

    public int health = 100;

    public Vector3 rbodyVelocity;

    private int bloodSplatterVollume;

    // private void OnCollisionEnter(Collision other)
    // {
    //     Damage();
    //     Debug.Log("Object Collision");
    // }

    private void OnParticleCollision(GameObject other)
    {
        ParticleSystem ps = other.GetComponent<ParticleSystem>();

        //unity bug workaround - collision at highspeeds happens before rendering the particle at hit point
        //enables collision module at shoot and disables at collision
        var psCollision = ps.collision;
        psCollision.enabled = false;
        // end of workaround

        List<ParticleCollisionEvent> collisionEvents;
        collisionEvents = new List<ParticleCollisionEvent>();
        int test = ps.GetCollisionEvents(this.gameObject, collisionEvents);
        Vector3 pointOfHit = collisionEvents[0].intersection;
        Vector3 splatterDir = (pointOfHit - other.transform.position).normalized;

        Damage(pointOfHit, splatterDir);

        Debug.Log("Particle Collision at " + pointOfHit);
    }


    public void Damage(Vector3 pointOfHit, Vector3 splatterDir)
    {
        health -= 5;

        int bloodVollumeDir = Random.Range(15, 25);
        int bloodVollumeFloor = Random.Range(2, 5);
        int bloodVollumeWound = Random.Range(7, 14);

        for (int i = 0; i <= bloodVollumeDir; i++)
        {
            GenerateBloodDir(pointOfHit, splatterDir);
        }
        for (int i = 0; i <= bloodVollumeFloor; i++)
        {
            GenerateBloodFloor(pointOfHit);
        }
        for (int i = 0; i <= bloodVollumeWound; i++)
        {
            GenerateBloodStain(pointOfHit);
        }
    }

    void GenerateBloodDir(Vector3 pointOfHit, Vector3 splatterDir)
    {
        Vector3 bloodDirDir = splatterDir + AddNoiseOnAngle(-5, 5);
        Vector3 quadSize = new Vector3(.4f, .4f);
        float moveSpeed = Random.Range(40f, 100f);
        float rotation = Random.Range(0, 360f);
        int uvIndex = Random.Range(0, 8);

        BloodParticleSystemHandler.Instance.SpawnBlood(pointOfHit, bloodDirDir, quadSize, false, false, moveSpeed, rotation, uvIndex);
    }

    void GenerateBloodFloor(Vector3 pointOfHit)
    {
        float moveSpeed = Random.Range(40f, 100f);
        float rotation = Random.Range(0, 360f);
        int uvIndex = Random.Range(0, 8);
        Vector3 quadSize = new Vector3(.4f, .4f);
        float bloodRotationFloor = Random.Range(-35f, 35f);
        Vector3 bloodDirFloor = Quaternion.Euler(0, 0, bloodRotationFloor) * -Vector3.up * .25f;

        BloodParticleSystemHandler.Instance.SpawnBlood(pointOfHit, bloodDirFloor, quadSize, false, false, moveSpeed, rotation, uvIndex);
    }

    void GenerateBloodStain(Vector3 pointOfHit)
    {
        float rotation = Random.Range(0, 360f);
        Vector3 woundQuadSize = new Vector3(.3f, .3f);
        int uvIndex = Random.Range(0, 8);

        Vector3 pointOfHitLocal = transform.InverseTransformPoint(pointOfHit);
        if (pointOfHitLocal.x > 0)
        {
            pointOfHitLocal.x -= Random.Range(.05f, .3f);
        }
        else { pointOfHitLocal.x += Random.Range(.05f, .3f); }
        if (pointOfHitLocal.y > 0)
        {
            pointOfHitLocal.y -= Random.Range(.05f, .3f);
        }
        else { pointOfHitLocal.y += Random.Range(.05f, .3f); }

        //blood wound
        WoundParticleSystemHandler.Instance.SpawnWound(pointOfHitLocal, Vector3.zero, woundQuadSize, false, 0f, rotation, uvIndex);
    }

    Vector3 AddNoiseOnAngle(float min, float max)
    {
        // Find random angle between min & max inclusive
        float xNoise = Random.Range(min, max);
        float yNoise = Random.Range(min, max);
        float zNoise = Random.Range(min, max);

        // Convert Angle to Vector3
        Vector3 noise = new Vector3(
          Mathf.Sin(2 * Mathf.PI * xNoise / 360),
          Mathf.Sin(2 * Mathf.PI * yNoise / 360),
          Mathf.Sin(2 * Mathf.PI * zNoise / 360)
        );
        return noise;
    }
}
