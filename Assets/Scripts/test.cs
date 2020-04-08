using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using Cinemachine;
using CodeMonkey.Utils;

public class test : MonoBehaviour
{
    // public CinemachineImpulseSource impulseSource;
    [SerializeField] private Shoot playerShoot;
    [SerializeField] private Material weaponTracerMaterial;


    public enum TraceHandle
    {
        Mesh, particles
    }
    public TraceHandle traceHandle;

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
        // Debug.DrawLine(e.gunEndPointPosition, e.shootPosition, Color.white, .1f);

        if (traceHandle == 0)
        {
            WeaponTracer(e.gunEndPointPosition, e.shootPosition);
        }
        else
        {
            playerShoot.bulletFX.Emit(1);
        }
    }

    private void WeaponTracer(Vector3 fromPosition, Vector3 targetPosition)
    {
        Vector3 dir = (targetPosition - fromPosition).normalized;

        float eulerZ = Utilities.GetAngleFromVectorFloat(dir) - 90f;
        float distance = Vector3.Distance(fromPosition, targetPosition);
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


