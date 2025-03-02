using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject Player1;
    public GameObject Player2;
    public GameState currentGameState = GameState.menu;
    public GameObject MenuPanel;

    public GameObject EndPanel;
    public GameObject EndMenu;

    GameObject BackgroundMusic;
    AudioSource backmusic;

    public enum GameState
    {
        menu,
        inGame,        
    }

    public enum PlayerTyap
    {
        Player1,
        Player2,
    }
    public PlayerTyap playerTyap = PlayerTyap.Player1;

    private void Awake()
    {
        instance = this;
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        backmusic = BackgroundMusic.GetComponent<AudioSource>();        
    }

    private void Start()
    {
        StartGame();
        Time.timeScale = 2.5f;
    }

    void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {

        }
        else if(newGameState == GameState.inGame)
        {

        }
        currentGameState = newGameState;
    }

    public void Resatart_Scene()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void GameClear()
    {
        SetGameState(GameState.menu);
        Time.timeScale = 0;
        EndMenu.SetActive(false);
        EndPanel.SetActive(true);
    }

    public void Menu()
    {
        SetGameState(GameState.menu);
        if (Time.timeScale == 0)
        {
            SetGameState(GameState.inGame);
            Time.timeScale = 1.7f;
            MenuPanel.SetActive(false);
            if(!backmusic.isPlaying)
            {
                backmusic.Play();
            }
        }
        else
        {
            Time.timeScale = 0;
            MenuPanel.SetActive(true);
            if(backmusic.isPlaying)
            {
                backmusic.Pause();
            }
        }
    }


    public void PlayerPoterIn()
    {
        playerTyap = PlayerTyap.Player2;
        Player2.gameObject.transform.position = Player1.gameObject.transform.position;        
        Player1.gameObject.SetActive(false);
        Player2.gameObject.SetActive(true);
    }

    public void PlayerPoterOut()
    {
        playerTyap = PlayerTyap.Player1;
        Player1.gameObject.transform.position = Player2.gameObject.transform.position;
        Player1.gameObject.transform.rotation = Quaternion.identity;
        Player1.gameObject.GetComponent<Player>().targetRot = Quaternion.identity;
        Player1.gameObject.SetActive(true);
        Player2.gameObject.SetActive(false);
        
    }
}
