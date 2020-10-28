using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunNPC1 : MonoBehaviour {

	public enum State { Run, Hurt };

	[SerializeField] private State state = State.Run;

	private NavMeshAgent nvAgent;
	private Animator animator;
	[SerializeField]  private bool isDie = false;

	[SerializeField] private GameObject Destination;

	private ObjectInteraction objectInteraction = null;

	private void Awake()
	{
		nvAgent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();

		objectInteraction = GetComponent<ObjectInteraction>();
	}

	private void Start()
	{
		StartCoroutine(NPCAction());
		StartCoroutine(SetRun());
	}
	
	IEnumerator NPCAction()
	{
		while (true)
		{
			switch (state)
			{
				case State.Run:
					nvAgent.isStopped = false;
					nvAgent.destination = Destination.transform.position;
					animator.SetBool("isRun", true);
					break;
				case State.Hurt:
					nvAgent.isStopped = true;
					animator.SetBool("isRun", false);
					break;
			}
			yield return new WaitForSeconds(0.125f);
		}
	}

	private IEnumerator SetRun()
	{
		yield return new WaitUntil(() => objectInteraction.GetActive());

		foreach(var elem in UICtrl.UI.itemImage)
        {
			if(elem.enabled)
            {
				state = State.Run;
				elem.enabled = false;
				--GameManager.instance.saveItemCnt;

				break;
			}
        }
	}

	public void SetHit()
	{
		state = State.Hurt;
	}
}