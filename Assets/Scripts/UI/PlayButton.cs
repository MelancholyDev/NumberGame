using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject.FindWithTag("MainMenuManager").GetComponent<MainMenuManager>().ShowlevelSelect();
        
    }
}
