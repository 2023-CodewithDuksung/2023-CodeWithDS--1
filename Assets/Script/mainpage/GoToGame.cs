using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTimeGame: MonoBehaviour
{
    public void GotoGame1()
    {
        SceneManager.LoadScene("game1");
    }
    public void GotoGame2()
    {
        SceneManager.LoadScene("game2");
    }
}
