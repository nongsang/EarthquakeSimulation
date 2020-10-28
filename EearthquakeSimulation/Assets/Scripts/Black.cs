using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black : MonoBehaviour {

	public GameObject black;
	public GameObject Die;

	float fade = 0.0f;

	private void Start()
	{
		Invoke("ShowDie", 3.0f);
	}

	private void Update()
	{
		fade += Time.deltaTime * 0.5f;
		black.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, fade);

	}

	void ShowDie()
	{
		Die.SetActive(true);
	}
}
