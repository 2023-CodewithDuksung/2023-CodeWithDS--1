using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeResult : MonoBehaviour
{
    public Text studytime;
    public int maxRandomSpawns = 3;
    public GameObject[] objectPrefabs;
    public float spawnInterval = 2.0f;
    private Vector2 spawnPosition; // 현재 물체 생성 위치
    private float verticalOffset = 0.15f; // 물체 간격

    // Start is called before the first frame update
    void Start()
    {
        float recordedTime = PlayerPrefs.GetFloat("RecordedTime", 0.0f);
        int objectCount = Mathf.FloorToInt(recordedTime / 2.0f);
        Debug.Log("저장된시간을 다음씬으로 이동~!" + recordedTime);

        // 생성된 물체 개수를 UI 텍스트로 표시
        //elapsedTimeText.text = "저장된 시간: " + recordedTime.ToString();

        studytime.text = recordedTime.ToString();

        spawnPosition = new Vector2(-1.0f, -3.0f); // 초기 위치 설정

        int totalObjectCount = Mathf.FloorToInt(recordedTime / spawnInterval);
        int randomObjectCount = Mathf.FloorToInt(recordedTime / spawnInterval);
        // Calculate the count of interval-based spawns
        int intervalObjectCount = totalObjectCount - randomObjectCount;

        float maxHeight = verticalOffset * (totalObjectCount - 1);

        // Spawn random objects
        for (int i = 0; i < randomObjectCount; i++)
        {
            SpawnRandomObject(maxHeight);
            Debug.Log("랜덤 물체생성");
        }

    }
    private void SpawnRandomObject(float maxHeight)
    {
        GameObject randomPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

        // Calculate the position for stacking
        Vector2 randomSpawnPosition = spawnPosition + Vector2.up * verticalOffset;

        Instantiate(randomPrefab, randomSpawnPosition, Quaternion.identity);

        // Update the spawn position for the next object
        spawnPosition = randomSpawnPosition + Vector2.up * verticalOffset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
