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
    [SerializeField] float totalBonus;

    public void Init()
    {
        Instance = this;
    }

    public void AddScore(int score, Vector2 scorePos)
    {
        Score scoreObject = Instantiate(baseScore);
        scoreObject.transform.position = scorePos;
        scoreObject.Active(score.ToString(), DataBaseManater.Instance.ScoreColor); 

        totalScore += score;
        scoreTmp.text = totalScore.ToString();
    }

    internal void AddBonus(float bonus, Vector3 position)
    {
        Score scoreObject = Instantiate(baseScore);
        scoreObject.transform.position = position;

        string str = "Bonus " + bonus.ToPersentStiring();
        scoreObject.Active(str, DataBaseManater.Instance.BonusColor);

        totalBonus += bonus; 
        bonusTmp.text = totalBonus.ToPersentStiring();
    }

    internal void ResetBonus()
    {
        totalBonus = 0;
        bonusTmp.text = totalBonus.ToPersentStiring();
    }
}
