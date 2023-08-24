using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeCheck : MonoBehaviour
{
    /*
    public GameObject objectPrefab; // 생성할 물체의 프리팹
    //public Transform objectSpawnPoint; // 물체가 생성될 위치
    public float spawnInterval = 2.0f; // 물체 생성 간격 (초 단위)
    public Text timerText; // UI Text 엘리먼트
    //public Button startButton; // "Start" 버튼
    //public Button finishButton;
    private Vector2 spawnPosition; // 현재 물체 생성 위치
    private float verticalOffset = 0.8f; // 물체 간격

    private bool isTiming = false;
    private float elapsedTime = 0.0f;
    */
    public GameObject objectPrefab1; // 생성할 물체 프리팹
    public GameObject objectPrefab2;
    public GameObject objectPrefab3;
    public GameObject objectPrefab4;
    public Transform spawnPointstudy;
    public Transform spawnPointsleep;// 물체가 생성될 위치
    public Transform spawnPointrelax;
    public Transform spawnPointmeal;
    public float yOffset = 0.4f;
    public float spawnInterval = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

        //startButton.onClick.AddListener(StartTiming);
        //finishButton.onClick.AddListener(StopTimingAndSpawnObjects);
        //spawnPosition = new Vector2(-1.0f, -3.0f); // 초기 위치 설정

        float loadedTimestudy = PlayerPrefs.GetFloat("CounttimeStudy");
        float loadedTimesleep = PlayerPrefs.GetFloat("CounttimeSleep");
        float loadedTimerelax = PlayerPrefs.GetFloat("CounttimeRelax");
        Debug.Log(loadedTimerelax);
        float loadedTimemeal = PlayerPrefs.GetFloat("CounttimeMeal");

        // 시간 값을 정수로 변환하여 물체 생성 개수 결정
        int numberOfObjectstudy = Mathf.FloorToInt(loadedTimestudy/spawnInterval);
        int numberOfObjectsleep = Mathf.FloorToInt(loadedTimesleep / spawnInterval);
        int numberOfObjectrelax = Mathf.FloorToInt(loadedTimerelax / spawnInterval);
        int numberOfObjectmeal = Mathf.FloorToInt(loadedTimemeal / spawnInterval);

        Debug.Log(numberOfObjectstudy);
        Debug.Log(numberOfObjectsleep);
        Debug.Log(numberOfObjectrelax);
        Debug.Log(numberOfObjectmeal);


        // 정수 값에 따라 물체 생성
        for (int i = 0; i < numberOfObjectstudy; i++)
        {
            Vector2 spawnPosition = spawnPointstudy.position + new Vector3(0f, i * yOffset, 0f);
            Instantiate(objectPrefab1, spawnPosition, Quaternion.identity);
        }
        for (int i = 0; i < numberOfObjectsleep; i++)
        {
            Vector2 spawnPosition = spawnPointsleep.position + new Vector3(0f, i * yOffset, 0f);
            Instantiate(objectPrefab2, spawnPosition, Quaternion.identity);
        }
        for (int i = 0; i < numberOfObjectrelax; i++)
        {
            Vector2 spawnPosition = spawnPointrelax.position + new Vector3(0f, i * yOffset, 0f);
            Instantiate(objectPrefab3, spawnPosition, Quaternion.identity);
        }
        for (int i = 0; i < numberOfObjectmeal; i++)
        {
            Vector2 spawnPosition = spawnPointmeal.position + new Vector3(0f, i * yOffset, 0f);
            Instantiate(objectPrefab4, spawnPosition, Quaternion.identity);
        }

        //Debug.Log("Loaded Time: " + loadedTimestudy);
        //Debug.Log("Number of objects: " + numberOfObjectstudy);


    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (isTiming)
        {
            elapsedTime += Time.deltaTime;

            // UI Text에 현재 시간 업데이트
            timerText.text = "Time: " + elapsedTime.ToString("F2");
        }*/
    }
    /*
    public void StartTiming()
    {
        isTiming = true;
        elapsedTime = 0.0f;
    }

    public void StopTimingAndSpawnObjects()
    {
        isTiming = false;
        int objectCount = Mathf.FloorToInt(elapsedTime / spawnInterval);

        // 물체 생성
        for (int i = 0; i < objectCount; i++)
        {
            SpawnObject();
            Debug.Log("물체생성");
        }
    }

    private void SpawnObject()
    {
        //lastSpawnPosition += Vector2.up * 20.5f; // 위로 이동
        //Instantiate(objectPrefab, objectSpawnPoint.position, Quaternion.identity);

        spawnPosition += Vector2.up * verticalOffset; // 위로 이동
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }*/

}
