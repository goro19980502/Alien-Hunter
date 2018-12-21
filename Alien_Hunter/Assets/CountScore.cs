using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScore : MonoBehaviour {

    public int sum = 0;
    public Text text;
    void Update()
    {
        if(sum >= 15)
            OnWinner();    
    }
    public void scoreCount(int n)
    {
        sum++;
        string s = sum.ToString();
        text.text = s;
    }
    void OnWinner()
    {
        Application.LoadLevel(1);
    }
}
