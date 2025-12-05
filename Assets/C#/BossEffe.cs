using UnityEngine;

public class BossEffe : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Boss>().Attack = true; //UŒ‚‚ğŠJn‚³‚¹‚é
        Destroy(gameObject); //Á‚·
    }

}
