using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartitionCtrl : MonoBehaviour {

    Rigidbody partition;

    private void Awake()
    {
		System.GC.Collect();
		partition = GetComponent<Rigidbody>();
    }

    // Use this for initialization
 //   void Start () {

	//}
	
	//// Update is called once per frame
	//void Update () {

	//}

    void Earthquake()
    {
        partition.isKinematic = false;
    }
}
