using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y,-10);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        }
    }
}
