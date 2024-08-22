using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] TextMeshProUGUI scoreTmp;
    [SerializeField] Score baseScore;

    [SerializeField] int totalScore;

    public void Init()
    {
        Instance = this;
    }

    public void AddScore(int score, Vector2 scorePos)
    {
        Score scoreObject = Instantiate(baseScore);
        scoreObject.transform.position = scorePos;
        scoreObject.Active(score); 

        totalScore += score;
        scoreTmp.text = totalScore.ToString();
    }

    internal void AddBonus(float bonusValue, Vector3 position)
    {
 //       throw new NotImplementedException();
    }

    internal void ResetBonus()
    {
//        throw new NotImplementedException();
    }
}
