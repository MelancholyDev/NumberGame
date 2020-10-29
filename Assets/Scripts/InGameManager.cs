using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour, IManager
{
    [SerializeField] bool devMode = true;
    [HideInInspector]public Tile[] tiles;
    public Dictionary<string, AbstractGameMode> GM=new Dictionary<string, AbstractGameMode>();
    [HideInInspector] public Initializator initializer;
    bool gameStarted = false;
    public int currentRound { get; private set; }
    public int health { get; private set; }
    public float score { get; private set; }
    public float timer { get; private set; }
    public float increase { get; private set; }
    private bool isPaused = false;



    public void CreateGameModeInstanties()
    {
        GM.Add("3x3",new GameMode3x3());
        GM.Add("4x4", new GameMode4x4());
        GM.Add("s3x3", new GameModeSN3x3());
        GM.Add("s4x4", new GameModeSN4x4());
    }

    public void RestartAllParameters(int timer)
    {

        this.timer = timer;
        score = 0;
        health = 3;
        currentRound = 1;
    }

    //Выставляет GameMode
    public void SetGameMode(string name)
    {
        initializer.CurGM = GM[name];
    }

    public void Damage()
    {
        health--;
        GameManager.ingameuimanager.Damage(health);
    }

    public void Update()
    {

        if(gameStarted && !isPaused)
        {
            if (health == 0 | timer <= 0)
            {
                Lose();
            }
            timer -= Time.deltaTime;
            GameManager.ingameuimanager.timer.text = timer.ToString().Substring(0, 4);
            GameManager.ingameuimanager.score.text = score.ToString();
            if (initializer.CurGM.CompleteLevel())
                UpdateLevel();
        }
        
    }

    public void UpdateLevel()
    {
        score += ++currentRound - 1;
        timer += 5;
        initializer.CurGM.ShuffleArrayOfTiles();
    }

    public void Lose()
    {
        Destroy(initializer.CurGM.instantinatedBoard);
        gameStarted = false;
        bool flag = CheckForNewRecord();
        GameManager.ingameuimanager.ShowEndGame(flag);
    }

    public bool CheckForNewRecord()
    {
        if (score > PlayerPrefs.GetFloat("Record " + initializer.CurGM.name, 0))
        {
            PlayerPrefs.SetFloat("Record " + initializer.CurGM.name, score);
            return true;
        }

        return false;
    }

    public void StartGame()
    {
        if(initializer.CurGM.instantinatedBoard!=null)
            Destroy(initializer.CurGM.instantinatedBoard);
        initializer.CurGM.SetRecord(PlayerPrefs.GetFloat("Record " + initializer.CurGM.name, 0));
        initializer.CurGM.RestartAllParameters();
        initializer.IinitializeAndShow();
        initializer.CurGM.ShuffleArrayOfTiles();
        initializer.CurGM.CalculateNextCorrectId(true);
        GameManager.ingameuimanager.ShowGame();
        GameManager.ingameuimanager.Record.text = initializer.CurGM.GetRecord().ToString();
        gameStarted = true;
        isPaused = false;

    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused = false;
    }

    //загружает словарь
    public void StartManager()
    {
        
        initializer = GetComponent<Initializator>();
        CreateGameModeInstanties();
    }

}
