using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour,IManager
{
    [SerializeField]Canvas Game;
    [SerializeField] Canvas PauseGame;
    //[SerializeField] Canvas UI;
    [SerializeField]Canvas EndGame;
    [SerializeField] Canvas Fader;

    [SerializeField] public Text timer;
    [SerializeField] public Text score;
    [SerializeField] public Text FinalScore;
    [SerializeField] public Text Record;
    [SerializeField] Animator[] hearts;
    [SerializeField] Button pause;
    

    [SerializeField] Text finalScore;
    [SerializeField] Text congratulations;
    [SerializeField] Button restartButton;

    public void StartManager()
    {
        PauseGame.gameObject.SetActive(false);
        EndGame.gameObject.SetActive(false);
        Game.gameObject.SetActive(false);
        //UI.gameObject.SetActive(true);
        Fader.gameObject.SetActive(true);
    }
    void RestartHearts()
    {
        for(int i=0;i<3;i++)
        {
            hearts[i].SetBool("Damage",false);
        }
    }
    public void Damage(int health)
    {
        if(health>=0 &health<=2)
        hearts[health].SetBool("Damage",true);
    }
    public void ShowGame()
    {
        Game.gameObject.SetActive(true);
        EndGame.gameObject.SetActive(false);
        PauseGame.gameObject.SetActive(false);
    }

    public void RestartGameCanvas()
    {
        timer.gameObject.SetActive(true);
        score.gameObject.SetActive(true);
        pause.gameObject.SetActive(true);
        RestartHearts();
    }
    public void ShowEndGame(bool flag = false)
    {
        EndGame.gameObject.SetActive(true);
        Game.gameObject.SetActive(false);
        PauseGame.gameObject.SetActive(false);
        if (flag)
            NewRecordAnim();
        FinalScore.text = score.text;
    }

    public void PauseGameFunc()
    {
        PauseGame.gameObject.SetActive(true);
        EndGame.gameObject.SetActive(false);
        Game.gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        PauseGame.gameObject.SetActive(false);
        EndGame.gameObject.SetActive(false);
        Game.gameObject.SetActive(true);
    }

    public void RestartEndGameCanvas()
    {
        finalScore.gameObject.SetActive(true);
        congratulations.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    public void ShowMenu()
    {
        EndGame.gameObject.SetActive(false);
        Game.gameObject.SetActive(false);
    }

    public void SetActiveFalseForUI()
    {
        PauseGame.gameObject.SetActive(false);
        EndGame.gameObject.SetActive(false);
        Game.gameObject.SetActive(false);
    } 

    public void LoadMainMenu()
    {
        GameManager.fader.LoadSceneWithFade("MainMenu");   
    }


    /////////////////////////////////////////////////////
    ////////////////////ANIMATIONS///////////////////////
    /////////////////////////////////////////////////////

    private void NewRecordAnim() { }

    public void CorrectTileAnim() { }

    public void WrongTileAnim() { }
}
