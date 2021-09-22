using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Xml.Linq;
using System;
#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace TweetWithScreenShot
{
    public class TweetManager : MonoBehaviour
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void OpenWindow(string url);
#endif
        private static TweetManager sinstance;
        public string[] hashTags;

        [SerializeField]
        private string clientID;

        public string ClientID
        {
            get
            {
                if (string.IsNullOrEmpty(clientID)) throw new Exception("ClientIDをセットしてください");
                return clientID;
            }
        }

        public static TweetManager Instance
        {
            get
            {
                if (sinstance == null)
                {
                    sinstance = FindObjectOfType<TweetManager>();
                    if (sinstance == null)
                    {
                        var obj = new GameObject(typeof(TweetManager).Name);
                        sinstance = obj.AddComponent<TweetManager>();
                    }
                }
                return sinstance;
            }
        }

        public static IEnumerator TweetWithScreenShot(string text)
        {
            yield return new WaitForEndOfFrame();
            var tex = ScreenCapture.CaptureScreenshotAsTexture();

            // imgurへアップロード
            string UploadedURL = "";

            UnityWebRequest www;

            WWWForm wwwForm = new WWWForm();
            wwwForm.AddField("image", Convert.ToBase64String(tex.EncodeToJPG()));
            wwwForm.AddField("type", "base64");

            www = UnityWebRequest.Post("https://api.imgur.com/3/image.xml", wwwForm);

            www.SetRequestHeader("AUTHORIZATION", "Client-ID " + Instance.ClientID);

            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Data: " + www.downloadHandler.text);
                XDocument xDoc = XDocument.Parse(www.downloadHandler.text);
                //Twitterカードように拡張子を外す
                string url = xDoc.Element("data").Element("link").Value;
                url = url.Remove(url.Length - 4, 4);
                UploadedURL = url;
            }

            text += " " + UploadedURL;
            string hashtags = "&hashtags=";
            if (sinstance.hashTags.Length > 0)
            {
                hashtags += string.Join (",", sinstance.hashTags);
            }

            // ツイッター投稿用URL
            string TweetURL = "http://twitter.com/intent/tweet?text=" + text + hashtags;

#if UNITY_WEBGL && !UNITY_EDITOR
            OpenWindow(TweetURL);
#elif UNITY_EDITOR
            System.Diagnostics.Process.Start (TweetURL);
#else
            Application.OpenURL(TweetURL);
#endif
        }
    }
}
