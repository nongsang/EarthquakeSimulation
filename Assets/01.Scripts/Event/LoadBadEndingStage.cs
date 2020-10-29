using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBadEndingStage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
		if (other.CompareTag("Player"))
		{
            if (GameManager.instance.isRun)
            {
                SceneManager.LoadScene("BadEnding");
            }
        }
    }
}
