using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float fireRate = 10;
    public int magSize = 10;
    public float reloadTime = 1;
    public Transform bulletSpawn;

    private bool firing = false;
    private bool reloading = false;
    private int bulletsRem;
    private float timer = 0;

	// Use this for initialization
	void Start ()
    {
        bulletsRem = magSize;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(firing)
        {
            if (timer <= 0 && !reloading)
            {
                if (bulletsRem > 0)
                {
                    LaunchProjectile();
                    timer = 1 / fireRate;
                }
                else
                {
                    Reload();
                }
            }

            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
	}

    public void Fire(bool toggle)
    {
        firing = toggle;
    }

    public virtual void LaunchProjectile()
    {
        bulletsRem--;
    }

    void Reload()
    {
        reloading = true;
        StartCoroutine("ReloadCoroutine");
    }

    IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);
        bulletsRem = magSize;
        reloading = false;
    }

}
