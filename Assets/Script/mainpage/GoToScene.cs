using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToScene : MonoBehaviour
{
    public void GotoStudy()
    {
        Debug.Log("study");
        SceneManager.LoadScene("Studypage");
    }
    public void GotoSleep()
    {
        Debug.Log("study");
        SceneManager.LoadScene("Sleeppage");
    }
    public void GotoRelax()
    {
        Debug.Log("study");
        SceneManager.LoadScene("Relaxpage");
    }
    public void GotoMeal()
    {
        Debug.Log("study");
        SceneManager.LoadScene("Mealpage");
    }
    public void GotoTimetable()
    {
        Debug.Log("study");
        SceneManager.LoadScene("Timetable");
    }
    public void GotoStore()
    {
        Debug.Log("study");
        SceneManager.LoadScene("Store");
    }
}
