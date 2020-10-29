using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBoxCover : MonoBehaviour
{
    private Transform tr = null;
    private ObjectInteraction objectInteraction = null;
    [SerializeField] private float rotationSpeed = 100.0f;

    private void Start()
    {
        tr = GetComponent<Transform>();
        objectInteraction = GetComponent<ObjectInteraction>();

        StartCoroutine(Open());
    }

    private IEnumerator Open()
    {
        yield return new WaitUntil(() => objectInteraction.GetActive());

        while (true)
        {
            tr.rotation *= Quaternion.Euler(Vector3.down * rotationSpeed * 0.015625f);

            if (tr.localEulerAngles.y <= 200.0f) break;

            yield return new WaitForSeconds(0.015625f);
        }
    }
}
