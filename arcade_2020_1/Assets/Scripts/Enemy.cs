using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rbd;
    private SpriteRenderer sptr;

    public ScriptableEnemy scriptableEnemy;

    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        sptr = GetComponent<SpriteRenderer>();

        sptr.sprite = scriptableEnemy.sprite;
        rbd.velocity = new Vector2(0, -scriptableEnemy.speed);
    }

    void Update()
    {
        if (transform.position.y < -Camera.main.orthographicSize)
            Destroy(gameObject);
    }
}
