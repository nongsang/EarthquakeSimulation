using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCameraCtrl : MonoBehaviour
{
    private Transform tr = null;
    private PlayerInteractionCtrl playerInteractionCtrl = null;
    
    [SerializeField] private float rotateY = 0.0f;
    [SerializeField] private float rotateX = 0.0f;

    private void OnEnable()
    {
        System.GC.Collect();
    }

    private void Start()
    {
        tr = GetComponent<Transform>();
        playerInteractionCtrl = GetComponent<PlayerInteractionCtrl>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // 회전
        rotateY += Input.GetAxis("Mouse X");
        rotateX -= Input.GetAxis("Mouse Y");

        rotateX = Mathf.Clamp(rotateX, -90.0f, 90.0f);
    }

    private void LateUpdate()
    {
        tr.rotation = Quaternion.Euler(rotateX, rotateY, 0.0f);
    }
}
