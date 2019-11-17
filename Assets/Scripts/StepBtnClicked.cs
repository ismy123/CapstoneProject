using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StepBtnClicked : MonoBehaviour
{
    public GameObject Canvas;

    private GameObject stepInfo;

    private void Start()
    {
        stepInfo = GameObject.Find("StepInfo");
        stepInfo.SetActive(false);
    }
    public void SetClear()          // 걸음 수 설정 버튼이 클릭되는 순간 창 안보이게 숨김 + 걸음 수 정보 띄워줌
    {
        Canvas.SetActive(false);
        stepInfo.SetActive(true);
    }
  
}
