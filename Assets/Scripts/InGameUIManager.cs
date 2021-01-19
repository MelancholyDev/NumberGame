using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour,IManager
{
    [SerializeField]Canvas Game;
    [SerializeField] Canvas PauseGame;
    [SerializeField]Canvas EndGame;
    [SerializeField] Animator[] hearts;
    [SerializeField] Button pause;
    

    [SerializeField] Text finalScore;
    [SerializeField] Text congratulations;
    [SerializeField] Button restartButton;

    //initialize fields
    public void StartManager()
    {
    }
    
    //Возвращает все сердечки в исходное состояние
    void RestartHearts()
    {
        for(int i=0;i<3;i++)
        {
            hearts[i].SetBool("Damage",false);
        }
    }
    
    //get damage from miss
    public void Damage(int health)
    {
        if(health>=0 & health<=2)
        hearts[health].SetBool("Damage",true);
    }
    
    public void ShowEndGame(bool flag = false)
    {
        EndGame.gameObject.SetActive(true);
        Game.gameObject.SetActive(false);
        PauseGame.gameObject.SetActive(false);
        if (flag)
            NewRecordAnim();
                //FinalScore.text = score.text;
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
