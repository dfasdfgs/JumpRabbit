using UnityEngine;

public class Player : MonoBehaviour
{
    private float JumpPower = 1f;
    private Rigidbody2D rigd;
    private Animator anim;
    private Platform landedPlatform;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Init()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("StateID", 1);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            JumpPower += DataBaseManater.Instance.JumpPowerInc;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rigd.AddForce(Vector2.one * JumpPower);
            JumpPower = 0;

            anim.SetInteger("StateID", 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetInteger("StateID", 0);
        rigd.velocity = Vector2.zero;


        CameraManager.instance.OnFollow(transform.position);

        if(collision.transform.parent.TryGetComponent(out Platform platform))
        {
            ScoreManager.Instance.AddScore(platform.Score, platform.transform.position);

            if (landedPlatform != platform) ScoreManager.Instance.AddBonus(DataBaseManater.Instance.BonusValue, transform.position);
            else ScoreManager.Instance.ResetBonus();

            landedPlatform = platform;
        }
    }
}
