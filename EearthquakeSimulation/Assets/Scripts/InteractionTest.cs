using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTest : MonoBehaviour {

    GameObject Interobj, textfobj, talkobj, textMessageobj;
    Image interimage;
    Text TextF, talkText, textMessage;
    bool npctalk;

    //NPC
    GameObject npcobj;

    int talkstate = 0;
    //현재 대화중인 문단을 뜻하며 대화하는 키 코드를 누를때마다 상승

	// Use this for initialization
	void Start () {
        Interobj = GameObject.Find("Interaction");
        interimage = Interobj.GetComponent<Image>();

        textfobj = GameObject.Find("TextF");
        TextF = textfobj.GetComponent<Text>();

        talkobj = GameObject.Find("TalkingText");
        talkText = talkobj.GetComponent<Text>();

        textMessageobj = GameObject.Find("TextMessage");
        textMessage = textMessageobj.GetComponent<Text>();

        npcobj = GameObject.Find("NPC");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            interimage.enabled = true;
            TextF.enabled = true;
            talkText.enabled = true;
            textMessage.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(npctalk == false)
            {
                npctalk = true;
            }
            if(npctalk == true)
            {
                switch (talkstate)
                {
                    case 0:
                        textMessage.text = "안녕하세요";
                        talkstate++;
                        break;
                    case 1:
                        textMessage.text = "ekdkdkdkdkdkdkdkdk";
                        talkstate++;
                        break;
                    case 2:
                        textMessage.text = "크어어어어";
                        talkstate++;
                        break;
                    case 3:
                        textMessage.text = "끄잉?";
                        talkstate++;
                        break;
                }
                
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interimage.enabled = false;
            TextF.enabled = false;
            talkText.enabled = false;
            npctalk = false;
            textMessage.text = "";
            textMessage.enabled = false;
            talkstate = 0;
        }
    }

    public bool getnpctalk()
    {
        return npctalk;
    }
}
