using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlatformManager platformManager;
    [SerializeField] CameraManager cameraManager;
    [SerializeField] DataBaseManater dataBasemanater;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] SoundManager soundManager;

    private void Awake()
    {
        dataBasemanater.Init();

        player.Init();
        platformManager.Init();
        cameraManager.Init();
        scoreManager.Init();
        soundManager.Init();
    }

    private void Start()
    {
        platformManager.Active();
        soundManager.PlayBgm(Define.BgmType.Main);
    }
}
