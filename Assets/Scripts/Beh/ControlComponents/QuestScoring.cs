using TMPro;
using UnityEngine;

namespace JernJam
{
  /* Helps to calculate the total score. */
  public class QuestScoring : MonoBehaviour
  {

    private int totalScore;
    public int maxScore;
    public int allItemsCount;
    public int collectedItemsCount;
    
    [SerializeField] public int relevantQuestScore = 10;
    [SerializeField] public int garbageScore = 1;
    [SerializeField] public string correctActionHint = "Items fits in the box, packed and ready for transportation";
    [SerializeField] public string wrongActionHint = "Feels wrong";
    [SerializeField] public string wastedWorld = "Wasted";

    [SerializeField] private TextMeshProUGUI _scoreField;
    [SerializeField] private GameObject _winPanel;
    
    public static QuestScoring instance { get; private set;  }

    private void Awake()
    {
      instance = this;
      totalScore = 0;
      collectedItemsCount = 0;
      _winPanel.SetActive(false);
    }

    public int getTotalScore()
    {
      return totalScore;
    }

    public void ScoreItem(int score)
    {
      totalScore += score;
      collectedItemsCount += 1;
      updateScoreUI();
      if (collectedItemsCount == allItemsCount)
      {
        winUI();
      }
      
    }

    public void updateScoreUI()
    {
      _scoreField.SetText(getTotalScore() + " / " + maxScore);
    }

    private void winUI()
    {
      _winPanel.SetActive(true);
    }
    

    
  }
}