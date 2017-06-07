using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMapping : MonoBehaviour
{
    public int fingerNum = 0;

    private Transform tf;
    private GlovInput.FingerState beforeState;

    void Start()
    {
        tf = GetComponent<Transform>();
        beforeState = GlovInput.FingerState.Straight;
    }

    void Update()
    {
        GlovInput.FingerState state = GlovInput.instance.GetOneFingerState(fingerNum);

        if(beforeState == state)
        {
            return;
        }

        beforeState = state;

        switch (state)
        {
            case GlovInput.FingerState.Straight:
                tf.Rotate(new Vector3(0, 0, -90));
                break;

            case GlovInput.FingerState.Fold:
                tf.Rotate(new Vector3(0, 0, 90));
                break;

            case GlovInput.FingerState.Bending:
                tf.Rotate(new Vector3(0, 0, 40));
                break;

            default:
                break;
        }
    }
}
