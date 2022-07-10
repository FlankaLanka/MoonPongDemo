using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public enum TweenBehavior
    {
        a,
        aa,
        aaa
    }

    public TweenBehavior s;
    // Start is called before the first frame update
    void Start()
    {
        s = TweenBehavior.a;
    }



    public void ChangeBehavor(int val)
    {
        if(val == 0)
        {
            Debug.Log("0");
        }
        else if (val == 1)
        {
            Debug.Log("1");
        }
        else if (val == 2)
        {
            Debug.Log("2");
        }
    }
}