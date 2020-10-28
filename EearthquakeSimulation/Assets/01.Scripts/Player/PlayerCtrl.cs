using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private CharacterController cc = null;

    // 이동 입력
    [SerializeField] private float currMoveSpeed = 10.0f;
    [SerializeField] private Vector3 moveDir = Vector3.zero;

    // 마우스 입력
    [SerializeField] private float rotateY = 0.0f;

    // 체력
    public bool isDie = false;
    public float maxHP = 100.0f;
    public float currHP;

    public bool isSafe = false;
    [SerializeField] private bool isCrouch = false;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        currHP = GameManager.instance.saveCurrHP;
    }

    private void Update()
    {
        if (isDie) return;

        // 이동 입력
        moveDir = Input.GetAxisRaw("Vertical") * cc.transform.forward
                + Input.GetAxisRaw("Horizontal") * cc.transform.right;

        // 회전 입력
        rotateY += Input.GetAxis("Mouse X");

        // 앉기 입력
        if (!isSafe)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                isCrouch = !isCrouch;
            }
        }

        // 1, 2 누르면 아이템 사용 구현

        if (isCrouch)
        {
            transform.localScale = new Vector3(1.0f, 0.8f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.6f, 1.0f);
        }

        // 적용
        cc.SimpleMove(moveDir * currMoveSpeed);
        cc.transform.rotation = Quaternion.Euler(0.0f, rotateY, 0.0f);
    }

    // 물체 밀기
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody _rb = hit.collider.attachedRigidbody;

        if (_rb)
        {
            _rb.velocity += cc.velocity * 0.1f;
        }
    }

    public void OnDamage(float damage)
    {
        currHP = Mathf.Clamp(currHP - damage, 0.0f, maxHP);

        if(currHP <= 0.0f)
        {
            isDie = true;
        }
    }
}
