using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Const;

public class ID: MonoBehaviour
{
    public GameObject prefab;
    public Toggle Delete_mode;

    private const string Server_Address = ServerURL.LocalIP;
    //private const string Server_GlobalIP = "http://192.168.0.104:3000";
    //private const string Server_GlobalIP = "http://10.213.220.214:3000";        ///UTokyoWifi使用時////

    private const string Server_Delete = Server_Address + "/posts/delete";
    private string current_account_id = LogInManager.account_id;

    public string account_id;
    public string object_id;

    public Texture2D image;

    public string x;
    public string y;
    public string z;
    public string text;
    //public string size;

    public string good;
    public string bad;

    public string troublesome;
    public bool activation;

   
    public void Delete_prefab()
    {
        if (Delete_mode.isOn)
        {
            Destroy(prefab);///これを使う
            Send(current_account_id, object_id);
            
        }
    }

    public void Send(string current_account_id, string object_id)
    {
        //コルーチンを呼び出す
        StartCoroutine(OnSend(current_account_id, object_id));

    }
    IEnumerator OnSend(string current_account_id, string object_id)
    {
        //POSTする情報
        WWWForm post = new WWWForm();

        Debug.Log(current_account_id);
        Debug.Log(object_id);

        post.AddField("account_id", current_account_id);
        post.AddField("object_id", object_id);
        
        //URLをPOSTで用意
        UnityWebRequest webRequest = UnityWebRequest.Post(Server_Delete, post);
        //UnityWebRequestにバッファをセット
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        //URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();
        //エラーが出ていないかチェック
        if (webRequest.isNetworkError)
        {
            //通信失敗
            Debug.Log(webRequest.error);
            Debug.Log("ユーザー情報の送信に失敗しました");

        }
    }


    void Start()
    {
        BoxCollider collider = prefab.GetComponent<BoxCollider>();
        collider.size = prefab.transform.localScale;
    }


    void Update()
    {
        BoxCollider collider = prefab.GetComponent<BoxCollider>();
        collider.size = prefab.transform.localScale;
    }
}
