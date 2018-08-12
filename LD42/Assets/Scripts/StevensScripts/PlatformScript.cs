using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public GameObject Destroyed_Version;
    public float timer;


	public void OnCollisionEnter(Collision col)
	{
        if(col.gameObject.tag == "player")
        {
            Debug.Log("About to explode");
            StartCoroutine(FallApart());
        }
	}

    IEnumerator FallApart()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
        Instantiate(Destroyed_Version, transform.position, transform.rotation);
    }
}
