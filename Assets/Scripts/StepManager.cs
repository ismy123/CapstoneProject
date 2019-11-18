using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepManager : MonoBehaviour
{
    public Button Range1Btn;
    public Button Range2Btn;
    public Button Range3Btn;
    public Button NoRangeBtn;

    void Start()
    {
        
    }

    public void ClickedButton1()
    {
        Singleton.Instance.range = 1000;
        Debug.Log(1000);
    }

    public void ClickedButton2()
    {
        Singleton.Instance.range = 1500;
        Debug.Log(1500);
    }

    public void ClickedButton3()
    {
        Singleton.Instance.range = 2000;
        Debug.Log(2000);
    }

    public void ClickedButton4()
    {
        Singleton.Instance.range = 00;
        Debug.Log(00);
    }
}

