using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStart : MonoBehaviour {

	GameObject Camera;
	GameObject NPC1;
	GameObject[] NPC2;
	BoxCollider bc;
	private GameObject HUD;

	public AudioClip eq;
	private AudioSource source;

	private void Awake()
    {
		bc = GetComponent<BoxCollider>();
        Camera = GameObject.Find("FirstPersonCharacter");
		//Camera = GameObject.Find("Main Camera");
		NPC1 = GameObject.FindGameObjectWithTag("NPC1");
        NPC2 = GameObject.FindGameObjectsWithTag("NPC2");
		HUD = GameObject.Find("HPImage");
	}

    // Use this for initialization
    void Start () {
		//tr = GetComponent<BoxCollider>();
		//Camera = GameObject.Find("FirstPersonCharacter");
		//NPC1 = GameObject.FindGameObjectWithTag("NPC1");
		//NPC2 = GameObject.FindGameObjectsWithTag("NPC2");
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//bc.enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			bc.enabled = false;
			StartCoroutine(EStart());
		}
	}

	IEnumerator EStart()
	{
		HUD.SendMessage("OnDamage", SendMessageOptions.DontRequireReceiver);
		yield return new WaitForSeconds(10.0f);
		source.PlayOneShot(eq, 1.0f);
		Camera.SendMessage("EStart", SendMessageOptions.DontRequireReceiver);
		yield return new WaitForSeconds(1.0f);
		NPC1.SendMessage("Switch", SendMessageOptions.DontRequireReceiver);
		foreach (GameObject npc2 in NPC2)
			npc2.SendMessage("Switch", SendMessageOptions.DontRequireReceiver);
	}

    void Switch()
    {
        bc.enabled = true;
    }
}
