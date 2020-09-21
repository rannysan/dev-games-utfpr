using UnityEngine;

public class Stomped : MonoBehaviour
{
    public float force;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();
            playerRb.AddForce(Vector2.up * force);

            Destroy(transform.parent.gameObject);
        }
    }
}
