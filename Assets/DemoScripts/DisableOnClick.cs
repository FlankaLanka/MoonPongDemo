using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DisableOnClick : MonoBehaviour
{
    private GameObject cur;
    [SerializeField] private GameObject StoryScreen;
    [SerializeField] private Flowchart flowchart;
    [SerializeField] private GameManager gm;

    private void Start()
    {
        cur = this.gameObject;
    }

    public void DisableClick()
    {
        if(gm.canStory)
        {
            StoryScreen.SetActive(true);
            flowchart.SetBooleanVariable("StartReady", true);
        }
        cur.SetActive(false);
    }
}
