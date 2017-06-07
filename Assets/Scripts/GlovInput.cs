using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO.Ports;

//Arduino와 통신하게 될 인터페이스 클래스
/*
 *통신방법 : 아두이노에서 접힌 손가락의 상태를 엄지(0번)부터 순차적으로 보냄.
 * 0, 1, 2의 숫자로 전송받음
 */
public class GlovInput : MonoBehaviour
{
    public enum FingerState
    {
        Straight, //펴짐
        Bending,  //살짝 구부림
        Fold      //완전히 접음
    };

    public static GlovInput instance = null;

    private FingerState[] fingers = new FingerState[5];
    private KeyCode[] keyMap = new KeyCode[5]
        { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G };  //엄지부터 a, s, d, f ,g;

    //private static SerialPort sp = new SerialPort("COM5", 9600);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("Manager Created");
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            fingers[i] = FingerState.Straight;
        }

        //if(!sp.IsOpen)
        //{
        //    sp.Open();
        //}
    }

    void Update()
    {
        //GetStateFromArduino();
        GetStateFromKeyboard();
    }

    public FingerState[] GetFingerStates()
    {
        return fingers;
    }

    public FingerState GetOneFingerState(int fingerNum)
    {
        return fingers[fingerNum];
    }

    /*
    private void GetStateFromArduino()
    {
        byte[] buffer = new byte[16];
        sp.Read(buffer, 0, 15);

        for (int i = 0; i < 5; i++)
        {
            fingers[i] = (FingerState)buffer[i]; //0또는 1 또는 2 전송
        }
    }*/

    private void GetStateFromKeyboard()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Input.GetKey(keyMap[i]) || Input.GetMouseButton(0))
            {
                fingers[i] = FingerState.Fold;
            }
            else
            {
                fingers[i] = FingerState.Straight;
            }
        }

    }

    private void OnDestroy()
    {
        //sp.Close();
    }
}
