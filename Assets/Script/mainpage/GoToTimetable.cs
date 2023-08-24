using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTimetable : MonoBehaviour
{
    public void GotoTimetable()
    {
        SceneManager.LoadScene("Timetable");
    }
}
