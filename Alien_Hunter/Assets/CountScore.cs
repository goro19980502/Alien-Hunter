using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountScore : MonoBehaviour {

    int sum = 0;
    GameObject[] eleobj;
    void Update () {
        if (eleobj == null)
            eleobj = GameObject.FindGameObjectsWithTag("Monster");
        
	}
    void OnCollisionEnter(Collision collision)
    {
        bool x = false;
        for(int i = 0; i < eleobj.Length; i++)
        {
            if(collision.gameObject.name == eleobj[i].name)
            {
                eleobj[i].SetActive(false);
                x = true;
                break;
            }
        }
    }
    void scoreCount()
    {
        bool x = false;
        if(eleobj.Length > 0)
        {
            for(int i = 0; i < eleobj.Length; i++)
            {
                if(eleobj[i].activeInHierarchy == true)
                {
                    x = true;
                    break;
                }
            }
        }
        if(x == false)
        {
            Application.LoadLevel(1);
        }
    }
}
