using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    public GameObject enemyGroup;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        spawnEnemy();
    }

    private void spawnEnemy()
    {
        if (enemy && enemyGroup && Random.Range(0, 1001) <= 20)
        {
            float posY = Random.Range(-4.6f, 4.6f);
            int direction = Random.Range(0, 2) == 0 ? 1 : -1;
            float posX = direction == -1 ? 7.3f : -7.3f;
            Enemy e = Instantiate(enemy);
            e.SetDirectionVector(direction);
            e.transform.position = new Vector3(posX, posY, -1);
            e.transform.parent = enemyGroup.transform;
            float da = Random.Range(8f, 15f);
            e.setDamage(da);
        }
    }
}
