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

    // void Update()
    // {
    //     if (Range1Btn == true)
    //     {
    //         Singleton.Instance.step = 1000;
    //         Debug.Log(1000);
    //     }

    //     else if (Range2Btn == true)
    //     {
    //         Singleton.Instance.step = 1500;
    //         Debug.Log(1500);
    //     }

    //     else if (Range3Btn == true)
    //     {
    //         Singleton.Instance.step = 2000;
    //         Debug.Log(2000);
    //     }

    //     else if (NoRangeBtn == true)
    //     {
    //         Singleton.Instance.step = 0;
    //         Debug.Log(00);
    //     }
    // }

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


 
    // public void ButtonClick()
    // {
        // Range1Btn = this.transform.GetComponent<Button>();
        // Range2Btn = this.transform.GetComponent<Button>();
        // Range3Btn = this.transform.GetComponent<Button>();
        // NoRangeBtn = this.transform.GetComponent<Button>();

        // if (Range1Btn = true)
        // {
        //     Singleton.Instance.step = 1000;
        //     Debug.Log(1000);
        // }

        // if (Range2Btn = true)
        // {
        //     Singleton.Instance.step = 1500;
        //     Debug.Log(1500);
        // }

        // if (Range3Btn = true)
        // {
        //     Singleton.Instance.step = 2000;
        //     Debug.Log(2000);
        // }

        // if (NoRangeBtn = true)
        // {
        //     Singleton.Instance.step = 0;
        //     Debug.Log(00);
        // }
    //          DontDestroyOnLoad(this.gameObject); //현재의 오브젝트가 다른 씬으로 넘어가도 삭제하지 않음
    // }
}

