using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { MainMenu, InBattle, Paused}
    public GameState CurrentState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //CurrentState = GameState.MainMenu;
        //SceneManager.LoadScene("MainMenu");
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattle()
    {
        CurrentState = GameState.InBattle;
        SceneManager.LoadScene("BattleScene");
    }
}
