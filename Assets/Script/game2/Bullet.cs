//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Bullet : MonoBehaviour
//{
//    public float moveSpeed = 0.01f;
//    public GameObject explosion;

//    GameObject Coin;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //Y??????
//        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
//        Destroy(gameObject, 10f);
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if(collision.gameObject.tag == "Enemy")
//        {
//            //???? ?????? ????
//            Instantiate(explosion, transform.position, Quaternion.identity);

//            Destroy(collision.gameObject);
//            Destroy(gameObject);

//            int currentCoin = PlayerPrefs.GetInt("Coin", 0);
//            currentCoin += 10;
//            PlayerPrefs.SetInt("Coin", currentCoin);

//        }
//    }

//    //?????????? ?????? ????
//    private void OnBecameInvisible()
//    {
//        //?????? ???? ?????? ?????? ??
//        Destroy(gameObject);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    public GameObject explosion;
    public GameObject coinPrefab;

    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);

            //int currentCoin = PlayerPrefs.GetInt("Coin", 0);
            //currentCoin += 10;
            //PlayerPrefs.SetInt("Coin", currentCoin);

            DropCoin();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void DropCoin()
    {
        GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        coin.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), 2f);
    }
}
