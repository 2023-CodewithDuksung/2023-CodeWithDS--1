using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timetable : MonoBehaviour
{

    private float startTime; // 시작 시간
    private float endTime;   // 종료 시간
    //private TimeCheckBook timeCheckBookInstance;
    
    public void StartButtonClicked()
    {
        startTime = Time.realtimeSinceStartup;
    }

    public void FinishButtonClicked()
    {
        endTime = Time.realtimeSinceStartup;

        float recordedTime = (endTime - startTime) /2; // 경과 시간 계산
     
        Debug.Log("시간저장!" + recordedTime);
        

        PlayerPrefs.SetFloat("RecordedTime", recordedTime);
        SceneManager.LoadScene("Timetable");
    }
}
