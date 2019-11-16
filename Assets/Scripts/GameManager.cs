using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int steps;                          //사용자의 현재 걸음수 저장 변수
    
    void Awake()
    {
        steps = int.Parse(GameObject.FindGameObjectsWithTag("CurrentSteps").ToString());        //현재 걸음수 가져온다
    }

    // Update is called once per frame
    void Update()
    {

    }
}
