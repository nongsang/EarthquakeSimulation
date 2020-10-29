using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDamage : MonoBehaviour {

	public Transform SpriHpbar;
	static float hp = 3.0f;
	bool isDamage = true;
	bool enable = false;
	public GameObject Die;
	public GameObject Save;

	bool isHurt = false;

	// Use this for initialization
	void Start () {
		//SpriHpbar.localScale = new Vector3(Save.GetComponent<Save>().Savehp, 2.5f, 1);
		Die = GameObject.Find("GoBlack");
		Save = GameObject.Find("Save");
		//SpriHpbar.localScale = new Vector3(Save.GetComponent<Save>().Savehp, 2.5f, 1);
		StartCoroutine(OnDamage());
	}
	
	// Update is called once per frame
	void Update () {
		//Save.SendMessage("SaveHP", hp,SendMessageOptions.DontRequireReceiver);
		if (SpriHpbar.localScale.x <= 0.3f)
		{
			SpriHpbar.localScale = new Vector3(0.0f, 2.5f, 1);
			//Debug.Log("바보");
			Die.SendMessage("Die", SendMessageOptions.DontRequireReceiver);
		}
	}

	IEnumerator OnDamage()
	{
		if (enable == false) yield return null;
		else
		{
			yield return new WaitForSeconds(10.0f);
			for (int i = 0; i < 20; ++i)
			{
				if (isDamage == false) yield return new WaitForSeconds(0.5f);
				else
				{
					yield return new WaitForSeconds(0.5f);
					SpriHpbar.localScale = new Vector3(hp -= 0.3f, 2.5f, 1);
				}
			}
		}
	}

	void Hurt()
	{
		SpriHpbar.localScale = new Vector3(hp -= 0.3f, 2.5f, 1);
	}

	private void Enable()
	{
		enable = true;
	}

	private void DamagedTrue()
	{
		isDamage = true;
	}

	private void DamagedFalse()
	{
		isDamage = false;
	}

	void SwitchDamage()
	{
		SpriHpbar.localScale = new Vector3(hp *= 0.5f, 2.5f, 1);
		//Save.GetComponent<Save>().Savehp = hp;
	}
}
