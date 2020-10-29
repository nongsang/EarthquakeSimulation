using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPipe : MonoBehaviour {

    bool setValveRotation;
    public float rotationSpeed = 200.0f;
    GameObject ES;

	private void Awake()
	{
		System.GC.Collect();
	}

	// Use this for initialization
	void Start () {
        ES = GameObject.Find("EventSwitch");
	}
	
	// Update is called once per frame
	void Update () {
        if (setValveRotation)
        {
            transform.rotation *= Quaternion.Euler(Vector3.forward * rotationSpeed * Time.deltaTime);
            if(transform.rotation.z >= 0.6)
            {
                setValveRotation = false;
            }
            ES.SendMessage("SetValve", SendMessageOptions.DontRequireReceiver);
        }
	}

    void setValveRotate()
    {
        setValveRotation = true;
    }
}
