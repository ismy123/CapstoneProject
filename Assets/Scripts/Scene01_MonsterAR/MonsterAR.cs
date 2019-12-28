using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAR : MonoBehaviour
{
    private GameObject monster01, monster02, monster03, monster04, monster05;
    private Vector3 pos;

    private GameObject monster;

    [SerializeField]
    private GameObject[] monsterPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Singleton.Instance.Monster = monster01)
        {
            monster = monster01;
        }

        else if (Singleton.Instance.Monster = monster02)
        {
            monster = monster02;
        }

        else if (Singleton.Instance.Monster = monster03)
        {
            monster = monster03;
        }

        else if (Singleton.Instance.Monster = monster04)
        {
            monster = monster04;
        }

        else if (Singleton.Instance.Monster = monster05)
        {
            monster = monster05;
        }
    }

    void SetMonster()
    {
        pos = new Vector3(0, -0.2884f, 1.0232f);
        Instantiate(monster, pos, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
    }
}
