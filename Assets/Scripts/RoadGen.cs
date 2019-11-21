using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoadGen : MonoBehaviour // 끝없는 길 만들기
{

    public Transform startPos; // 길의 위치를 알아서 자연스럽게 이어지게 함

    public float nextStep = 0;

    public float speed = 5.0f; // 길이 움직이는 속도 조절

    Vector3 moveDir = Vector3.zero;

    public GameObject [] PrefabsRoad; // 길의 다양한 타입을 저장
    private StepCounter step = new StepCounter();
    GameObject moveroad, newRoad;
    GameObject[] roads;
    

    private void Start()
    {
        moveroad = GameObject.Find("Road");

        roads = new GameObject[] { newRoad, moveroad };

    }
    // Update is called once per frame
    void Update()

    { 
        addroad();
        step.WalkingCheck();

        if (Singleton.Instance.isWalking == true) // 사용자가 움직이면 길도 움직이게 하기
        {
                // transform.position = new Vector3(0,0,-100.0f);//프레임마다 등속으로 다가오기

                moveDir = new Vector3(0, 0, -5);
                //moveDir *= speed;
                //moveDir *= Time.deltaTime;

                foreach(GameObject r in roads)
                r.transform.Translate(moveDir, Space.World);
        }
        else
        {
            Debug.Log("You Should Move!!");
        }
    }

    void addroad()
    {
        nextStep = nextStep + 10;
        newRoad = Instantiate(PrefabsRoad[Random.Range(0, 3)], new Vector3(startPos.position.x, startPos.position.y, transform.position.z + nextStep * 2), Quaternion.identity) as GameObject; // 길 생성
    }
}