using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEndElevatorRightDoor : MonoBehaviour
{
	private Transform tr = null;
	[SerializeField] private float Speed = 1.0f;

	private void Start()
	{
		tr = GetComponent<Transform>();
		StartCoroutine(Close());
	}

	private IEnumerator Close()
	{
		while (true)
		{
			tr.Translate(-transform.right * Speed * 0.015625f);

			if (tr.position.x <= -2.8f) break;

			yield return new WaitForSeconds(0.015625f);
		}
	}
}
