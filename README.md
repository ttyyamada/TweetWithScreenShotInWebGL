# TweetWithScreenShotInWebGL
UnityのWebGLでサムネイル付き画像ツイートをするサンプルです
おそらくモバイルや他のいろんな環境でも動くと思いますが動作はあまり確認していません

導入方法はこちらにとてもわかりやすいものを書いていただきました！
https://unity-senpai.hatenablog.com/entry/2019/07/07/130111

TweetManagerをアタッチしたGameObjectをhierarchyに置き、InspectorでImgurのClientKeyを設定し、

```
StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("Hello!"));
```

という風に呼び出します

## アップデート情報
### 2021/09/22

urlの設定をInspectorからできるようにしました

これにより、urlと一緒に画像付きツイートをできるようになります

ただし、ツイートする画面では画像ではなく、リンク先のサムネイル表示になってしまいます

urlを設定しなければ画像が表示されます

非推奨のメソッドを使っていたため、WebGLのツイート方法を変更しました

https://github.com/naichilab/unityroom-tweet
こちらの

`OpenWindow.jslib`

をそのままお借りしています（許諾済み）
