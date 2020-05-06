using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using Cinemachine;
using CodeMonkey.Utils;

public class ShootEffect : MonoBehaviour
{
    [SerializeField] private Shoot playerShoot;
    [SerializeField] private Material weaponTracerMaterial;
    private ParticleSystem ps;

    public enum TraceOption
    {
        Mesh, Particles
    }
    public TraceOption traceOption;

    private CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Start()
    {
        playerShoot.OnShoot += Player_OnShoot;
    }

    private void Player_OnShoot(object sender, Shoot.OnShootEventArgs e)
    {
        impulseSource.GenerateImpulse();

        //mesh or vfx
        if (traceOption == 0)
        {
            Vector2 shootDirection = (e.shootPosition - e.gunEndPointPosition).normalized;
            BulletRaycast.ShootRay(e.gunEndPointPosition, shootDirection);

            WeaponTracer(e.gunEndPointPosition, BulletRaycast.rayEndPoint);

            // Debug.DrawLine(e.gunEndPointPosition, BulletRaycast.rayEndPoint, Color.white, 1);
        }
        else
        {
            playerShoot.bulletFX.Emit(1);

            //colision rendering workaround problem
            var psCollision = playerShoot.bulletFX.collision;
            psCollision.enabled = true;
        }
    }

    private void WeaponTracer(Vector3 fromPosition, Vector3 targetPosition)
    {
        float distanceOffset = 0.3f;

        Vector3 dir = (targetPosition - fromPosition).normalized;

        float eulerZ = Utilities.GetAngleFromVectorFloat(dir) - 90f;
        float distance = Vector3.Distance(fromPosition, targetPosition);
        distance = distance + distanceOffset;
        Vector3 tracerSpawnPosition = fromPosition + dir * distance * 0.5f;

        Material tmpWeaponTracerMaterial = new Material(weaponTracerMaterial);
        tmpWeaponTracerMaterial.SetTextureScale("_MainTex", new Vector2(1f, (distance / 190f)));

        World_Mesh worldMesh = World_Mesh.Create(tracerSpawnPosition, eulerZ, .2f, distance, weaponTracerMaterial, null, 10000);

        float timer = 0.1f;
        FunctionUpdater.Create(() =>
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                worldMesh.DestroySelf();
                return true;
            }
            return false;
        });
    }
}


