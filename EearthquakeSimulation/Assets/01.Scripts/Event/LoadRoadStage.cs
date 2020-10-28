using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRoadStage : MonoBehaviour
{
	[SerializeField] private GameObject Player = null;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (GameManager.instance.isRun)
			{
				GameManager.instance.SaveHP(Player.GetComponent<PlayerCtrl>().currHP);
				GameManager.instance.SaveItem();

				SceneManager.LoadScene("Road");
			}
		}
		else
        {
			other.gameObject.SetActive(false);
        }
	}
}