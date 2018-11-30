using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour {

    public float destroyTime = 1;


	// Use this for initialization
	void Start ()
    {
        StartCoroutine("DestroyObject");
	}


    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
