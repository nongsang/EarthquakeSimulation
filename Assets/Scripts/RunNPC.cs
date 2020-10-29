using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunNPC : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Timer());
	}

	IEnumerator	Timer()
	{
		yield return new WaitForSeconds(5.0f);
		Destroy(gameObject);
	}
	
}
