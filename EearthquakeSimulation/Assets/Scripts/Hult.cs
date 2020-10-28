using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hult : MonoBehaviour {

	 public GameObject HPImage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter()
	{
		HPImage.SendMessage("Hurt", SendMessageOptions.DontRequireReceiver);
	}
}
