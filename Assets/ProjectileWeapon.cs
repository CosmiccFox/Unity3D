using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    public float range = 100;
    public GameObject projectile;
    public GameObject hitEffect;

    public override void LaunchProjectile()
    {
        base.LaunchProjectile();

        GameObject spawnProjectile = Instantiate(projectile, bulletSpawn.position, Quaternion.identity);
        spawnProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 30, ForceMode.Impulse);

    }
}
