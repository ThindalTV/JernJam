using System;
using TMPro;
using UnityEngine;

namespace JernJam
{
  public class QuestDescriptionDisplay : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _textMeshProField;
    [SerializeField] private string _defaultQuestString = "Another one's treasure";

    public static QuestDescriptionDisplay instance { get; private set;  }

    private void Awake()
    {
      instance = this;
    }
    
    private void Start()
    {
      UpdateQuestText(_defaultQuestString);
    }

    public void UpdateQuestText(string newQuestText)
    {
      if (newQuestText == "")
      {
        newQuestText = "Something ancient and useless";
      }
      _textMeshProField.SetText(newQuestText);
    }

    public void HideQuestText()
    {
      this.enabled = false;
    }
    
  }
}