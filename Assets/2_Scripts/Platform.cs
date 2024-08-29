using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D col;
    [SerializeField] int score;

    public float HalfSizeX => col.size.x * 0.5f;
    public int Score => score;


    private void Awake()
    {
        col = GetComponentInChildren<BoxCollider2D>();
    }

    public void Active(Vector2 pos)
    {
        transform.position = pos;

        if (Random.value < DataBaseManater.Instance.itemSpawnPer)
        {
            Item item = Instantiate<Item>(DataBaseManater.Instance.baseItem);
            item.Active(transform.position, HalfSizeX);
        }
    }

    internal void OnLanding()
    {
        ScoreManager.Instance.AddScore(score, transform.position);
    }
}
