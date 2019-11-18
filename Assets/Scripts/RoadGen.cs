﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoadGen : MonoBehaviour // 끝없는 길 만들기
{
    public Transform startPos;
    float nextStep = -45.7f;

    float speed = 4.0f;

    Vector3 moveDir = Vector3.zero;

    public GameObject [] PrefabsRoad; // 길의 다양한 타입을 저장
    private StepCounter step = new StepCounter();
    GameObject moveroad, newRoad;
    GameObject[] roads;

    private void Start()
    {
        moveroad = GameObject.Find("Road");

        roads = new GameObject[] { moveroad, newRoad };
    }
    // Update is called once per frame
    void Update()
    {
        //nextStep+=10;
        if(moveroad.transform.position.z + 23.3f < -31f)
        {
            newRoad = Instantiate(PrefabsRoad[Random.Range(0, 2)], new Vector3(startPos.position.x, startPos.position.y, transform.position.z + nextStep), Quaternion.identity) as GameObject; // 길 생성
        }

        step.WalkingCheck();
        if (Singleton.Instance.isWalking == true) // 사용자가 움직이면 길도 움직이게 하기
        {
                // transform.position = new Vector3(0,0,-100.0f);//프레임마다 등속으로 다가오기

                moveDir = new Vector3(0, 0, -1);
                //moveDir *= speed;
                moveDir *= Time.deltaTime;

                foreach(GameObject r in roads)
                    r.transform.TransformDirection(moveDir);
        }
        else
        {
            Debug.Log("You Should Move!!");
        }
    }

}
