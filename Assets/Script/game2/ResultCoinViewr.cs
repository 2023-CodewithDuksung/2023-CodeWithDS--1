//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class ResultCoinViewr : MonoBehaviour
//{
//    private TextMeshProUGUI textResultCoin;

//    private void Awake()
//    {
//        textResultCoin = GetComponent<TextMeshProUGUI>();

//        int coin = PlayerPrefs.GetInt("Coin");
//        textResultCoin.text = ""+ coin;
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultCoinViewer : MonoBehaviour
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

        int coin = PlayerPrefs.GetInt("Coin", 0);

        Debug.Log("Coin value: " + coin); // 디버그 로그 출력
        textResultCoin.text = "Result Coin: " + coin;
        float amountcoin = PlayerPrefs.GetFloat("Coin");
        Debug.Log(amountcoin);
        
    }


}
