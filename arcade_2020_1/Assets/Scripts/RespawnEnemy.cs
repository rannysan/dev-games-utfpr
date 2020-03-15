using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy1;
    public GameObject enemy2;

    private float width;
    private float heigth;
    void Start()
    {
        heigth = Camera.main.orthographicSize;
        width = heigth * Camera.main.aspect;

        InvokeRepeating("Respawn", 2, 1);
    }

    public void Respawn()
    {
        float posX = Random.Range(-width + 0.5f, width - 0.5f);
        int rng = Random.Range(1, 3);

        if (rng == 1)
            Instantiate(enemy, new Vector2(posX, heigth + 2), Quaternion.identity);
        else if (rng == 2)
            Instantiate(enemy1, new Vector2(posX, heigth + 2), Quaternion.identity);
        else if (rng == 3)
            Instantiate(enemy2, new Vector2(posX, heigth + 2), Quaternion.identity);
    }
}
