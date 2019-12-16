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
        Singleton.Instance.range = 2000;
        Debug.Log(2000);
    }

    public void ClickedButton2()
    {
        Singleton.Instance.range = 3000;
        Debug.Log(3000);
    }

    public void ClickedButton3()
    {
        Singleton.Instance.range = 5000;
        Debug.Log(5000);
    }

    public void ClickedButton4()
    {
        Singleton.Instance.range = 00;
        Debug.Log(00);
    }
}

