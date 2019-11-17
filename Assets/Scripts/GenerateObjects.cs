/*
 * 사용자의 현재 걸음 수값이 변동함에 따라 구슬/아이템/몬스터가 화면에 나타난다.
 * 구슬: 40 걸음
 * 아이템: 85 걸음
 * 몬스터: 100 걸음
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour
{
    private int currentSteps, bubbleSteps, itemSteps, monsterSteps;
    private int random;
    private float randomX;
    private Vector3 pos;

    private int bubble = 40;                            //구슬 기준 걸음 수
    private int item = 85;
    private int monster = 100;

    [SerializeField]
    private GameObject[] bubblePrefabs;                 //구슬 오브젝트

    [SerializeField]
    private GameObject[] itemPrefabs;

    [SerializeField]
    private GameObject[] monsterPrefabs;

    public GameObject ground;

    // Update is called once per frame
    void Update()
    {
        currentSteps = Singleton.Instance.step;

        bubbleSteps = currentSteps % bubble;
        itemSteps = currentSteps % item;
        monsterSteps = currentSteps % monster;

        if (bubbleSteps == bubble)
        {
            random = Random.Range(0, 2);
            Instantiate(bubblePrefabs[random], RandomPos(), Quaternion.identity);
        }

        if (itemSteps == item)
        {
            random = Random.Range(0, 1);
        }

        if (monsterSteps == monster)
        {
            random = Random.Range(0, 6);
        }
    }

    Vector3 RandomPos()
    {
        randomX = Random.Range(-3.0f, 3.0f);
        pos = new Vector3(randomX, 1, -33);
        return pos;
    }
}
