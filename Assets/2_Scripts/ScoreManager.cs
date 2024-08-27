using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private struct ScoreData
    {
        public string str;
        public Color color;
        public Vector2 pos;
    }

    public static ScoreManager Instance;
    [SerializeField] TextMeshProUGUI scoreTmp;
    [SerializeField] TextMeshProUGUI bonusTmp;
    [SerializeField] Score baseScore;
    private List<ScoreData> scoreDataList = new List<ScoreData>();

    [SerializeField] int totalScore;
    [SerializeField] float totalBonus;

    public void Init()
    {
        Instance = this;
        StartCoroutine(OnScoreCor());
    }

    private IEnumerator OnScoreCor()
    {
        while (true)
        {
            if (scoreDataList.Count > 0)
            {
                ScoreData data = scoreDataList[0];

                Score scoreobj = Instantiate<Score>(baseScore);
                scoreobj.transform.position = data.pos;
                scoreobj.Active(data.str, data.color);

                scoreDataList.RemoveAt(0);
                yield return new WaitForSeconds(DataBaseManater.Instance.ScorePopinterval);
            }
            else
            {
                yield return null; //���������� ����ɶ����� ��
            }
        }
    }

    public void AddScore(int score, Vector2 scorePos)
    {
        //�ִ�
        scoreDataList.Add(new ScoreData()
        {
            str = score.ToString(),
            color = DataBaseManater.Instance.ScoreColor,
            pos = scorePos
        });

        //canvas
        totalScore += score;
        scoreTmp.text = totalScore.ToString();
    }

    internal void AddBonus(float bonus, Vector3 position)
    {
        scoreDataList.Add(new ScoreData()
        {
            str = "Bonus " + bonus.ToPersentStiring(),
            color = DataBaseManater.Instance.BonusColor,
            pos = position
        });

        //canvas
        totalBonus += bonus;
        bonusTmp.text = totalBonus.ToPersentStiring();
    }



    internal void ResetBonus()
    {
        totalBonus = 0;
        bonusTmp.text = totalBonus.ToPersentStiring();
    }
}

