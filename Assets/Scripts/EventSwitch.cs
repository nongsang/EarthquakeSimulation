using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSwitch : MonoBehaviour {

 //   //GameObject player;
 //   private GameObject Camera;
 //   //private GameObject[] Oj;
 //   bool breakerSwitch1;
 //   bool breakerSwitch2;
 //   bool breakerSwitch3;
 //   bool valve;

 //   private GameObject elevator;
 //   private GameObject Exit;
 //   private GameObject Player;
 //   private GameObject goblack;
	//public GameObject Damage;
	//public GameObject Dontblock;

	//public AudioClip eq;
	//private AudioSource source;

 //   private void Awake()
 //   {
	//	Camera = GameObject.Find("FirstPersonCharacter");
 //       elevator = GameObject.Find("ElevatorButton");
 //       Exit = GameObject.Find("ExitTarget");
 //       Player = GameObject.Find("FPSController");
 //       goblack = GameObject.Find("GoBlack");
 //   }

 //   // Use this for initialization
 //   void Start () {
	//	//Oj = GameObject.FindWithTag("Mug");
	//	//Oj = GameObject.FindGameObjectsWithTag("OBJECT");

	//	//Camera = GameObject.Find("FirstPersonCharacter");
	//	//elevator = GameObject.Find("ElevatorButton");
	//	source = GetComponent<AudioSource>();
 //   }
	
	//// Update is called once per frame
	//void Update () {
        
 //   }
 //   void OnTriggerEnter(Collider other)
 //   {
 //       if(other.tag == "Player" && (breakerSwitch1 & breakerSwitch2 & breakerSwitch3 & valve == true))
 //       {
 //           Camera.SendMessage("Switch",SendMessageOptions.DontRequireReceiver);
 //           elevator.SendMessage("Enable", SendMessageOptions.DontRequireReceiver);
 //           Exit.SendMessage("Switch", SendMessageOptions.DontRequireReceiver);
 //           Player.SendMessage("Switch", SendMessageOptions.DontRequireReceiver);
 //           goblack.SendMessage("Switch", SendMessageOptions.DontRequireReceiver);
	//		Damage.SendMessage("SwitchDamage", SendMessageOptions.DontRequireReceiver);
	//		Dontblock.GetComponent<BoxCollider>().enabled = true;

	//		//Oj.SendMessage("Switch", SendMessageOptions.DontRequireReceiver);
	//		//foreach (GameObject o in Oj)
	//		//{
	//		//    o.SendMessage("Switch", SendMessageOptions.DontRequireReceiver);
	//		//}
	//		breakerSwitch1 = false;
 //           breakerSwitch2 = false;
 //           breakerSwitch3 = false;
 //           valve = false;
	//		StartCoroutine(dontblock());
 //       }
 //   }

 //   //bool AllTrue(bool breaker1, bool breaker2, bool breaker3, bool valve)
 //   //{
 //   //    if (breaker1 & breaker2 & breaker3 & valve == true)
 //   //        return true;
 //   //}

	//IEnumerator dontblock()
	//{
	//	//yield return new WaitForSeconds(0.5f);
	//	source.PlayOneShot(eq, 1.0f);
	//	yield return new WaitForSeconds(5.0f);
	//	Dontblock.GetComponent<BoxCollider>().enabled = false;
	//}

 //   public void SetBreakerSwitch1()
 //   {
 //       breakerSwitch1 = true;
 //   }
 //   public void SetBreakerSwitch2()
 //   {
 //       breakerSwitch2 = true;
 //   }
 //   public void SetBreakerSwitch3()
 //   {
 //       breakerSwitch3 = true;
 //   }
 //   public void SetValve()
 //   {
 //       valve = true;
 //   }
}
