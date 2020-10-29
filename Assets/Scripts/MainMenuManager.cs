using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenuUI;
    [SerializeField] GameObject Settings;
    [SerializeField] GameObject levelSelect;
    [SerializeField] GameObject PlayButton;



    public void StartGameWithGameMode(string gamemode)
    {
        GameManager.ingamemanager.SetGameMode(gamemode);
        GameManager.fader.LoadSceneWithFade("Game");
    }

    public void ShowMainMenuUI()
    {
        MainMenuUI.SetActive(true);
        PlayButton.SetActive(true);
        Settings.SetActive(false);
        levelSelect.SetActive(false);
    }

    public void ShowSettings()
    {
        MainMenuUI.SetActive(false);
        PlayButton.SetActive(false);
        Settings.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void ShowlevelSelect()
    {
        MainMenuUI.SetActive(false);
        PlayButton.SetActive(false);
        Settings.SetActive(false);
        levelSelect.SetActive(true);
    }
}
