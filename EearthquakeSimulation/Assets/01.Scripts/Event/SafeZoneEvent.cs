using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneEvent : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
        {
			other.GetComponent<PlayerCtrl>().isSafe = true;
        }
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
        {
			other.GetComponent<PlayerCtrl>().isSafe = false;
		}
	}
}
