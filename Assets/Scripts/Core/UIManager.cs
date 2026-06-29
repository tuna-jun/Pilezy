using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text goalText;
    [SerializeField] private TMP_Text dockText;
    [SerializeField] private TMP_Text resultText;

    public void UpdateGoals(List<GoalEntry> goals)
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine("Goals");

        for(int i = 0; i < goals.Count; i++)
        {
            GoalEntry goal = goals[i];
            builder.AppendLine(goal.ItemData.DisplayName + ":" + goal.CurrentCount + "/" + goal.RequiredCount);
        }

        goalText.text = builder.ToString();
    }

    public void UpdateDockCount(int currentCount, int maxCount)
    {
        dockText.text = "Dock: " + currentCount + "/" + maxCount;
    }

    public void ShowWin()
    {
        resultText.text = "WIN";
        resultText.gameObject.SetActive(true);
    }

    public void ShowLose()
    {
        resultText.text = "LOSE";
        resultText.gameObject.SetActive(true);
    }

    public void HideResult()
    {
        resultText.text = "";
        resultText.gameObject.SetActive(false);
    }
}
