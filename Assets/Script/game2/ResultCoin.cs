using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultCoin : MonoBehaviour
{
    private TextMeshProUGUI textResultCoin;
    /*
    private void Start()
    {
        float amountcoin = PlayerPrefs.GetFloat("Coin");
        Debug.Log("총 얻은 코인:" + amountcoin);
    }*/

    private void Awake()
    {
        textResultCoin = GetComponent<TextMeshProUGUI>();

        //float coin = PlayerPrefs.GetFloat("Coin");

        //Debug.Log("Coin value: " + coin); // 디버그 로그 출력
        //textResultCoin.text =""+ coin;
        float amountcoin = PlayerPrefs.GetFloat("Coin");
        Debug.Log(amountcoin);

        textResultCoin.text = "" + amountcoin;
        

    }


}

