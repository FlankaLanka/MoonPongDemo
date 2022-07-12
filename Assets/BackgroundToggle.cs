using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundToggle : MonoBehaviour
{
    [SerializeField] private GameObject backgroundInGame;
    [SerializeField] private GameObject backgroundInStart;
    [SerializeField] private GameObject backgroundInStory;
    [SerializeField] private GameObject backgroundInDemo;
    private bool allowBackground = false;

    public void ToggleBackground()
    {
        allowBackground = !allowBackground;
        if(allowBackground)
        {
            backgroundInGame.SetActive(true);
            backgroundInStart.SetActive(true);
            backgroundInStory.SetActive(true);
            backgroundInDemo.SetActive(true);
        }
        else
        {
            backgroundInGame.SetActive(false);
            backgroundInStart.SetActive(false);
            backgroundInStory.SetActive(false);
            backgroundInDemo.SetActive(false);
        }
    }
}
