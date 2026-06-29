using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    private bool isGameOver;
    public bool IsGameOver => isGameOver;

    public void WinGame()
    {
        if (isGameOver)
        {
            return;
        }
        isGameOver = true;
        Debug.Log("Win");
        uiManager.ShowWin();
    }
    
    public void LoseGame()
    {
        if (isGameOver)
        {
            return;
        }
        isGameOver = true;
        Debug.Log("Lose");
        uiManager.ShowLose();
    }
}
