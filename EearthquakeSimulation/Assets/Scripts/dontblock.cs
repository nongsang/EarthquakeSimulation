using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontblock : MonoBehaviour {

	SphereCollider sc;

	// Use this for initialization
	void Start () {
		sc = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		//sc.enabled = false;
	}
}
