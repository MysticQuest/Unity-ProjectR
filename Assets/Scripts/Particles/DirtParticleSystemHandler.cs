using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtParticleSystemHandler : MonoBehaviour
{
    public static ShellParticleSystemHandler Instance { get; private set; }

    private MeshParticleSystem meshParticleSystem;
    private List<SingleShell> singleShellList;

    private void Awake()
    {
        Instance = this;
        singleShellList = new List<SingleShell>();
        meshParticleSystem = GetComponent<MeshParticleSystem>();
    }

    private void Update()
    {
        for (int i = 0; i < singleShellList.Count; i++)
        {
            SingleShell singleShell = singleShellList[i];
            singleShell.Update();
            if (singleShell.StoppedMoving())
            {
                singleShellList.RemoveAt(i);
                i--;
            }
        }
    }

    public void SpawnShell(Vector3 position, Vector3 direction)
    {
        singleShellList.Add(new SingleShell(position, direction, meshParticleSystem));
    }

    private class SingleShell
    {
        private MeshParticleSystem meshParticleSystem;
        private Vector3 position;
        private Vector3 direction;
        private int quadIndex;
        private Vector3 quadSize;
        private float rotation;
        private float moveSpeed;

        public SingleShell(Vector3 position, Vector3 direction, MeshParticleSystem meshParticleSystem)
        {
            this.position = position;
            this.direction = direction;
            this.meshParticleSystem = meshParticleSystem;

            quadSize = new Vector3(.05f, .1f);
            rotation = Random.Range(0, 360f);
            moveSpeed = Random.Range(4f, 6f);

            quadIndex = meshParticleSystem.AddQuad(position, rotation, quadSize, true, 0);
        }

        public void Update()
        {
            position += direction * Time.deltaTime * moveSpeed;
            rotation += 360f * (moveSpeed / 10f) * Time.deltaTime;

            meshParticleSystem.UpdateQuad(quadIndex, position, rotation, quadSize, true, 0);

            float slowdownFactor = 3.5f;
            moveSpeed -= moveSpeed * slowdownFactor * Time.deltaTime;
        }

        public bool StoppedMoving()
        {
            return moveSpeed < .01;
        }
    }
}
