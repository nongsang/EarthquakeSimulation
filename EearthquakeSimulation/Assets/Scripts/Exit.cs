using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
	GameObject obj;
	bool enable = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("NPC1"))
		{
			obj = GameObject.FindWithTag("NPC1").GetComponent<NPC1>().getGameObject();
			Destroy(obj);
		}
		if (other.CompareTag("NPC2"))
		{
			obj = GameObject.FindWithTag("NPC2").GetComponent<NPC2>().getGameObject();
			Destroy(obj);
		}
	}

	void Switch()
	{
		enable = true;
	}
}