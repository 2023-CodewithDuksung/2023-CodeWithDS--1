using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExplainPanel : MonoBehaviour
{
    public GameObject[] panelButton, ExpPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextButtonClick(int i)
    {
        switch (i)
        {
            case 0: 
                ExpPanel[i].SetActive(false);
                ExpPanel[i + 1].SetActive(true);
                break;
            case 1:
                ExpPanel[i].SetActive(false);
                ExpPanel[i + 1].SetActive(true);
                break;
            case 2:
                ExpPanel[i].SetActive(false);
                ExpPanel[i + 1].SetActive(true);
                break;
            case 3:
                ExpPanel[i].SetActive(false);
                SceneManager.LoadScene("MainPage 0");
                break;
        }
    }
}
