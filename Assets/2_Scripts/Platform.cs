using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D col;
    private Animation anim;
    public int number;

    [SerializeField] int score;

    public float HalfSizeX => col.size.x * 0.5f;
    public int Score => score;


    private void Awake()
    {
        col = GetComponentInChildren<BoxCollider2D>();
        anim = GetComponent<Animation>();
    }

    public void Active(Vector2 pos, int platformNumber)
    {
        transform.position = pos;
        number = platformNumber;

        if (platformNumber == 1)
            return;

        if (Random.value < DataBaseManager.Instance.itemSpawnPer)
        {
            Item item = Instantiate<Item>(DataBaseManager.Instance.baseItem);
            item.Active(transform.position, HalfSizeX);
        }
    }

    public void OnLandingAnimation()
    {
        anim.Play();
    }
}
