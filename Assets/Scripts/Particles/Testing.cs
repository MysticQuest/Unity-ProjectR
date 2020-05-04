using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    [SerializeField] private Shoot playerShoot;
    [SerializeField] private AnimationControl animControl;
    [SerializeField] private MoveVelocity moveVelocity;

    private float nextSpawnDirtTime;

    private void Start()
    {
        if (!animControl)
        {
            animControl = GameObject.Find("Player").GetComponent<AnimationControl>();
        }

        if (!moveVelocity)
        {
            moveVelocity = GameObject.Find("Player").GetComponent<MoveVelocity>();
        }

        if (!playerShoot)
        {
            playerShoot = GameObject.Find("Player").GetComponent<Shoot>();
        }

        playerShoot.OnShoot += PlayerShoot_OnShoot;
    }

    private void Update()
    {
        DirtParticlesSpawnDelay();
    }

    private void DirtParticlesSpawnDelay()
    {
        if (Time.time >= nextSpawnDirtTime)
        {
            if (animControl.isMoving)
            {
                //increase size on vertical movement to improve the effect
                DirtParticleSystemHandler.Instance.SpawnDirt(moveVelocity.GetPosition() + new Vector3(0, -.5f), moveVelocity.GetDirection() * -1f);
                nextSpawnDirtTime = Time.time + .05f;
            }
        }
    }

    private void PlayerShoot_OnShoot(object sender, Shoot.OnShootEventArgs e)
    {
        Vector3 quadPosition = e.gunEndPointPosition;

        Vector3 shootDir = (e.shootPosition - e.gunEndPointPosition).normalized;
        quadPosition += shootDir * -.2f + Vector3.up * 0.1f;

        float shellRotation = Random.Range(75f, 125f);
        if (shootDir.x < 0)
        {
            shellRotation *= -1;
        }

        Vector3 shellMoveDir = Quaternion.Euler(0, 0, shellRotation) * shootDir;

        ShellParticleSystemHandler.Instance.SpawnShell(quadPosition, shellMoveDir);

        // int uvIndex = UnityEngine.Random.Range(0, 8);
        // int spawnedQuadIndex = AddQuad(quadPosition, rotation, quadSize, true, uvIndex);

        // FunctionUpdater.Create(() =>
        // {
        //     quadPosition += new Vector3(1, 1) * Time.deltaTime;
        //     // quadSize += new Vector3(1, 1) * Time.deltaTime;
        //     // rotation += 360f * Time.deltaTime;
        //     UpdateQuad(spawnedQuadIndex, quadPosition, rotation, quadSize, true, uvIndex);
        // });
    }
}
