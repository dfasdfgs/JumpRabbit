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

        int a = 123456;
        Debug.Log("Extension Test int : " + a.ToString());

        float b = 123456.789f;
        Debug.Log("Extension Test int : " + b.ToString());
    }
}
