using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonDown : MonoBehaviour {

    MeshRenderer mr;

	private void Awake()
	{
		System.GC.Collect();
	}

	// Use this for initialization
	void Start () {
        mr = GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	//void Update () {
		
	//}

    public void setOnMeshRender()
    {
        mr.enabled = true;
        transform.position = new Vector3(-5.293f, 2.167f, -12.444f);
    }
}
