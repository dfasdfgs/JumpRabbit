using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpPower = 1f;
    private Platform landedPlatform;

    private Rigidbody2D rigd;
    private Animator anim;
    private bool isJumpReady;

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
        if (isJumpReady == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumpReady = true;
                anim.SetInteger("StateID", 1);
            }
        }
        else
        {
            JumpPower += DataBaseManager.Instance.JumpPowerInc * Time.deltaTime;
            if(JumpPower> DataBaseManager.Instance.maxJumpPower)
            {
                SetIdleState();
                return;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumpReady = false;
                if (JumpPower < DataBaseManager.Instance.minJumpPower)
                {
                    SetIdleState();
                }
                else
                {
                    rigd.AddForce(Vector2.one * JumpPower);
                    JumpPower = 0;

                    anim.SetInteger("StateID", 2);

                    Define.SfxType sfxType = Random.value < 0.5f ? Define.SfxType.Jump1 : Define.SfxType.Jump2;
                    SoundManager.Instance.PlaySfx(sfxType);

                    Effect effect = Instantiate(DataBaseManager.Instance.effect);
                    effect.Active(transform.position);
                }
            }
        }




        if (transform.position.y < DataBaseManager.Instance.GameOverY)
        {
            GameManager.instance.OnGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetIdleState();

        CameraManager.instance.OnFollow(transform.position);

        if (collision.transform.TryGetComponent(out Platform platform))
        {
            PlatformManager.Instance.LandingPlatformNum = platform.number;
            platform.OnLandingAnimation();

            if (landedPlatform == null)
            {
                landedPlatform = platform;
                return;
            }
            if (landedPlatform != platform) ScoreManager.Instance.AddBonus(DataBaseManager.Instance.BonusValue, transform.position);
            else ScoreManager.Instance.ResetBonus(transform.position);

            ScoreManager.Instance.AddScore(platform.Score, platform.transform.position);

            landedPlatform = platform;
        }
    }

    private void SetIdleState()
    {
        anim.SetInteger("StateID", 0);
        rigd.velocity = Vector2.zero;
        JumpPower = 0;
        isJumpReady = false;
    }
}
