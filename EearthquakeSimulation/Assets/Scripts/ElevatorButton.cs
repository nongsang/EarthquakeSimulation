using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    private ObjectInteraction objectInteraction = null;

    public delegate void ElevatorDoorHandler();
    public static event ElevatorDoorHandler OnElevatorDoorOpen;

    private void Start()
    {
        objectInteraction = GetComponent<ObjectInteraction>();
    }

    private IEnumerator Open()
    {
        yield return new WaitUntil(() => objectInteraction.GetActive());

        OnElevatorDoorOpen();
    }
}
