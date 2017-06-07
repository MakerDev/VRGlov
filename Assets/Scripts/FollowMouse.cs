using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour
{
    float distance = 13.51f;

    private void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

        this.transform.position = objPos;
    }
}