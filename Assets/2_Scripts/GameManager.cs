using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlatformManager platformManager;
    [SerializeField] CameraManager cameraManager;
    [SerializeField] DataBaseManater dataBasemanater;
    [SerializeField] ScoreManager scoreManager;

    private void Awake()
    {
        dataBasemanater.Init();

        player.Init();
        platformManager.Init();
        cameraManager.Init();
        scoreManager.Init();
    }

    private void Start()
    {
        platformManager.Active();
    }
}
