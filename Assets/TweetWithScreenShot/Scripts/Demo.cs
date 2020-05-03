using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour {

    public void Tweet(){
        StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("WebGLのTweetSampleです"));
    }
}
