using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    [SerializeField] SpriteRenderer bgSrdr;
    float cameraWidth;

    public void Init()
    {
        instance = this;
        Camera camera = Camera.main;
        float cameraHeight = camera.orthographicSize * 2f;
        cameraWidth = cameraHeight * camera.aspect;
    }

    public void OnFollow(Vector2 targerPos)
    {
        StartCoroutine(OnFollowCor(targerPos));
    }
    private IEnumerator OnFollowCor(Vector2 targerPos)
    {
        while (0.1 < Vector3.Distance(transform.position, targerPos))
        {
            transform.position = Vector3.Lerp(transform.position, targerPos, Time.deltaTime * DataBaseManager.Instance.followSpeed);

            float bgRightX = bgSrdr.transform.position.x + bgSrdr.size.x;
            float cameraRightX = Camera.main.transform.position.x + cameraWidth / 2;

            if (bgRightX <= cameraRightX)
            {
                bgSrdr.size = new Vector2(bgSrdr.size.x + cameraWidth, bgSrdr.size.y);
            }

            yield return null;
        }
    }
}
