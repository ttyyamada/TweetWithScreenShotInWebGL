# TweetWithScreenShotInWebGL
UnityのWebGLでサムネイル付き画像ツイートをするサンプルです

導入方法はこちらにとてもわかりやすいものを書いていただきました！
https://unity-senpai.hatenablog.com/entry/2019/07/07/130111

TweetManagerをアタッチしたGameObjectをhierarchyに置き、InspectorでImgurのClientKeyを設定し、

```
StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("Hello!"));
```

という風に呼び出します
