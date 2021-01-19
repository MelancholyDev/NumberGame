using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour, IManager
{
    [HideInInspector]public Tile[] tiles;
    public Dictionary<string, AbstractGameMode> GM=new Dictionary<string, AbstractGameMode>();
    public AbstractGameMode curGm;
    public int currentRound { get; private set; }
    public int health { get; private set; }
    public float score { get; private set; }
    public float timer { get; private set; }



    //Создаёт экземпляры каждого режима игры
    public void createGameModeInstanties()
    {
        GM.Add("3x3",new GameMode3x3());
        GM.Add("4x4", new GameMode4x4());
        GM.Add("s3x3", new GameModeSN3x3());
        GM.Add("s4x4", new GameModeSN4x4());
    }

    //Сбрасывает параметры до начального значения и выставляет таймеро в зависимости от переданного значения
    public void restartAllParameters()
    {
        timer =curGm.timer;
        score = 0;
        health = 3;
        currentRound = 1;
    }

    //Выставляет GameMode и загружает карту
    public void loadGame(string name)
    {
        curGm = GM[name];
        GameManager.fader.LoadSceneWithFade("Game");
    }

    public void startGame()
    {
        curGm.prepareBoard();
        StartCoroutine(game());
    }

    IEnumerator game()
    {
        yield return new WaitForSeconds(1);
    }

    //Уменьшает количество хп и вызывает в InGameUIManager анимацию сердечка
    public void Damage()
    {
        health--;
        GameManager.ingameuimanager.Damage(health);
    }
    
    public void UpdateLevel()
    {
        score += ++currentRound - 1;
        timer += 5;
    }

    public void Lose()
    {
      
    }


    public void Pause()
    {  
    }
    

    //Загружает словарь
    public void StartManager()
    {
        createGameModeInstanties();;
    }

}
