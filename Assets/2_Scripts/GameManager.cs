using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Player player;
    [SerializeField] PlatformManager platformManager;
    [SerializeField] CameraManager cameraManager;
    [SerializeField] DataBaseManager dataBasemanater;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] SoundManager soundManager;
    [SerializeField] GameObject retryBtnObj;




    private void Awake()
    {
        instance = this;

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
        scoreManager.Active();
        soundManager.PlayBgm(Define.BgmType.Main);
    }
    public void CallBtnRetry()
    {
        SceneManager.LoadScene(0);
    }
    public void OnGameOver()
    {
        retryBtnObj.SetActive(true);
    }
}
