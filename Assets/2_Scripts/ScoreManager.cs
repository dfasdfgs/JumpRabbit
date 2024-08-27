using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] TextMeshProUGUI scoreTmp;
    [SerializeField] TextMeshProUGUI bonusTmp;
    [SerializeField] Score baseScore;

    [SerializeField] int totalScore;
    [SerializeField] float totalbonus;

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

    internal void AddBonus(float bonus, Vector3 position)
    {
        totalbonus += bonus; 
        bonusTmp.text = totalbonus.ToPersentStiring();
    }

    internal void ResetBonus()
    {
        totalbonus = 0;
        bonusTmp.text = totalbonus.ToPersentStiring();
    }
}
