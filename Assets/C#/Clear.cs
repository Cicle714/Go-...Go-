using UnityEngine;

public class Clear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            FindObjectOfType<UI>().StartCoroutine(FindObjectOfType<UI>().WhiteOut()); //ƒNƒŠƒA‰‰o
        }
    }
}
