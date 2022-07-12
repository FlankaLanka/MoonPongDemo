using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnime : MonoBehaviour
{
    [SerializeField] private GameObject Animes;

    public void EnableAnime()
    {
        if(!Animes.activeInHierarchy)
        {
            Animes.SetActive(true);
            Animes.GetComponent<AudioSource>().Play();
        }
        else
        {
            Animes.SetActive(false);
        }
    }
}
