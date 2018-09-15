# TweetWithScreenShotInWebGL
UnityのWebGLでサムネイル付き画像ツイートをするサンプルです

TweetManagerをアタッチしたGameObjectをhierarchyに置き、InspectorでImgurのClientKeyを設定し、

```
StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("Hello!"));
```

という風に呼び出します
