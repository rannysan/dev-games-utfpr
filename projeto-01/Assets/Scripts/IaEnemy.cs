using UnityEngine;

public class IaEnemy : MonoBehaviour
{
    public float speed;
    public bool isRight;

    public Transform groundCheck;
    public Transform damageCheck;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 2f);

        if(!groundInfo.collider)
        {
            if (isRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && (collision.collider.CompareTag("Goals") || collision.collider.CompareTag("Enemy")))
        {
            if (isRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = true;
            }
        }
    }
}
