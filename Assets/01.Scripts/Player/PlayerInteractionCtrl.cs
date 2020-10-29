using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionCtrl : MonoBehaviour
{
    // 상호작용 가능한 물체를 가까이 보고 있는가?
    [SerializeField] private bool isLook = false;

    // 검출할 레이어의 문자열
    [SerializeField] private string LayerName = "Interactive";

    // 바라보는 물체 정보
    private RaycastHit objectInfo;

    // 바라보는 물체의 상호작용 정보
    private ObjectInteraction objectInteraction = null;

    void Update ()
	{
        if (objectInteraction)    // 어떤 물체를 가까이 보고 있을 때
        {
            if (isLook) // 상호작용 가능한 물체를 보고있을 때
            {
                if (Input.GetKeyDown(KeyCode.F))    // 상호작용키를 누르면
                {
                    objectInteraction.SetActive(true);
                }
            }
            else
            {
                isLook = !isLook ;
                objectInteraction.ShowInteractionMsg(isLook);
            }
        }
        else    // 어떤 물체도 가까이 보고 있지 않을 때
        {
            if (isLook)
            {
                isLook = !isLook;
                UICtrl.UI.ShowInteractionMsg(null, isLook);
            }
        }
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.forward * 3.0f, Color.green);

        // 상호작용 가능한 물체만 레이캐스트로 검출
        int _layerMask = 1 << LayerMask.NameToLayer(LayerName);
        if(Physics.Raycast(transform.position, transform.forward, out objectInfo, 3.0f, _layerMask))
        {
            objectInteraction = objectInfo.collider.GetComponent<ObjectInteraction>();
        }
        else
        {
            objectInteraction = null;
        }
    }
}
