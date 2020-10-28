using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC1 : MonoBehaviour
{
    enum State { Patrol, Run };

    [SerializeField] private Transform target1, target2, target3;
    private NavMeshAgent nav;
    private Animator ani;

    [SerializeField] private State state = State.Patrol;

	void Start () {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(target1.position);
        ani = GetComponent<Animator>();

        StartCoroutine(Action());
	}
	
    private IEnumerator Action()
    {
        while(true)
        {
            switch(state)
            {
                case State.Patrol:
                    if ((transform.position.x == target1.position.x) && (transform.position.z == target1.position.z))
                    {
                        nav.SetDestination(target2.position);
                    }
                    else if((transform.position.x == target2.position.x) && (transform.position.z == target2.position.z))
                    {
                        nav.SetDestination(target1.position);
                    }

                    break;
                case State.Run:
                    ani.Play("standard_run");
                    nav.SetDestination(target3.position);
                    nav.speed = 5;
                    break;
                default:
                    break;
            }

            yield return new WaitForSeconds(0.125f);
        }
    }

    public GameObject getGameObject()
    {
        return gameObject;
    }

	public void Switch()
	{
		state = State.Run;
	}
}
