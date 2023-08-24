using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame: MonoBehaviour
{  
    public void GotoEntrance()
    {
        SceneManager.LoadScene("GameEntrance");
    }
    public void GotoGame1()
    {
        SceneManager.LoadScene("MiniGame1Intro");
    }
    public void GotoGame2()
    {
        SceneManager.LoadScene("MiniGame2Intro");
    }
}
