using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //Scriptable Object test
    // public BloodPresets bloodPreset;  

    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        Debug.Log("Particle Collision at " + pointOfHit);
    }


    public void Damage(Vector3 pointOfHit, Vector3 splatterDir)
    {
        health -= 5;

        float bloodRotation = Random.Range(-45f, 45f);
        Vector3 bloodDir = Quaternion.Euler(0, 0, bloodRotation) * -Vector3.up;
        Vector3 bloodDirCol = splatterDir * 5f;
        Vector3 quadSize = new Vector3(.4f, .4f);
        float moveSpeed = Random.Range(20f, 40f);
        float rotation = Random.Range(0, 360f);
        int uvIndex = Random.Range(0, 8);
        Vector3 bloodPos = pointOfHit + new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f));

        // BloodParticleSystemHandler.Instance.SpawnBlood(pointOfHit, Vector3.zero, quadSize, 0f, rotation, uvIndex);

        BloodParticleSystemHandler.Instance.SpawnBlood(bloodPos, splatterDir, quadSize, moveSpeed, rotation, uvIndex);

        //Scriptable Object test
        // BloodParticleSystemHandler.Instance.SpawnBlood(bloodPos, bloodPreset.direction, bloodPreset.quadSize, bloodPreset.moveSpeed, bloodPreset.rotation, bloodPreset.uvIndex);
    }
}
