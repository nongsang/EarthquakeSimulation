using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakerSwitch : MonoBehaviour {

    bool setRotation;

	private void Awake()
	{
		System.GC.Collect();
	}

	// Use this for initialization
	//void Start()
	//{
	//	Debug.Log(transform.rotation.z);
	//}

	// Update is called once per frame
	void Update () {
        if (setRotation)
        {
            transform.rotation *= Quaternion.Euler(Vector3.back * 200.0f * Time.deltaTime);
            //Debug.Log(transform.rotation.z);
            if (transform.rotation.z <= -0.5)
                setRotation = false;
        }
	}

    private void OnMouseDown()
    {
        setRotation = true;
    }
}
