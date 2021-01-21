using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image blackFade;
    
    [SerializeField]
    private float fadeLenght;
    
    // Start is called before the first frame update
    void Start()
    {
        blackFade.gameObject.SetActive(true);
        FadeInEffect();
    }

    void FadeInEffect()
    {
        blackFade.CrossFadeAlpha(0, fadeLenght, false);
    }

    public void FadeOutEffect(){
        blackFade.CrossFadeAlpha(1, fadeLenght, false);
    }
}
