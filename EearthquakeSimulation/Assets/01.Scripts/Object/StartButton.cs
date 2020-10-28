using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private ObjectInteraction objectInteraction = null;

	private void Start()
    {
        objectInteraction = GetComponent<ObjectInteraction>();
        StartCoroutine(StartCheck());
	}

    private IEnumerator StartCheck()
    {
        yield return new WaitUntil(() => objectInteraction.GetActive());

        GameManager.instance.isRun = true;

        GameObject _UI = transform.root.gameObject;
        _UI.SetActive(false);
    }
}
