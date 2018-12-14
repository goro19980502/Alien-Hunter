using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timecount : MonoBehaviour {

    public float startTime;
    public Text text;
    string s;
	void Update () {
        showtime();
	}
    void showtime()
    {
        float nowTime = Time.time - startTime;
        int timeInt = 180 - (int)nowTime;
        Debug.Log("執行時間"+timeInt);
        s = timeInt.ToString();
        text.text = "Time： " + s;
        if (timeInt == 0)
            Application.LoadLevel(1);
    }
    //更新遊戲時間
    void rest()
    {
        startTime = Time.time;
    }
    //時間暫停
    public void OnEnableStop()
    {
        Time.timeScale = 0f;
    }
    //時間以正常速度運行
    public void OnDisableStart()
    {
        Time.timeScale = 1f;
    }
}
