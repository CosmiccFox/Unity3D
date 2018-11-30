using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.gameObject.GetComponent<EnemyControl>() != null)
        {
            //Instantiate(hitEffect);
            collision.rigidbody.gameObject.GetComponent<EnemyControl>().KillEnemy();
        }

        Destroy(gameObject);
    }
}
