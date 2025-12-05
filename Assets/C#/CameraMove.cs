using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Player player;
    [SerializeField]
    private GameObject BackGround; //”wŒiæ“¾
    private Vector3 FirstPos; //”wŒi‚ÌÅ‰‚ÌˆÊ’u‚ğæ“¾
    void Start()
    {
        player = FindObjectOfType<Player>();
        FirstPos = BackGround.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y, -10); //XÀ•W‚ª0ˆÈ‰º‚È‚çƒJƒƒ‰‚ğˆÚ“®‚³‚¹‚È‚¢
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10); //ƒJƒƒ‰‚ğƒvƒŒƒCƒ„[‚É’Ç]‚³‚¹‚é
        }
        BackGround.transform.position = (transform.position / 1.5f) + FirstPos; //”wŒi‚É“®‚«‚ğ—^‚¦‚é
    }
}
