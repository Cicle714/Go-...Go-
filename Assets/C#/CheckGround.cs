using UnityEngine;

public class CheckGround : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        player.CheckGround(true);@//’n–Ê‚ÉG‚ê‚Ä‚¢‚éˆ—
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            player.CheckGround(false); //’n–Ê‚©‚ç—£‚ê‚Ä‚¢‚éˆ—
    }

}
