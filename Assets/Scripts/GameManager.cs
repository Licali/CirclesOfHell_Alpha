using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState { MainMenu, InBattle, Paused}
    public GameState CurrentState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBatle()
    {
        CurrentState = GameState.InBattle;
        SceneManager.LoadScene("BattleScene");
    }
}
