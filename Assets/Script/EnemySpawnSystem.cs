using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    [SerializeField]
    private StageData stageData; // �������� ũ�� ����
    [SerializeField]
    private GameObject[] enemyPrefabs; // ������ �� ������Ʈ��
    [SerializeField]
    private float spawnCycleTime; // ���� �ֱ�

    private void Start()
    {
        StartCoroutine("EnemySpawner");
    }

    private IEnumerator EnemySpawner() // �� ������Ʈ �ڷ�ƾ
    {
        while(true)
        {
            // �������� ũ�� x ��ġ �������� ���� �� ����
            float xPosition = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);

            // ������ �� ������Ʈ�� �ε��� ���� ������ ����
            int enemyPrefabIndex = Random.Range(0, enemyPrefabs.Length);

            SpawnEnemy(enemyPrefabs[enemyPrefabIndex], new Vector3(xPosition, stageData.LimitMax.y + 1.0f, 0));

            yield return new WaitForSeconds(spawnCycleTime);
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab, Vector3 position) // ������ ������Ʈ , ������ ��ġ
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }
}
