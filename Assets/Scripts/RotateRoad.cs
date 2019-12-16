﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoad : MonoBehaviour
{
    public Vector3 anglesToRotate;
    // Update is called once per frame
    void Update()
    {
        if (Singleton.Instance.isWalking == true) // 사용자가 움직이면 길도 움직이게 하기
        {
            transform.Rotate (anglesToRotate * Time.deltaTime);
        }
        else
        {
            Debug.Log("You Should Move!!");
        }
    }
}