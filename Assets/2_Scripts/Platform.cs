using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D col;

    public float HalfSizeX => col.size.x * 0.5f;


    private void Awake()
    {
        col = GetComponentInChildren<BoxCollider2D>();
    }

    public void Active(Vector2 pos)
    {
        transform.position = pos;
    }
}
