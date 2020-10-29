using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour
{
	public static UICtrl UI = null;

	[SerializeField] private GameObject Player = null;
	[SerializeField] private Image HPImage = null;
	[SerializeField] private GameObject InteractionPenal = null;
	public RawImage[] itemImage = null;
	[SerializeField] private RawImage bloodyScreenImage = null;
	public RawImage fadeInOutImage = null;
    [SerializeField] private RawImage dieMsgImage = null;
	[SerializeField] private RawImage ArrivalMsgImage = null;

	private void Awake()
    {
		if(UI == null)
        {
			UI = this;
        }
		else if(UI != this)
        {
			Destroy(gameObject);
		}
	}

	private void Start()
    {
		HPImage.fillAmount = GameManager.instance.saveCurrHP / GameManager.instance.saveMaxHP;
		ShowItem();

		InteractionPenal.SetActive(false);

		StartCoroutine(HPCheck());
	}

	private IEnumerator HPCheck()
    {
		while(true)
        {
			HPImage.fillAmount = Player.GetComponent<PlayerCtrl>().currHP / Player.GetComponent<PlayerCtrl>().maxHP;

			yield return new WaitForSeconds(0.125f);
        }
    }

	public void ShowInteractionMsg(string Msg, bool isShow)
    {
		InteractionPenal.transform.FindChild("InteractionMsg").GetComponent<Text>().text = Msg;
		InteractionPenal.SetActive(isShow);
	}

	public void ShowSlotItem(Texture UIImage, bool isShow)
    {
		foreach(var elem in itemImage)
        {
			if (!elem.IsActive())
            {
				elem.texture = UIImage;
				elem.enabled = isShow;

				break;
            }
        }
    }

	public void FadeInOut(bool black, float t)
    {
		if(black)
        {
			fadeInOutImage.color = new Color(0.0f, 0.0f, 0.0f, fadeInOutImage.color.a + t);
        }
		else
        {
			fadeInOutImage.color = new Color(0.0f, 0.0f, 0.0f, fadeInOutImage.color.a - t);
		}
    }

	public void ShowDieMsg(bool value)
    {
		dieMsgImage.gameObject.SetActive(value);
	}

	public void ShowArrivalMsg(bool value)
    {
		ArrivalMsgImage.gameObject.SetActive(value);
	}

	private void ShowItem()
    {
		for(int i = 0; i < GameManager.instance.saveItemCnt; i++)
        {
			itemImage[i].texture = GameManager.instance.firstAidImage;
			itemImage[i].enabled = true;
		}
    }
}