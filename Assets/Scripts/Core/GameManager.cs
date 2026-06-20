using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    }
    
    public void LoseGame()
    {
        if (isGameOver)
        {
            return;
        }
        isGameOver = true;
        Debug.Log("Lose");
    }
}
