using UnityEngine;

public class Boss : EnemyStatus
{
    Rigidbody2D rb;
    SpriteRenderer sR;

    public bool Attack; //攻撃モード

    [SerializeField]
    private float AttackInterval; //攻撃の間隔
    [SerializeField]
    private float AttackInterval2; //攻撃の間隔
    private float AttackCount; //攻撃のカウント
    private float AttackCount2; //攻撃のカウント

    [SerializeField]
    private Vector2 BulletVector;

    [SerializeField]
    private GameObject Bullet; //弾
    [SerializeField]
    private GameObject BulletPos; //弾が出る場所
    [SerializeField]
    private GameObject BulletPos2; //弾が出る場所
    [SerializeField]
    private float BulletSpeed; //弾の速さ

    private int BulletCount;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();

        AttackCount = AttackInterval; //攻撃のカウント初期化
    }


    // Update is called once per frame
    void Update()
    {

        if (!Attack)
            return;

        if (AttackCount < 0)
        {
            AttackCount = AttackInterval; //攻撃のカウント初期化
            GameObject clone = Instantiate(Bullet, BulletPos.transform.position, Quaternion.identity); //弾発射
            EnemyBullet cloneBullet = clone.GetComponent<EnemyBullet>();
            cloneBullet.type = EnemyBullet.BulletType.Normal; //直線に弾を飛ばす

            //画像の向きに弾を発射する
            if (!sR.flipX)
                cloneBullet.bulletSpeed = BulletSpeed;
            else
                cloneBullet.bulletSpeed = -BulletSpeed;

            cloneBullet.transform.localScale = Vector3.one * 2.5f; //サイズを合わせる
            cloneBullet.attackPow = AttackPow; //弾に攻撃力を与える
        }
        AttackCount -= Time.deltaTime; //カウントダウン

        if (AttackCount2 < 0)
        {
            AttackCount2 = AttackInterval2; //攻撃のカウント初期化
            if (BulletCount >= 5)
            {
                BulletCount = 0;
                return;
            }
            BulletCount++;
            GameObject clone = Instantiate(Bullet, BulletPos2.transform.position, Quaternion.identity); //弾発射
            EnemyBullet cloneBullet = clone.GetComponent<EnemyBullet>();
            cloneBullet.type = EnemyBullet.BulletType.Physics; //山なりに弾を飛ばす

            //画像の向きに弾を発射する
            if (!sR.flipX)
                cloneBullet.bulletVector = BulletVector;
            else
                cloneBullet.bulletVector = new Vector2(-BulletVector.x, BulletVector.y);

            cloneBullet.transform.localScale = Vector3.one * 2f; //サイズを合わせる
            cloneBullet.attackPow = AttackPow; //弾に攻撃力を与える
        }
        AttackCount2 -= Time.deltaTime; //カウントダウン
    }
}
