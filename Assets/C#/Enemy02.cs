using UnityEngine;

public class Enemy02 : EnemyStatus
{
    Rigidbody2D rb;
    SpriteRenderer sR;

    [SerializeField]
    private float AttackInterval; //攻撃の間隔
    private float AttackCount; //攻撃のカウント
    [SerializeField]
    private float BulletCountPlus;


    [SerializeField]
    private GameObject Bullet; //弾
    [SerializeField]
    private GameObject BulletPos; //弾が出る場所
    [SerializeField]
    private Vector2 BulletVector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();

        AttackCount = AttackInterval; //攻撃のカウント初期化
        AttackCount -= BulletCountPlus; //カウントの加算値
    }


    // Update is called once per frame
    void Update()
    {
        if (AttackCount < 0)
        {
            AttackCount = AttackInterval; //攻撃のカウント初期化
            GameObject clone = Instantiate(Bullet, BulletPos.transform.position, Quaternion.identity); //弾発射
            EnemyBullet cloneBullet = clone.GetComponent<EnemyBullet>();
            cloneBullet.type = EnemyBullet.BulletType.Physics;
            if (!sR.flipX)
                cloneBullet.bulletVector = BulletVector;
            else
                cloneBullet.bulletVector = new Vector2(-BulletVector.x, BulletVector.y);
            cloneBullet.attackPow = AttackPow;
        }
        AttackCount -= Time.deltaTime; //カウントダウン
    }
}
