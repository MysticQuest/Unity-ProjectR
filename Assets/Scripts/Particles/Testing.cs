using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    [SerializeField] private Shoot playerShoot;

    private void Start()
    {
        playerShoot.OnShoot += PlayerShoot_OnShoot;
    }

    private void PlayerShoot_OnShoot(object sender, Shoot.OnShootEventArgs e)
    {
        Vector3 quadPosition = e.gunEndPointPosition;
        // Vector3 quadSize = new Vector3(.1f, .2f);
        // float rotation = 0f;

        Vector3 shootDir = (e.shootPosition - e.gunEndPointPosition).normalized;
        quadPosition += shootDir * -.2f + Vector3.up * 0.1f;
        Vector3 shellMoveDir = Quaternion.Euler(0, 0, Random.Range(95f, 125f)) * shootDir;
        // Vector3 shellMoveDir = Quaternion.AngleAxis(Random.Range(95f, 125f), Vector3.up) * shootDir;

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
