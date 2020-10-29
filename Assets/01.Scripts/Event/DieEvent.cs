using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DieEvent : MonoBehaviour
{
    private PlayerCtrl playerCtrl = null;

    private void Awake()
    {
        playerCtrl = GetComponent<PlayerCtrl>();
    }

    private void OnEnable()
    {
        StartCoroutine(FadeOutAndDie());
    }

    private IEnumerator FadeOutAndDie()
    {
        yield return new WaitUntil(() => playerCtrl.isDie);

        UICtrl.UI.fadeInOutImage.gameObject.SetActive(true);

        while (UICtrl.UI.fadeInOutImage.color.a != 1.0f)
        {
            UICtrl.UI.FadeInOut(true, 1.0f * 0.015625f);

            yield return new WaitForSeconds(0.015625f);
        }

        UICtrl.UI.ShowDieMsg(true);
    }
}