﻿/*
 * 사용자의 현재 걸음 수값이 변동함에 따라 구슬/아이템/몬스터가 화면에 나타난다.
 * 구슬: 40 걸음
 * 아이템: 85 걸음
 * 몬스터: 100 걸음
 */
using UnityEngine;
using System.Linq;

public class GenerateObjects : MonoBehaviour
{
    private int currentSteps, marbleSteps, itemSteps, monsterSteps;
    private int newMarbleStep, newItemStep, newMonsterStep = -1;
    private int random;
    private float randomX;
    private Vector3 pos;
    private bool isObjExist;

    private int marbleLimit = 10;                            //구슬 기준 걸음 수 40
    private int itemLimit = 85;
    private int monsterLimit = 100;

    [SerializeField]
    private GameObject[] marblePrefabs;                 //구슬 오브젝트

    [SerializeField]
    private GameObject[] itemPrefabs;

    [SerializeField]
    private GameObject[] monsterPrefabs;

    private GameObject[] marble;
    private GameObject[] item;
    private GameObject[] monster;
    private GameObject[] objects;

    private StepCounter stepCounter = new StepCounter();

    // Update is called once per frame
    void Update()
    {
        currentSteps = Singleton.Instance.step;

        marbleSteps = currentSteps % marbleLimit;
        itemSteps = currentSteps % itemLimit;
        monsterSteps = currentSteps % monsterLimit;

        if (currentSteps > 0 && (newMarbleStep != currentSteps) && marbleSteps == 0)    //구슬 생성 조건
        {
            newMarbleStep = currentSteps;
            random = Random.Range(0, 2);                                                //구슬 종류 뽑고
            Instantiate(marblePrefabs[random], RandomPos(), Quaternion.identity);       //씬에 구슬 생성
            //Instantiate(marblePrefabs[random], new Vector3(0,1,-60), Quaternion.identity);
            Handheld.Vibrate();                                                         //진동으로 구슬 생성 알림
        }

        if (currentSteps > 0 && (newItemStep != currentSteps) && itemSteps == 0)         //아이템 생성 조건
        {
            newItemStep = currentSteps;
            random = Random.Range(0, 1);
            Instantiate(itemPrefabs[random], RandomPos(), Quaternion.identity);
            Handheld.Vibrate();
        }

        if (currentSteps > 0 && (newMonsterStep != currentSteps) && monsterSteps == 0)      //몬스터 생성 조건
        {
            newMonsterStep = currentSteps;
            random = Random.Range(0, 4);
            Instantiate(monsterPrefabs[random], RandomPos(), Quaternion.identity);
            Handheld.Vibrate();
        }
    }

    void FixedUpdate()
    {
        isObjExist = GameObject.FindGameObjectsWithTag("marble") != null || GameObject.FindGameObjectsWithTag("item") != null || GameObject.FindGameObjectsWithTag("monster") != null;
        stepCounter.WalkingCheck();

        if(isObjExist && stepCounter.isWalking == true)                       //씬에 오브젝트 있고 사용자가 걷고 있으면 실행
        {
            marble = GameObject.FindGameObjectsWithTag("marble");
            item = GameObject.FindGameObjectsWithTag("item");
            monster = GameObject.FindGameObjectsWithTag("monster");

            objects = marble.Concat(item.Concat(monster).ToArray()).ToArray();

            foreach (GameObject o in objects)
                o.transform.Translate(Vector3.back * Time.deltaTime, Space.World);        //이동
        }
    }

    Vector3 RandomPos()                                 //화면 상단의 임의의 위치 잡는다
    {
        randomX = Random.Range(-3.0f, 3.0f);
        pos = new Vector3(randomX, 1, -33);
        return pos;
    }
}
