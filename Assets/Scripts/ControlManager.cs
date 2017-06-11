using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    RaycastHit hit;

    void Start()
    {

    }

    void Update()
    {
        Drag();
    }

    void Drag()
    {
        Debug.DrawRay(transform.position, this.transform.right * (-100), Color.green);
        if (Physics.Raycast(this.transform.position, this.transform.right * (-100), out hit, Mathf.Infinity))
        {
            //추후 IDragable을 상속받는 것만 인식하게 바꾸기
            if (hit.collider.gameObject.name == "Cube")
                Debug.Log("Hit");

            Vector3 toPos = transform.position;
            toPos.x = hit.transform.position.x;
            hit.transform.position = toPos;
        }
    }
}
