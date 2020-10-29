using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGwangHwaMoonStage : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			SceneManager.LoadScene("GwangHwaMoon");
		}
		else
		{
			other.gameObject.SetActive(false);
		}
	}
}
