using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb; //Rigidbody2D取得
    Animator anim; //Animator取得
    SpriteRenderer sR; //SpriteRenderer取得
    BoxCollider2D col; //Collider取得

    [SerializeField]
    private int Hp; //体力
    [SerializeField]
    private int MaxHp; //最大体力

    [SerializeField]
    private float MoveSpeed; //移動スピード
    [SerializeField]
    private float DashSpeed; //ダッシュスピード

    [SerializeField]
    private float JumpPow; //ジャンプ力の設定
    [SerializeField]
    private bool IsGround; //地面にいるか
    [SerializeField]
    private bool Fall; //落ちているか

    private bool Hit; //攻撃をくらったか
    private bool knockback; //ノックバック中か

    [SerializeField]
    private GameObject DeadObject; //死んだときにでるオブジェクト
    [SerializeField]
    private GameObject DeadEffect; //死んだときのエフェクト

    private float offsetX; //コライダーの位置
    private float offsetY; //コライダーの位置




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();


        offsetX = col.offset.x;　//当たり判定取得
        offsetY = col.offset.y; //当たり判定取得
    }

    // Update is called once per frame
    void Update()
    {
        if (knockback) //ノックバック中は操作を受け付けない
        {
            return;
        }
        PlayerMove(); //移動
        PlayerAir(); //空中
    }




    private void PlayerMove()
    {

        float moveNum = 0; //移動値
        bool isDash = false; //ダッシュしているか

        //移動処理
        if (GetKeyA())
        {
            sR.flipX = true;
            moveNum -= MoveSpeed;
        }
        if (GetKeyD())
        {
            sR.flipX = false;
            moveNum += MoveSpeed;
        }
        //ダッシュ処理
        if (GetKeyShift() && moveNum != 0)
        {
            isDash = true;
            moveNum *= DashSpeed;
        }

        //アニメータ-処理
        anim.SetBool("Dash", isDash);
        anim.SetBool("Move", moveNum != 0);

        //移動処理
        rb.linearVelocityX = moveNum;
    }

    void PlayerAir()
    {
        //地面についているかでコライダーの位置を変える
        if (IsGround)
        {
            col.offset = new Vector2(offsetX, offsetY);
        }
        else
        {
            col.offset = new Vector2(offsetX, 0);
        }

        //ジャンプ処理
        if (GetKeyDownSpace() && IsGround)
        {
            IsGround = false;
            rb.linearVelocityY = JumpPow;
            anim.Play("Jump");
        }

        //落ちている処理
        if (rb.linearVelocityY <= -0.5f)
        {
            Debug.Log("読んでるよ");
            Fall = true;
        }
        else
        {
            Fall = false;
        }
        anim.SetBool("Fall", Fall);
    }


    //地面にいるかの処理
    public void CheckGround(bool landing)
    {
        if (landing)
        {
            Fall = false;
            if (!IsGround)
                anim.Play("Idle"); //地面についたら強制的にIdleにする
            IsGround = true;
        }
        else
        {
            IsGround = false;
        }
    }


    public void Damage(int damage, Vector2 Nockback)
    {
        if (!Hit)
        {
            Hp -= damage; //Hpを減らす処理
            knockback = true; //ノックバックしている
            if (Hp <= 0)
            {
                StartCoroutine(PlayerDead()); //プレイヤー死にました
                return;
            }
        }
    }



    /// <summary>
    /// プレイヤーが死んだときの処理
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayerDead()
    {
        //死んだときの演出
        anim.Play("Hit");
        Time.timeScale = 0;
        float count = 1;
        while (count > 0)
        {
            count -= Time.unscaledDeltaTime;
            yield return null;
        }
        Time.timeScale = 1;
        Instantiate(DeadObject, gameObject.transform.position, Quaternion.identity);
        Instantiate(DeadEffect, gameObject.transform.position, Quaternion.identity);

        FindObjectOfType<UI>().StartCoroutine(FindObjectOfType<UI>().BlackOut2());

        gameObject.SetActive(false); ;

    }

    //操作関係
    bool GetKeyA()
    {
        if (Input.GetKey(KeyCode.A)) return true;
        return false;
    }
    bool GetKeyD()
    {
        if (Input.GetKey(KeyCode.D))
            return true;
        return false;
    }
    bool GetKeyShift()
    {
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) return true;
        return false;
    }

    bool GetKeyDownSpace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            return true;
        return false;
    }

}
