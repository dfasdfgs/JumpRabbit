using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshPro tmp;

    private void Awake()
    {
        tmp = GetComponentInChildren<TextMeshPro>();
    }

    public void Active(string score, Color color)
    {
        tmp.text = score.ToString();
        tmp.color = color;

    }

    public void Deactive()
    {
        Destroy(gameObject);
    }
}
