using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticleSystemHandler : MonoBehaviour
{
    public static BloodParticleSystemHandler Instance { get; private set; }

    private MeshParticleSystem meshParticleSystem;
    private List<Single> singleList;

    private void Awake()
    {
        Instance = this;
        singleList = new List<Single>();
        meshParticleSystem = GetComponent<MeshParticleSystem>();
    }

    private void Update()
    {
        for (int i = 0; i < singleList.Count; i++)
        {
            Single single = singleList[i];
            single.Update();
            if (single.StoppedMoving())
            {
                singleList.RemoveAt(i);
                i--;
            }
        }
    }

    public void SpawnBlood(Vector3 position, Vector3 direction, Vector3 quadSize, bool onObject, bool isPooling, float moveSpeed, float rotation, int uvIndex)
    {
        singleList.Add(new Single(position, direction, quadSize, onObject, isPooling, moveSpeed, rotation, uvIndex, meshParticleSystem));
    }

    private class Single
    {
        private MeshParticleSystem meshParticleSystem;
        private Vector3 position;
        private Vector3 direction;
        private int quadIndex;
        private Vector3 quadSize;
        private float moveSpeed;
        private float rotation;
        private int uvIndex;

        //experimental
        private bool onObject;
        private bool isPooling;

        public Single(Vector3 position, Vector3 direction, Vector3 quadSize, bool onObject, bool isPooling, float moveSpeed, float rotation, int uvIndex, MeshParticleSystem meshParticleSystem)
        {
            // quadSize = new Vector3(.4f, .4f);
            // moveSpeed = Random.Range(10f, 20f);
            // rotation = Random.Range(0, 360f);
            // uvIndex = Random.Range(0, 8);

            this.position = position;
            this.direction = direction;
            this.quadSize = quadSize;
            this.moveSpeed = moveSpeed;
            this.rotation = rotation;
            this.uvIndex = uvIndex;

            this.meshParticleSystem = meshParticleSystem;

            quadIndex = meshParticleSystem.AddQuad(position, rotation, quadSize, true, uvIndex);
        }

        public void Update()
        {
            if (onObject == true)
            {

                meshParticleSystem.UpdateQuad(quadIndex, position, rotation, quadSize, true, uvIndex);
            }
            else
            {
                position += direction * Time.deltaTime * moveSpeed;
                rotation += 360f * (moveSpeed / 10f) * Time.deltaTime;
                if (moveSpeed < 2.5f)
                {
                    quadSize *= 1.008f;
                }

                meshParticleSystem.UpdateQuad(quadIndex, position, rotation, quadSize, true, uvIndex);

                float slowdownFactor = 20f;
                moveSpeed -= moveSpeed * slowdownFactor * Time.deltaTime;
            }
        }

        public bool StoppedMoving()
        {
            return moveSpeed < .01;
        }
    }
}
