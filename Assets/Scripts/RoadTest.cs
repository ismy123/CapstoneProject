/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTest : MonoBehaviour
{

    Vector3 moveDir = Vector3.zero;
    GameObject moveroad, newRoad;
    GameObject[] roads;

    // Start is called before the first frame update
    void Start()
    {
        roads = new GameObject[] { newRoad, moveroad };
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(0,0,-5.0f);
        moveDir = new Vector3(0, 0, -5);
        foreach(GameObject r in roads)
                r.transform.Translate(moveDir, Space.World);
                
    }
}*/
