using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour {

	[SerializeField] private GameObject Exp = null;
	[SerializeField] private GameObject Smoke = null;
	[SerializeField] private GameObject Fire = null;

	[SerializeField] private GameObject[] NPCs = null;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("NPC1"))
		{
			foreach(var elem in NPCs)
            {
				elem.GetComponent<RunNPC1>().SetHit();
            }

			Exp.SetActive(true);

			Camera.main.GetComponent<CameraShake>().SetTimeAndAmount(0.5f);

			Destroy(Exp, 5.0f);
			Smoke.SetActive(false);
			Fire.SetActive(true);

			Destroy(gameObject, 2.0f);
			
			InvokeRepeating("FireParticleIncrease", 1.0f, 0.1f);
		}
	}

	private void FireParticleIncrease()
	{
		Fire.GetComponent<ParticleSystem>().maxParticles += 3;
	}
}
