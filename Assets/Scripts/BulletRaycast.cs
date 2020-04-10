using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BulletRaycast
{
    public static Vector2 rayEndPoint;

    public static void ShootRay(Vector3 shootPosition, Vector3 shootDirection)
    {
        float distance = 10f;
        int layerMask = ~(LayerMask.GetMask("Player"));

        DoRaycast(shootPosition, shootDirection, distance, layerMask);
    }

    public static void DoRaycast(Vector3 shootPosition, Vector3 shootDirection, float distance, int layerMask)
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(shootPosition, shootDirection, distance, layerMask);

        rayEndPoint = shootPosition + shootDirection * distance;

        if (raycastHit2D.collider)
        {
            rayEndPoint = raycastHit2D.point;
            Target target = raycastHit2D.collider.GetComponent<Target>();
            if (target)
            {
                target.Damage();
            }
        }
    }
}

