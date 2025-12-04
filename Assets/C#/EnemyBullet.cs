using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    Rigidbody2D rb;

    public enum BulletType //攻撃の種類
    {
        Normal,
        Physics,
    }
    private BulletType Type;
    public BulletType type
    {
        get { return Type; }
        set { Type = value; }
    }


    private float BulletSpeed; //弾のスピード
    public float bulletSpeed
    {
        get { return BulletSpeed; }
        set { BulletSpeed = value; }
    }

    private Vector2 BulletVector; //弾のベクトル
    public Vector2 bulletVector
    {
        get { return BulletVector; }
        set { BulletVector = value; }
    }

    private float AttackPow; //弾の攻撃力
    public float attackPow
    {
        get { return AttackPow; }
        set { AttackPow = value; }
    }
    [SerializeField]
    private float NockBackPow; //ノックバック力


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (type == BulletType.Normal)
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        else if (type == BulletType.Physics)
        {
            PhysicsBullet();
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case BulletType.Normal:
                NormalBullet();
                break;


        }
    }

    void NormalBullet()
    {
        transform.position += Vector3.left * BulletSpeed * Time.deltaTime;
    }
    void PhysicsBullet()
    {
        rb.linearVelocity = BulletVector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if(type == BulletType.Normal)
            collision.gameObject.GetComponent<Player>().Damage((int)AttackPow, new Vector3(-BulletSpeed, NockBackPow + (AttackPow / 2)));
            else if(type == BulletType.Physics)
                collision.gameObject.GetComponent<Player>().Damage((int)AttackPow, new Vector3(rb.linearVelocityX, NockBackPow + (AttackPow / 2)));
        }
    }

}
