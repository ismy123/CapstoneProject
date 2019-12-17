using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelmanager : MonoBehaviour
{
    public GameObject panel;

    void Update()
    {
        if(Singleton.Instance.panel == true)
        {   
            panel.SetActive(true);
        }

        else
        {
            panel.SetActive(false);
        }
    }
}
