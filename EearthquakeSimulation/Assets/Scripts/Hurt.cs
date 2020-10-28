using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{

	public GameObject HPImage;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		HPImage.SendMessage("Hurt", SendMessageOptions.DontRequireReceiver);
	}
}
