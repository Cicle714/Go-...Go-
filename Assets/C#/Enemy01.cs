using UnityEngine;

public class Enemy01 : EnemyStatus
{
    Rigidbody2D rb;
    SpriteRenderer sR;

    [SerializeField]
    private float AttackInterval; //攻撃の間隔
    private float AttackCount; //攻撃のカウント


    [SerializeField]
    private GameObject Bullet; //弾
    [SerializeField]
    private GameObject BulletPos; //弾が出る場所
    [SerializeField]
    private float BulletSpeed; //弾の速さ

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();

        AttackCount = AttackInterval; //攻撃のカウント初期化
    }


    // Update is called once per frame
    void Update()
    {
        if (AttackCount < 0)
        {
            AttackCount = AttackInterval; //攻撃のカウント初期化
            GameObject clone = Instantiate(Bullet,BulletPos.transform.position, Quaternion.identity); //弾発射
            EnemyBullet cloneBullet = clone.GetComponent<EnemyBullet>();
            cloneBullet.type = EnemyBullet.BulletType.Normal;
            if(!sR.flipX)
            cloneBullet.bulletSpeed = BulletSpeed;
            else
            cloneBullet.bulletSpeed = -BulletSpeed;
            cloneBullet.attackPow = AttackPow;
        }
        AttackCount -= Time.deltaTime; //カウントダウン
    }
}
