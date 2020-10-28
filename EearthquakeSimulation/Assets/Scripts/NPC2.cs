using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC2 : MonoBehaviour
{
    enum State { Idle, Run };

    private NavMeshAgent nav;
    public Transform target;
    Animator ani;

    [SerializeField] private State state = State.Idle;

	void Start () {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        StartCoroutine(Action());
	}

    private IEnumerator Action()
    {
        while(true)
        {
            switch(state)
            {
                case State.Idle:
                    break;

                case State.Run:
                    ani.Play("standard_run");
                    nav.enabled = true;
                    nav.SetDestination(target.position);
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
