using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideEarthquakeEvent : MonoBehaviour
{
	private AudioSource audioSource = null;

	[SerializeField] private AudioClip earthquakeInsideAudioClip = null;
	[SerializeField] private AudioClip earthquakeOutsideAudioClip = null;

	[SerializeField] private GameObject Player = null;
	[SerializeField] private GameObject[] People = null;
	[SerializeField] private GameObject[] Patrollers = null;

	[SerializeField] private float Damage = 15.0f;
	[SerializeField] private float Power = 500.0f;
	[SerializeField] private float Delay = 3.0f;
	[SerializeField] private float repeatSecond = 0.5f;

	public delegate void AddForceHandler(float power);
	public static event AddForceHandler AddForceEvent;

	private void Start()
    {
		audioSource = GetComponent<AudioSource>();
		People = GameObject.FindGameObjectsWithTag("NPC2");
		Patrollers = GameObject.FindGameObjectsWithTag("NPC1");

		StartCoroutine(Earthquake(Power));
		StartCoroutine(End());
	}

	private void OnDisable()
    {
		StopCoroutine(Earthquake(Power));
    }

	private IEnumerator Earthquake(float power)
	{
		// 게임 시작을 기다렸다가
		yield return new WaitUntil(() => GameManager.instance.isRun);

		// 게임이 시작되면 Delay만큼 기다리고
		yield return new WaitForSeconds(Delay);

		audioSource.PlayOneShot(earthquakeInsideAudioClip);
		audioSource.PlayOneShot(earthquakeOutsideAudioClip);

		Camera.main.GetComponent<CameraShake>().SetTimeAndAmount(earthquakeInsideAudioClip.length);

        foreach (var elem in People)
        {
			elem.GetComponent<NPC2>().Switch();
        }
        foreach (var elem in Patrollers)
        {
            elem.GetComponent<NPC1>().Switch();
        }

        while (true)
		{
			AddForceEvent(power);

			if (!Player.GetComponent<PlayerCtrl>().isSafe)
			{
				Player.GetComponent<PlayerCtrl>().OnDamage(Damage);
			}

			yield return new WaitForSeconds(repeatSecond);
		}
	}

	private IEnumerator End()
    {
		yield return new WaitUntil(() => GameManager.instance.isRun);

		yield return new WaitForSeconds(Delay + earthquakeInsideAudioClip.length);

		gameObject.SetActive(false);
	}
}
