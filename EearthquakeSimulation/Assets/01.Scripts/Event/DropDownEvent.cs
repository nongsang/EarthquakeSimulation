using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownEvent : MonoBehaviour {

	public GameObject invisableWall;
	public GameObject[] Fires;
	public GameObject[] Exp;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			invisableWall.SetActive(true);

			Camera.main.GetComponent<CameraShake>().SetTimeAndAmount(0.5f);

			foreach (GameObject fire in Fires)
			{
				fire.SetActive(true);
			}
			foreach (GameObject exp in Exp)
			{
				exp.SetActive(true);
			}
		}
	}
}
