using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGen : MonoBehaviour // 끝없는 길 만들기
{
    public Transform startPos;
    int nextStep = 0;

    float speed = 4.0f;

    Vector3 moveDir = Vector3.zero;

    public GameObject [] PrefabsRoad; // 길의 다양한 타입을 저장

    // Update is called once per frame
    void Update()
    { 
        nextStep+=10;
        GameObject moveroad = Instantiate(PrefabsRoad[Random.Range(0,PrefabsRoad.Length)], new Vector3(startPos.position.x,startPos.position.y,transform.position.z+nextStep), Quaternion.identity) as GameObject; // 길 생성
        
         if (Singleton.Instance.isWalking == true) // 사용자가 움직이면 길도 움직이게 하기
        {
                // transform.position = new Vector3(0,0,-100.0f);//프레임마다 등속으로 다가오기

                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
        }

        else if (Singleton.Instance.isWalking == false)
        {
            Debug.Log("You Should Move!!");
        }
    }

}
