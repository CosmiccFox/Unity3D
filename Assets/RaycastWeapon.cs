using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : Weapon
{

    public float range = 100;
    public GameObject hitEffect;
    public GameObject bulletTrail;
    public LayerMask enemy;

    public override void LaunchProjectile()
    {
        base.LaunchProjectile();
        RaycastHit hit;

        GameObject trail = Instantiate(bulletTrail, bulletSpawn.position, Quaternion.identity);
        trail.transform.rotation = bulletSpawn.rotation;

        if (Physics.Raycast(bulletSpawn.position, bulletSpawn.forward, out hit, range))
        {
            Instantiate(hitEffect, hit.point, Quaternion.identity);
            float distance = Vector3.Distance(bulletSpawn.position, hit.point);
            trail.transform.localScale = new Vector3(1, 1, distance);

            if (Physics.Raycast(bulletSpawn.position, bulletSpawn.forward, range, enemy))
            {
                Destroy(hit.transform.gameObject, 2.0f);
               // GetComponent<EnemyControl>().KillEnemy();
            }
        }
        else
        {
            trail.transform.localScale = new Vector3(1, 1, range);
        }
    }

}
