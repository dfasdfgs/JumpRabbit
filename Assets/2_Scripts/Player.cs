using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpPower = 1f;
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

            Define.SfxType sfxType = Random.value < 0.5f ? Define.SfxType.Jump1 : Define.SfxType.Jump2;
            SoundManager.Instance.PlaySfx(sfxType);

            Effect effect = Instantiate(DataBaseManater.Instance.effect);
            effect.Active(transform.position);
        }

        if(transform.position.y < DataBaseManater.Instance.GameOverY)
        {
            GameManager.instance.OnGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetInteger("StateID", 0);
        rigd.velocity = Vector2.zero;


        CameraManager.instance.OnFollow(transform.position);

        if (collision.transform.TryGetComponent(out Platform platform))
        {
            platform.OnLandingAnimation();

            if (landedPlatform == null)
            {
                landedPlatform = platform;
                return;
            }
                if (landedPlatform != platform) ScoreManager.Instance.AddBonus(DataBaseManater.Instance.BonusValue, transform.position);
                else ScoreManager.Instance.ResetBonus(transform.position);

                ScoreManager.Instance.AddScore(platform.Score, platform.transform.position);

            landedPlatform = platform;
        }
    }
}
