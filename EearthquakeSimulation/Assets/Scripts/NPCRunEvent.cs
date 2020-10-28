using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRunEvent : MonoBehaviour {

	public GameObject npc1;
	public GameObject npc2;
	public GameObject npc3;

	private void Start()
	{
		StartCoroutine(ActiveNPC());
	}

	IEnumerator ActiveNPC()
	{
		yield return new WaitForSeconds(5.0f);
		npc1.SetActive(true);
		yield return new WaitForSeconds(6.0f);
		npc3.SetActive(true);
		yield return new WaitForSeconds(3.0f);
		npc2.SetActive(true);
	}
}