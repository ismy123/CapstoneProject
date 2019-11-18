﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGen : MonoBehaviour // 끝없는 길 만들기
{
    public Transform startPos; // 길의 위치를 알아서 자연스럽게 이어지게 함
    int nextStep = 0;

    float speed = 4.0f; // 길이 움직이는 속도 조절

    Vector3 moveDir = Vector3.zero;

    public GameObject [] PrefabsRoad; // 길의 다양한 타입을 저장

    // Update is called once per frame
    void Update()
    { 
        nextStep+=10;
        GameObject moveroad = Instantiate(PrefabsRoad[Random.Range(0,PrefabsRoad.Length)], new Vector3(startPos.position.x,startPos.position.y,transform.position.z+nextStep), Quaternion.identity) as GameObject; // 길 무한 생성
        
         if (Singleton.Instance.isWalking == true) // 사용자가 움직이면 길도 움직이게 하기
        {
            // moveroad.transform.position = new Vector3(0,0,-20.0f);//프레임마다 등속으로 다가오기

            moveDir = new Vector3(0, 0, -20);
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);

        }

        else if (Singleton.Instance.isWalking == false)
        {
            Debug.Log("You Should Move!!");
        }
    }

}
