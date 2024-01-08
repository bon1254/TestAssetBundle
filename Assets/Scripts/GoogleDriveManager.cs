using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleDriveDownloader : MonoBehaviour
{
    private AssetBundle assetBundle = null;

    [SerializeField]
    TMP_Text Text_State;

    [SerializeField]
    string assetBundleLink = "https://drive.google.com/uc?export=download&id=1F-3Xu1SJTEQsuphpsl35Mjh6VI6uXLlP";

    private void Start()
    {
        Text_State.text = "Not Load AssetBundle";
    }

    public void DownLoadAssetBundleFromGoogleDrive()
    {
        StartCoroutine(DownloadAndLoad());
    }

    private IEnumerator DownloadAndLoad()
    {
        UnityWebRequest webrequest = UnityWebRequestAssetBundle.GetAssetBundle(assetBundleLink);
        yield return webrequest.SendWebRequest();

        if (webrequest.result != UnityWebRequest.Result.Success)
        {
            Text_State.text = $"Loading AssetBundle Error! Result: {webrequest.error}";
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(webrequest);

            GameObject prefab = bundle.LoadAsset<GameObject>("testsphere");
            Instantiate(prefab);

            Text_State.text = "Load Sucessfully!";
        }
    }
}
