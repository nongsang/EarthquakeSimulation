using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : MonoBehaviour
{
	private ObjectInteraction objectInteraction = null;
	[SerializeField] private Texture UIImage = null;

	private void Start()
    {
        objectInteraction = GetComponent<ObjectInteraction>();

		StartCoroutine(Take());
    }

	private IEnumerator Take()
    {
		yield return new WaitUntil(() => objectInteraction.GetActive());

		UICtrl.UI.ShowSlotItem(UIImage, true);

		gameObject.SetActive(false);
    }

	//[SerializeField] private bool isActive = false;

	//private void OnEnable()
 //   {
	//	GameManager.OnObjectActive += Active;
	//}

	//private void OnDisable()
 //   {
	//	GameManager.OnObjectActive -= Active;
	//}

	//private void Active()
 //   {
	//	isActive = true;
 //   }
}
