using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    private GameObject playButton;
    void Start()
    {
        playButton = GameObject.FindWithTag("PlayButton");
        initializeButtons();
        try
        {
            playButton.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.Log("Кнопка включения выбора уровней не найдена!");
        }
    }

    private void initializeButtons()
    {
        buttons[0].onClick.AddListener(()=>GameManager.ingamemanager.loadGame("3x3"));
        buttons[1].onClick.AddListener(()=>GameManager.ingamemanager.loadGame("4x4"));
        buttons[2].onClick.AddListener(()=>GameManager.ingamemanager.loadGame("s3x3"));
        buttons[3].onClick.AddListener(()=>GameManager.ingamemanager.loadGame("s4x4"));
    }

    public void closeLevelSelect()
    {
        try
        {
            playButton.SetActive(true);
        }
        catch (Exception e)
        {
            Debug.Log("Кнопка включения не инициализирована!");
        }
        Destroy(gameObject);
    }

}
