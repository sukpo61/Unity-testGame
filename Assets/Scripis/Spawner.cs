using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]

    private GameObject[] enemies;

    [SerializeField]

    private float spawnInterval = 1.5f;



    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };
    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoutine();

    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);

        float moveSpeed = 5f;
        int spawnCount = 0;
        int enemyindex = 0;


        while (true)
        {
            int index = Random.Range(0, enemies.Length);
            foreach (float PosX in arrPosX)
            {
                SpawnEnemy(PosX, index, moveSpeed);
            }

            spawnCount += 1;
            if (spawnCount % 10 == 0)
            {
                enemyindex += 1;
                moveSpeed += 2;
            }
            yield return new WaitForSeconds(spawnInterval);

        }
    }

    // Update is called once per frame
    void SpawnEnemy(float posX, int index, float speed)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(speed);
    }
}


