using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject levelSelect;



    public void StartGameWithGameMode(string gamemode)
    {
       // GameManager.ingamemanager.setGameMode(gamemode);
        GameManager.fader.LoadSceneWithFade("Game");
    }

    public void ShowlevelSelect()
    {
        Instantiate(levelSelect);
    }
}
