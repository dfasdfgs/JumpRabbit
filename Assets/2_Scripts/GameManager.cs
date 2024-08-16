using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlatformManager platformManager;
    [SerializeField] CameraManager cameraManager;

    private void Awake()
    {
        player.Init();
        platformManager.Init();
        cameraManager.Init();
    }

    private void Start()
    {
        platformManager.Active();
    }
}
