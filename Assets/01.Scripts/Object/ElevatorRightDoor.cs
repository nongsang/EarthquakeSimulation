using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorRightDoor : MonoBehaviour
{
	private Transform tr = null;
	[SerializeField] private GameObject elevatorButton = null;
	[SerializeField] private float Speed = 1.0f;

	private void Start()
	{
		tr = GetComponent<Transform>();
		StartCoroutine(Open());
	}

	private IEnumerator Open()
	{
		yield return new WaitUntil(() => elevatorButton.GetComponent<ObjectInteraction>().GetActive());

		while (true)
		{
			tr.Translate(transform.right * Speed * 0.015625f);

			if (tr.position.x >= -1.4f) break;

			yield return new WaitForSeconds(0.015625f);
		}
	}
}