using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    Image faderSprite;
    private void Awake()
    {
        GameManager.fader = this;
        faderSprite = GetComponent<Image>();
        firstFade();
    }

    private void firstFade()
    {
        StartCoroutine(FadeWithoutLoadScene());
    }

    public void LoadSceneWithFade(string Scene)
    {
        StartCoroutine(FadeScene(Scene));
    }
    IEnumerator FadeScene(string Scene)
    {
        faderSprite.raycastTarget = true;
        while (faderSprite.color.a < 1)
        {
            faderSprite.color = new Color(0, 0, 0, faderSprite.color.a + 0.02f);
            yield return new WaitForEndOfFrame();
        }
        //GameManager.ingameuimanager.SetActiveFalseForUI();

        SceneManager.LoadScene(Scene);
        while (faderSprite.color.a > 0)
        {
            faderSprite.color = new Color(0, 0, 0, faderSprite.color.a - 0.02f);
            yield return new WaitForEndOfFrame();
        }
        faderSprite.raycastTarget = false;
    }
    
    IEnumerator FadeWithoutLoadScene()
    {
        faderSprite.color=new Color(0, 0, 0, 1);
        while (faderSprite.color.a > 0)
        {
            faderSprite.color = new Color(0, 0, 0, faderSprite.color.a - 0.02f*Time.deltaTime*40);
            yield return new WaitForEndOfFrame();
        }
        faderSprite.raycastTarget = false;
    }

}
