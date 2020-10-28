using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBreaker : MonoBehaviour
{
    private Transform tr = null;
    private ObjectInteraction objectInteraction = null;
    [SerializeField] private bool setRotate = false;
    [SerializeField] private float rotationSpeed = 1.0f;

    private void Start()
    {
        tr = GetComponent<Transform>();
        objectInteraction = GetComponent<ObjectInteraction>();
        StartCoroutine(Break());
    }

    private IEnumerator Break()
    {
        yield return new WaitUntil(() => objectInteraction.GetActive());

        setRotate = true;

        while (setRotate)
        {
            tr.rotation *= Quaternion.Euler(Vector3.up * rotationSpeed * 0.015625f);

            if (tr.localEulerAngles.y >= 350.0f)
            {
                setRotate = false;
            }

            yield return new WaitForSeconds(0.015625f);
        }
    }
}
