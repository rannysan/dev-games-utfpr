using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float speed;

    private float width;
    private float heigth;

    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();

        heigth = Camera.main.orthographicSize;
        width = heigth * Camera.main.aspect;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rbd.velocity = new Vector2(x, y) * speed;

        if (transform.position.x > width)
            transform.position = new Vector2(-width, transform.position.y);
        else if (transform.position.x < -width)
            transform.position = new Vector2(width, transform.position.y);

        if (transform.position.y > 0 && y > 0 || transform.position.y < -heigth && y < 0)
            rbd.velocity = new Vector2(x, 0) * speed;
    }
}
