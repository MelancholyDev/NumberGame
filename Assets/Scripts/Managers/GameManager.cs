using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Fader fader;
    public static InGameManager ingamemanager;
    public static SoundManager soundmanager;
    public static InGameUIManager ingameuimanager;


    //Инициализирует поля,вызывает стартовые методы и запрещает уничтожение объекта
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        InitStaticFields();
        InitializeAllManagers();
    }
    //Иницицализирует статические поля мэнэджера,чтобы к ниму всегда был доступ
    void InitStaticFields()
    {
        ingamemanager = GetComponent<InGameManager>();
        soundmanager = GetComponent<SoundManager>();
        ingameuimanager = GetComponent<InGameUIManager>();
    }
    //Вызывает функцию запсука у всех мэнэджеров
    void InitializeAllManagers()
    {
        ingamemanager.StartManager();
        soundmanager.StartManager();
        ingameuimanager.StartManager();
    }


}
