using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Kakera;
using Const;

public class Config_button : MonoBehaviour
{
    private string account_id;
    public string account_name;
    private string account_mail;

    public string sum;
    public string change_name;
    public string introduction;
    public string town;
    public string birthday;  ///DateTime
    public Texture2D icon1 ;
    public Texture2D icon2 ;
    public string Kagi ;

    public InputField accountnameInput;
    public InputField introductionInput;
    public InputField townInput;
    public InputField birthdayInput;

    public Texture2D icon1Input;
    public Texture2D icon2Input;
    public Toggle KagiInput;

    private const string Server_Address = ServerURL.LocalIP;
    //private const string Server_GlobalIP = "http://192.168.0.104:3000";
    //private const string Server_GlobalIP = "http://10.213.220.214:3000";        ///UTokyoWifi使用時////

    private const string URL_Account = Server_Address + "/configs/show";
    private const string URL_Profile_Update = Server_Address + "/configs/update";//edit??

    public Canvas canvas0;
    public Canvas CanvasNameConfig;
    public Canvas CanvasProfileConfig;
    public Canvas CanvasPrivacyConfig;
    public Canvas CanvasNotificationConfig;
    public Canvas CanvasKiyaku;
    public Canvas CanvasTaikai;

    public Text Name0;
    public Text Name1;


    // ログイン画面のときtrue, 新規登録画面のときfalse
    private bool LogIned;

    // テキストボックスで入力される文字列を格納
    public string id1;
    private string pw1;

    public string id0;
    private string pw0;
    public string mail0;

    void Start()
    {
        canvas0.gameObject.SetActive(true);
        CanvasNameConfig.gameObject.SetActive(false);
        CanvasProfileConfig.gameObject.SetActive(false);
        CanvasPrivacyConfig.gameObject.SetActive(false);
        CanvasNotificationConfig.gameObject.SetActive(false);
        CanvasKiyaku.gameObject.SetActive(false);
        CanvasTaikai.gameObject.SetActive(false);

        //NCMBUser user = NCMBUser.CurrentUser;

        account_id = LogInManager.account_id;
        account_name = LogInManager.account_name;
        account_mail = LogInManager.account_mail;

        change_name = XARManager.change_name;
        introduction = XARManager.introduction;
        town = XARManager.town;
        sum = XARManager.sum;
        birthday = XARManager.birthday;
        Kagi = XARManager.Kagi;

        accountnameInput.text = change_name;
        introductionInput.text = introduction;
        townInput.text = town;
        birthdayInput.text = birthday;

        Name0.text = change_name;
        Name1.text = change_name;      
    }

    public void SendAccount(string account_id, string account_name, string account_mail)
    {
        StartCoroutine(OnSend(account_id, account_name, account_mail));
    }
    IEnumerator OnSend(string account_id, string account_name, string account_mail)
    {
        //POSTする情報
        WWWForm post = new WWWForm();

        post.AddField("account_id", account_id);
        post.AddField("account_name", account_name);
        post.AddField("account_mail", account_mail);

        //URLをPOSTで用意
        UnityWebRequest webRequest = UnityWebRequest.Post(URL_Account, post);
        //UnityWebRequestにバッファをセット
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        //URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();
        //エラーが出ていないかチェック
        if (webRequest.isNetworkError)
        {
            //通信失敗
            Debug.Log(webRequest.error);
            Debug.Log("情報の送信に失敗しました");
        }
        
    }

    public void SendProfile(string account_id, string account_name, string account_mail, string introduction, string town, string birthday, byte[] icon1, byte[] icon2)
    {
        //コルーチンを呼び出す
        StartCoroutine(OnSendProfile(account_id, account_name, account_mail, introduction, town, birthday, icon1, icon2));
    }
    IEnumerator OnSendProfile(string account_id, string account_name, string account_mail, string introduction, string town, string birthday, byte[] icon1, byte[] icon2)
    {
        //POSTする情報
        WWWForm post = new WWWForm();

        post.AddField("account_id", account_id);
        post.AddField("account_name", account_name);
        post.AddField("account_mail", account_mail);
        post.AddField("introduction", introduction);
        post.AddField("town", town);
        //post.AddField("birthday", birthday.ToString());
        //post.AddBinaryData("icon1", icon1);
        //post.AddBinaryData("icon2", icon2);

        //URLをPOSTで用意
        UnityWebRequest webRequest = UnityWebRequest.Post(URL_Profile_Update, post);
        //UnityWebRequestにバッファをセット
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        //URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();
        //エラーが出ていないかチェック
        if (webRequest.isNetworkError)
        {
            //通信失敗
            Debug.Log(webRequest.error);
            Debug.Log("プロフィールの送信に失敗しました");
        }
    }

    void Update()
    {
        change_name = accountnameInput.text;
        //account_name = accountnameInput.text;
        introduction = introductionInput.text;
        town = townInput.text;
        //birthday = DateTime.Parse(birthdayInput.text);
        LogIned = true;
    }

    public void Profile_Update()
    {
        SendProfile(account_id, change_name, account_mail, introduction, town, birthday, null, null);
        //SendProfile(account_id, account_name, account_mail, introduction, town, birthday, icon1.EncodeToJPG(), icon2.EncodeToJPG());
        //accountnameInput.placeholder.GetComponent<Text>().text = "現在" + change_name;
        //introductionInput.placeholder.GetComponent<Text>().text = "現在" + introduction;
        
        Name0.text = change_name;
        Name1.text = change_name;
    }


    public void Name_Config()
    {
        canvas0.gameObject.SetActive(false);
        CanvasNameConfig.gameObject.SetActive(true);
        CanvasProfileConfig.gameObject.SetActive(false);
        CanvasPrivacyConfig.gameObject.SetActive(false);
        CanvasNotificationConfig.gameObject.SetActive(false);
        CanvasKiyaku.gameObject.SetActive(false);
        CanvasTaikai.gameObject.SetActive(false);
    }

    public void Profile_Config()
    {
        canvas0.gameObject.SetActive(false);
        CanvasNameConfig.gameObject.SetActive(false);
        CanvasProfileConfig.gameObject.SetActive(true);
        CanvasPrivacyConfig.gameObject.SetActive(false);
        CanvasNotificationConfig.gameObject.SetActive(false);
        CanvasKiyaku.gameObject.SetActive(false);
        CanvasTaikai.gameObject.SetActive(false);
    }

    public void Privacy_Config()
    {
        canvas0.gameObject.SetActive(false);
        CanvasNameConfig.gameObject.SetActive(false);
        CanvasProfileConfig.gameObject.SetActive(false);
        CanvasPrivacyConfig.gameObject.SetActive(true);
        CanvasNotificationConfig.gameObject.SetActive(false);
        CanvasKiyaku.gameObject.SetActive(false);
        CanvasTaikai.gameObject.SetActive(false);
    }

    public void Notification_Config()
    {
        canvas0.gameObject.SetActive(false);
        CanvasNameConfig.gameObject.SetActive(false);
        CanvasProfileConfig.gameObject.SetActive(false);
        CanvasPrivacyConfig.gameObject.SetActive(false);
        CanvasNotificationConfig.gameObject.SetActive(true);
        CanvasKiyaku.gameObject.SetActive(false);
        CanvasTaikai.gameObject.SetActive(false);
    }

    public void Kiyaku()
    {
        canvas0.gameObject.SetActive(false);
        CanvasNameConfig.gameObject.SetActive(false);
        CanvasProfileConfig.gameObject.SetActive(false);
        CanvasPrivacyConfig.gameObject.SetActive(false);
        CanvasNotificationConfig.gameObject.SetActive(false);
        CanvasKiyaku.gameObject.SetActive(true);
        CanvasTaikai.gameObject.SetActive(false);
    }

    public void Taikai()
    {
        canvas0.gameObject.SetActive(false);
        CanvasNameConfig.gameObject.SetActive(false);
        CanvasProfileConfig.gameObject.SetActive(false);
        CanvasPrivacyConfig.gameObject.SetActive(false);
        CanvasNotificationConfig.gameObject.SetActive(false);
        CanvasKiyaku.gameObject.SetActive(false);
        CanvasTaikai.gameObject.SetActive(true);
    }

    public void Back()
    {
        canvas0.gameObject.SetActive(true);
        CanvasNameConfig.gameObject.SetActive(false);
        CanvasProfileConfig.gameObject.SetActive(false);
        CanvasPrivacyConfig.gameObject.SetActive(false);
        CanvasNotificationConfig.gameObject.SetActive(false);
        CanvasKiyaku.gameObject.SetActive(false);
        CanvasTaikai.gameObject.SetActive(false);
    }

    public void Configure_Back()
    {
        SceneManager.LoadScene("ARable_MainScene");
    }
}
