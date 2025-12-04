using UnityEngine;

public class Ground : MonoBehaviour
{
    SpriteRenderer sR;
    BoxCollider2D Col;
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        Col = GetComponent<BoxCollider2D>();

        Col.size = sR.size; //コライダーをSpriteRendererのサイズに合わせる

    }

}
