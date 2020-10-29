using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    private Transform camTransform;
    [SerializeField] private float shakeTime = 0.0f;

    [SerializeField] private float shakeAmount = 0.3f;

    private Vector3 originalPos;

    void Awake()
    {
        camTransform = GetComponent<Transform>();
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }
	
	void Update () {
		if (shakeTime > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeTime = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    public void SetTimeAndAmount(float time, float amount = 0.3f)
    {
        shakeTime = time;
        shakeAmount = amount;
    }
}
