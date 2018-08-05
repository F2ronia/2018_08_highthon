using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private int Spawnint;
    public float SpawnTime = 1.0f;

    private bool isSpawn = true;

    //
    private int SpawnCnt = 0;

    //

    [SerializeField]
    private GameObject Enemy;

    public void StartSpawn()
    {
        StartCoroutine(EnemySpawner());
    }

    private IEnumerator EnemySpawner()
    {
        Spawnint = Random.Range(1, 5);
        switch (Spawnint)
        {
            case 1:
                Enemy.transform.position = new Vector2(10.0f, 5.0f);
                break;

            case 2:
                Enemy.transform.position = new Vector2(10.0f, 2.5f);
                break;

            case 3:
                Enemy.transform.position = new Vector2(10.0f, 0.0f);
                break;

            case 4:
                Enemy.transform.position = new Vector2(10.0f, -2.5f);
                break;
        }

        Instantiate(Enemy);

        if (SpawnCnt <= 0) 
        {
            yield return 0;
        }
        else
        {
            yield return new WaitForSeconds(SpawnTime);
            StartCoroutine(EnemySpawner());
        }
    }
}