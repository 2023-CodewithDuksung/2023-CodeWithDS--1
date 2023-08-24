using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    public void LoadNextScene()
    {
        // 다음 씬의 이름을 여기에 입력합니다.
        string nextSceneName = "MiniGame1";

        // 다음 씬으로 전환합니다.
        SceneManager.LoadScene(nextSceneName);
    }
}
