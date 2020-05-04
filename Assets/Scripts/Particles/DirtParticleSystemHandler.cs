using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtParticleSystemHandler : MonoBehaviour
{
    public static DirtParticleSystemHandler Instance { get; private set; }

    private MeshParticleSystem meshParticleSystem;
    private List<Single> singleList;

    [SerializeField] private MoveVelocity moveVelocity;

    private void Awake()
    {
        Instance = this;
        singleList = new List<Single>();
        meshParticleSystem = GetComponent<MeshParticleSystem>();

        if (!moveVelocity)
        {
            moveVelocity = GameObject.Find("Player").GetComponent<MoveVelocity>();
        }
    }

    private void Update()
    {
        for (int i = 0; i < singleList.Count; i++)
        {
            Single single = singleList[i];
            single.Update();
            if (single.StoppedMoving())
            {
                single.DestroySelf();
                singleList.RemoveAt(i);
                i--;
            }
        }
    }

    public void SpawnDirt(Vector3 position, Vector3 direction)
    {
        singleList.Add(new Single(position, direction, meshParticleSystem, moveVelocity));
    }

    private class Single
    {
        private MeshParticleSystem meshParticleSystem;
        private Vector3 position;
        private Vector3 direction;
        private int quadIndex;
        private Vector3 quadSize;
        private float moveSpeed;
        private int uvIndex;
        private float uvIndexTimer;
        private float uvIndexTimerMax;



        public Single(Vector3 position, Vector3 direction, MeshParticleSystem meshParticleSystem, MoveVelocity moveVelocity)
        {
            this.position = position;
            this.direction = direction;
            this.meshParticleSystem = meshParticleSystem;

            if (moveVelocity.velocityVector.y == 0)
            {
                quadSize = new Vector3(.3f, .2f);
            }
            else
            {
                quadSize = new Vector3(.5f, .4f);
            }

            moveSpeed = Random.Range(3f, 4f);
            uvIndex = 0;
            uvIndexTimerMax = 1f / 20;

            quadIndex = meshParticleSystem.AddQuad(position, 0f, quadSize, true, uvIndex);
        }

        public void Update()
        {
            uvIndexTimer += Time.deltaTime;
            if (uvIndexTimer >= uvIndexTimerMax)
            {
                uvIndexTimer -= uvIndexTimerMax;
                uvIndex++;
            }

            position += direction * Time.deltaTime * moveSpeed;

            meshParticleSystem.UpdateQuad(quadIndex, position, 0f, quadSize, true, uvIndex);

            float slowdownFactor = 25f;
            moveSpeed -= moveSpeed * slowdownFactor * Time.deltaTime;
        }

        public bool StoppedMoving()
        {
            return uvIndex >= 8 || moveSpeed < .001;
        }

        public void DestroySelf()
        {
            meshParticleSystem.DestroyQuad(quadIndex);
        }
    }
}
