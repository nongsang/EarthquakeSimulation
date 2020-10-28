using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEvent : MonoBehaviour
{
    //public GameObject Player;
    //SpriteRenderer Finish1;
    //SpriteRenderer Finish2;

    //public GameObject Save;

    //public GameObject Desk;
    //public GameObject Gas;
    //public GameObject Fuse;
    //public GameObject Save0;
    //public GameObject Save1;
    //public GameObject Save2;

    //bool isFinish = false;
    //float fade = 0.0f;

    //private void Start()
    //{
    //	Finish1 = GameObject.Find("GoBlack1").GetComponent<SpriteRenderer>();
    //	Finish2 = GameObject.Find("GoBlack2").GetComponent<SpriteRenderer>(); ;
    //}

    //private void Update()
    //{
    //	Save = GameObject.Find("Save");
    //	if (isFinish)
    //		finish();
    //}

    //void finish()
    //{
    //	//fade += 0.5f * Time.deltaTime;
    //	//Finish1.color = new Color(0, 0, 0, fade);
    //	//Finish2.color = new Color(0, 0, 0, fade);
    //	//Invoke("quit", 4.0f);
    //}

    //private void quit()
    //{
    //	Application.Quit();
    //	//Debug.Log("꺼짐");
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //	if (other.tag == "Player")
    //	{
    //		Debug.Log("끝");
    //		Player.GetComponent<CharacterController>().enabled = false;
    //		isFinish = true;
    //		StartCoroutine(Show());
    //	}
    //}

    //IEnumerator Show()
    //{
    //	//yield return new WaitForSeconds(2.0f);
    //	//Desk.SetActive(true);
    //	//yield return new WaitForSeconds(0.5f);
    //	//Fuse.SetActive(true);
    //	//yield return new WaitForSeconds(0.5f);
    //	//Gas.SetActive(true);
    //	//yield return new WaitForSeconds(0.5f);
    //	//if (Save.GetComponent<Save>().SaveNPC1 == false && Save.GetComponent<Save>().SaveNPC2 == false)
    //	//	Save0.SetActive(true);
    //	//else if (Save.GetComponent<Save>().SaveNPC1 == true && Save.GetComponent<Save>().SaveNPC2 == true)
    //	//	Save2.SetActive(true);
    //	//else
    //	//	Save1.SetActive(true);
    //	yield return new WaitForSeconds(3.0f);
    //	Application.Quit();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("끝");

            StartCoroutine(FadeOutAndEnding());
        }
    }

    private IEnumerator FadeOutAndEnding()
    {
        UICtrl.UI.fadeInOutImage.gameObject.SetActive(true);

        while (UICtrl.UI.fadeInOutImage.color.a != 1.0f)
        {
            UICtrl.UI.FadeInOut(true, 1.0f * 0.015625f);

            yield return new WaitForSeconds(0.015625f);
        }

        UICtrl.UI.ShowArrivalMsg(true);
    }
}
