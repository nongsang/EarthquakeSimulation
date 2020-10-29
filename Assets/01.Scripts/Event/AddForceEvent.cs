using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceEvent : MonoBehaviour
{
    private Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        InsideEarthquakeEvent.AddForceEvent += RandomAddForce;
    }

    private void OnDisable()
    {
        InsideEarthquakeEvent.AddForceEvent -= RandomAddForce;
    }

    public void RandomAddForce(float power)
    {
        Vector3 _Dir = Random.insideUnitSphere * power;

        rb.AddForce(_Dir);
    }
}
