using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour
{
    [SerializeField]GameObject MainMenuManager;

    void OnMouseDown()
    {
        MainMenuManager.GetComponent<MainMenuManager>().ShowlevelSelect();
        Debug.Log("PLAY");
    }
}
