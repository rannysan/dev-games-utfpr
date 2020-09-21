using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    public float offset_y = 1;

    void Update()
    {
        if (player)
        {
            Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y + offset_y, -10);
            this.transform.position = position;

        }
    }
}
