using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTimeStudy : MonoBehaviour
{
    bool btn_active; //버튼이 활성화 상태인지 검사.
    public Text[] text_time; // 시간을 표시할 text
    float time; // 시간.
    public float counttimeStudy;// 시간 누적을 위해서 저장하는 곳

    public Sprite[] sprites;
    //public Animator animator;
    private void Start()
    {

        btn_active = false; //버튼의 초기 상태를 false로 만듦
    }
    public void Btn_Click()
    { // 버튼 클릭 이벤트

        if (!btn_active)
        {
            SetTimerOn();
        }
        else
        {
            SetTimerOff();
        }
    }
    public void SetTimerOn()

    { // 버튼 활성화 메소드

        //animator.SetBool("timeron", true);
        btn_active = true;
        GameObject.Find("Timerbutton").GetComponent<Image>().sprite = sprites[1];
    }

    public void SetTimerOff()

    { // 버튼 비활성화 메소드
        //animator.SetBool("timeron", false);
        GameObject.Find("Timerbutton").GetComponent<Image>().sprite = sprites[0];
        counttimeStudy = time;
        Debug.Log(counttimeStudy);
        btn_active = false;
    }
    private void Update() // 바뀌는 시간을 text에 반영 해 줄 update 생명주기

    {
        if (btn_active)
        {
            time += Time.deltaTime;
            text_time[0].text = ((int)time / 3600).ToString();
            text_time[1].text = ((int)time / 60 % 60).ToString();
            text_time[2].text = ((int)time % 60).ToString();
        }
    }
}
