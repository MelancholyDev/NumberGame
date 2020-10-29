using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    bool firstfade = true;
    Image faderSprite;
    private void Awake()
    {
        GameManager.fader = this;
        faderSprite = GetComponent<Image>();
        
    }
    private void Update()
    {
        if (firstfade) {
            if(faderSprite.color.a > 0)
                faderSprite.color = new Color(0, 0, 0, faderSprite.color.a - 0.02f);
            if (faderSprite.color.a <= 0)
            {
                faderSprite.raycastTarget = false;
                firstfade = false;
            }
        }
        
    }

    public void LoadSceneWithFade(string Scene)
    {
        StartCoroutine(Fade(Scene));

    }
    IEnumerator Fade(string Scene)
    {
        faderSprite.raycastTarget = true;
        while (faderSprite.color.a < 1)
        {
            faderSprite.color = new Color(0, 0, 0, faderSprite.color.a + 0.02f);
            yield return new WaitForEndOfFrame();
        }
        GameManager.ingameuimanager.SetActiveFalseForUI();

        SceneManager.LoadScene(Scene);
        while (faderSprite.color.a > 0)
        {
            faderSprite.color = new Color(0, 0, 0, faderSprite.color.a - 0.02f);
            yield return new WaitForEndOfFrame();
        }
        faderSprite.raycastTarget = false;
    }

}
