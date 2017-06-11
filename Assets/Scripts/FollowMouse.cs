using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour
{
    float distance = 15.0f;

    void Update()
    {
        Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 pos = mouse.GetPoint(distance);
        this.transform.position = pos;
    }
}