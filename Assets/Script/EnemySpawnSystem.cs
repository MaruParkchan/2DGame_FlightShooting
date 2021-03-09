using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    [SerializeField]
    private StageData stageData; // 스테이지 크기 정보
    [SerializeField]
    private GameObject[] enemyPrefabs; // 생성할 적 오브젝트들
    [SerializeField]
    private float spawnCycleTime; // 생성 주기

    private void Start()
    {
        StartCoroutine("EnemySpawner");
    }

    private IEnumerator EnemySpawner() // 적 오브젝트 코루틴
    {
        while(true)
        {
            // 스테이지 크기 x 위치 범위내에 랜덤 값 지정
            float xPosition = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);

            // 생성할 적 오브젝트들 인덱스 랜덤 값으로 생성
            int enemyPrefabIndex = Random.Range(0, enemyPrefabs.Length);

            SpawnEnemy(enemyPrefabs[enemyPrefabIndex], new Vector3(xPosition, stageData.LimitMax.y + 1.0f, 0));

            yield return new WaitForSeconds(spawnCycleTime);
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab, Vector3 position) // 생성할 오브젝트 , 생성할 위치
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }
}
