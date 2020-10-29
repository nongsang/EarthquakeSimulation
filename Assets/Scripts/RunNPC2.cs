using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunNPC2 : MonoBehaviour {

	public enum NPCState { Run, Hit };

	public NPCState npcstate = NPCState.Run;

	private NavMeshAgent nvAgent;
	private Animator animator;
	//private bool isDie = false;

	public GameObject Destination;

	private void Awake()
	{
		nvAgent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}

	private void Start()
	{
		StartCoroutine(NPCAction());
	}
	
	IEnumerator NPCAction()
	{
		while (true)
		{
			switch (npcstate)
			{
				case NPCState.Run:
					nvAgent.isStopped = false;
					nvAgent.destination = Destination.transform.position;
					animator.SetBool("isRun", true);
					break;
				case NPCState.Hit:
					nvAgent.isStopped = true;
					animator.SetBool("isRun", false);
					break;
			}
			yield return null;
		}
	}

	public void SetRun()
	{
		npcstate = NPCState.Run;
	}

	public void SetHit()
	{
		npcstate = NPCState.Hit;
	}
}