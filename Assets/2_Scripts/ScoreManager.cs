using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] TextMeshProUGUI scoreTmp;

    [SerializeField] int totalScore;

    public void Init()
    {
        Instance = this;
    }

    public void AddScore(int score)
    {
        totalScore += score;
        scoreTmp.text = totalScore.ToString();
    }
}
