﻿using UnityEngine;

namespace JernJam
{
  /* Helps to calculate the total score. */
  public class QuestScoring : MonoBehaviour
  {
    public delegate void AfterScoreUpdate();
    public static event AfterScoreUpdate onScoreUpdate;
    private int totalScore;
    [SerializeField] public int relevantQuestScore = 10;
    [SerializeField] public int garbageScore = 1;
    [SerializeField] public string correctActionHint = "Items fits in the box, packed and ready for transportation";
    [SerializeField] public string wrongActionHint = "Feels wrong";
    [SerializeField] public string wastedWorld = "Wasted";

    public static QuestScoring instance { get; private set;  }

    private void Awake()
    {
      instance = this;
      totalScore = 0;
    }

    public int getTotalScore()
    {
      return totalScore;
    }

    public void ScoreItem(int score)
    {
      totalScore += score;
      onScoreUpdate?.Invoke();
    }
    

    
  }
}