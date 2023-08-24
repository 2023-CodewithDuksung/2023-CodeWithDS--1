using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountTimeRelax : MonoBehaviour
{
    bool btn_active; //��ư�� Ȱ��ȭ �������� �˻�.
    public Text[] text_time; // �ð��� ǥ���� text
    float time; // �ð�.
    public float counttimeRelax;// �ð� ������ ���ؼ� �����ϴ� ��
    public Sprite[] sprites;
    //public Animator animator;
    private void Start()
    {
        btn_active = false; //��ư�� �ʱ� ���¸� false�� ����
    }
    public void Btn_Click()
    { // ��ư Ŭ�� �̺�Ʈ
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
    { // ��ư Ȱ��ȭ �޼ҵ�
        //animator.SetBool("timeron", true);
        btn_active = true;
        GameObject.Find("Timerbutton").GetComponent<Image>().sprite = sprites[1];
    }

    public void SetTimerOff()
    { // ��ư ��Ȱ��ȭ �޼ҵ�
        //animator.SetBool("timeron", false);
        GameObject.Find("Timerbutton").GetComponent<Image>().sprite = sprites[0];
        counttimeRelax = time;
        Debug.Log(counttimeRelax);
        PlayerPrefs.SetFloat("CounttimeRelax", counttimeRelax);
        btn_active = false;
    }
    private void Update() // �ٲ�� �ð��� text�� �ݿ� �� �� update �����ֱ�
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
