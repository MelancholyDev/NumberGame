﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReverseTimer : MonoBehaviour
{
    [SerializeField] bool DevMode=true;
    //Компонент,отвечающий за анимации таймера
    Animation anim;

    //Компонент,отвечающий за цифры на таймере
    Text text;

    //Инициализирует anim и text и запсукает таймер
    void Start()
    {
        anim = GetComponent<Animation>();
        text = GetComponent<Text>();
        StartCoroutine(BeginGame());
    }

    //Courotine таймера,анимация вылета и влета цифры поочередно меняют друг друга,параллельно меняя цифры на таймере.
    //После того,как таймер закончится,он запустит игру.
    IEnumerator BeginGame()
    {
        if (!DevMode)
        {
            int a = 3;
            if (text == null)
                text = GetComponent<Text>();
            text.text = a.ToString();
            while (a >= 0)
            {
                anim.Play("Out");
                while (anim.isPlaying)
                    yield return new WaitForEndOfFrame();
                a--;
                text.text = a.ToString();
                if (a >= 0)
                {
                    anim.Play("In");
                    while (anim.isPlaying)
                        yield return new WaitForEndOfFrame();
                }
            }
        }
        GameManager.ingamemanager.StartGame();
        if (DevMode)
            gameObject.SetActive(false);
        Debug.Log(1);
    }

}
