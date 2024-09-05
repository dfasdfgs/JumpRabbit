using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D col;
    private Animation anim;
    [SerializeField] int score;

    public float HalfSizeX => col.size.x * 0.5f;
    public int Score => score;


    private void Awake()
    {
        col = GetComponentInChildren<BoxCollider2D>();
        anim = GetComponent<Animation>();
    }

    public void Active(Vector2 pos, bool isFirstFrame)
    {
        transform.position = pos;

        if (isFirstFrame)
            return;

        if (Random.value < DataBaseManater.Instance.itemSpawnPer)
        {
            Item item = Instantiate<Item>(DataBaseManater.Instance.baseItem);
            item.Active(transform.position, HalfSizeX);
        }
    }

    public void OnLandingAnimation()
    {
        anim.Play();
    }
}
