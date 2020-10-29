using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	// 싱글턴
	public static GameManager instance = null;

	public bool isRun = false;

	// 저장된 최대 HP
	public float saveMaxHP = 100.0f;
	// 저장된 현재 HP
	public float saveCurrHP;
    // 확보한 아이템 갯수
    public int saveItemCnt = 0;
    // 구한 NPC 수
    public int saveNPCCnt = 0;

    public Texture firstAidImage = null;

    public delegate void ObjectActiveHandler();
	public static event ObjectActiveHandler OnObjectActive;

	private void Awake()
	{
		if(instance == null)
        {
			instance = this;
		}
		else if(instance != this)
        {
			Destroy(gameObject);
        }

		saveCurrHP = saveMaxHP;

		DontDestroyOnLoad(gameObject);
	}

	private void OnEnable()
    {
		StartCoroutine(RunCheck());
	}

	private IEnumerator RunCheck()
    {
		yield return new WaitUntil(() => isRun);

		OnObjectActive();
    }

    public void SaveHP(float HP)
    {
        saveCurrHP = HP;
    }

    public void SaveItem()
    {
        foreach(var elem in UICtrl.UI.itemImage)
        {
            if(elem.IsActive())
            {
                ++saveItemCnt;
            }
        }
    }

    //IEnumerator Init()
    //{
    //	while (true)
    //	{
    //		yield return new WaitForSeconds(0.2f);
    //		FirstAid1 = GameObject.Find("FirstAid1");
    //		FirstAid2 = GameObject.Find("FirstAid2");
    //		hp = GameObject.Find("HPImage");

    //		if (SaveFirstAid1 == true)
    //			FirstAid1.GetComponent<SpriteRenderer>().enabled = true;
    //		if (SaveFirstAid2 == true)
    //			FirstAid2.GetComponent<SpriteRenderer>().enabled = true;
    //		//Savehp = HP;
    //	}
    //}

    //public void SaveHP(float currHP, float maxHP)
    //{
    //    saveMaxHP = maxHP;
    //    saveCurrHP = currHP;
    //}

    //public void SaveItem()
    //   {

    //   }
}
