using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepManager : MonoBehaviour
{
    private static StepManager instance;

    public static StepManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new StepManager();
            }

            return instance;
        }
    }
    // public int range;
    private int Step;
    private int range;
    public Button Range1Btn;
    public Button Range2Btn;
    public Button Range3Btn;
    public Button NoRangeBtn;
    
        
    public void ButtonClick(int range)
    {
        Step = range;
        Range1Btn = this.transform.GetComponent<Button>();
        Range1Btn.onClick.AddListener(Range1);

        Range2Btn = this.transform.GetComponent<Button>();
        Range2Btn.onClick.AddListener(Range2);

        Range3Btn = this.transform.GetComponent<Button>();
        Range3Btn.onClick.AddListener(Range3);

        NoRangeBtn = this.transform.GetComponent<Button>();
        NoRangeBtn.onClick.AddListener(Range4);

        // if (Instance == null)
        // {
        //     instance = this;
        //     Step = range;
        // }

        // else if (instance != this)
        // {
        //     Destroy(this.gameObject);
        // }

    void Range1()
    {
        range = 1000;
    }

    void Range2()
    {
        range = 1500;
    }

    void Range3()
    {
        range = 2000;
    }

    void Range4()
    {
        range = 2000;
    }
        DontDestroyOnLoad(this.gameObject); //현재의 오브젝트가 다른 씬으로 넘어가도 삭제하지 않음
    }

    public void Send(int Step)
    {
        Step = range;
    }

}

