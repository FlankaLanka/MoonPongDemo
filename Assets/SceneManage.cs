using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

    public void LaunchMulti()
    {
        SceneManager.LoadScene("PongMulti");
    }

    public void LaunchSingle()
    {
        SceneManager.LoadScene("PongSingle");
    }

    public void LaunchStory()
    {
        SceneManager.LoadScene("Story");
    }

    public void LaunchEditor()
    {
        SceneManager.LoadScene("Pong");
    }
}
