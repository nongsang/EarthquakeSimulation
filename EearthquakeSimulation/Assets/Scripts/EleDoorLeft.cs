using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleDoorLeft : MonoBehaviour {

    public float doorSpeed = 1.0f;
    int doorState = 0;
	//0일때는 문이 닫혀있음 1은 문이 열리는 중 2는 문이 열려있음 3은 문이 닫히는 중

	//왼쪽문이 닫혀있을 때의 X좌표는 -4.26 // -0.609
	//열려있을 때의 X좌표는 -5.82 // -0.8314

	// Use this for initialization
	//   void Start () {
	//       //Debug.Log(transform.position.x);
	//}

	private void Awake()
	{
		System.GC.Collect();
	}

	// Update is called once per frame
	void Update () {
		if(doorState == 1)
        {
            //transform.position += new Vector3(-1 * doorSpeed * Time.deltaTime, 0, 0);
            transform.Translate(Vector3.left * doorSpeed * Time.deltaTime);
            if(transform.position.x <= -5.81)
            {
                doorState++;

            }
            //Debug.Log(transform.position.x);
        }
	}

    public void setDoorState()
    {
        if(doorState == 0)
        {
            doorState++;

        }
    }
}
