using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using NCMB;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;
using Const;


public class LogInManager : MonoBehaviour {

  public static string account_id;
  public static string account_name;
  public static string account_mail;

  private const string Server_Address = ServerURL.LocalIP;
  private const string URL_UserCreate = Server_Address + "/configs/create";
  
  public Canvas canvas0;
  public Canvas canvasCreate;
  public Canvas canvasLogin;

  public InputField create_ID;
  public InputField create_PASS;
  public InputField create_MAIL;

  public InputField login_ID;
  public InputField login_PASS;

  // ログイン画面のときtrue, 新規登録画面のときfalse
  private bool isLogIn;
  private bool LogIned;

  // テキストボックスで入力される文字列を格納
  public string id1;
  private string pw1;

  public string id0;
  private string pw0;
  public string mail0;

  public static string currentPlayerName;


  public static string sum;
  
  public static string introduction;
  public static string town;
  public static string birthday;
  public static Texture2D icon1;
  public static Texture2D icon2;
  public static string Kagi = "false";


    void Start () {

        logOut();
    isLogIn = true;
    LogIned = false;

    canvas0.gameObject.SetActive(true);
    canvasCreate.gameObject.SetActive(false);
    canvasLogin.gameObject.SetActive(false);

  }

    // mobile backendに接続して新規会員登録 ------------------------
    public void signUp()
    {
        NCMBUser user0 = new NCMBUser();

        user0.UserName = id0;
        user0.Email = mail0;
        user0.Password = pw0;
        user0.SignUpAsync((NCMBException e) => {
            if (e == null)
            {
                NCMBUser.LogInAsync(id0, pw0, (NCMBException er) => {
                    // 接続成功したら
                
                Debug.Log("初回ログインです．");
                //NCMBUser user = NCMBUser.CurrentUser;
                SendAccount(user0.ObjectId, user0.UserName, user0.Email);

                LogIned = true;
                });
            }
        });
    }

    // mobile backendに接続してログイン ------------------------
    public void logIn() {

    string id = id1;
    string pw = pw1;

    //NCMBUser.LogInWithMailAddressAsync(id, pw, (NCMBException e) => {
    NCMBUser.LogInAsync (id, pw, (NCMBException e) => {
    // 接続成功したら
    if( e == null ){
      LogIned = true;
            
        }
    });
}
 

  void Update()
  {
    id0 = create_ID.text;
    pw0 = create_PASS.text;
    mail0 = create_MAIL.text;

    id1 = login_ID.text;
    pw1 = login_PASS.text;

        if (LogIned==true)
        {
            NCMBUser user = NCMBUser.CurrentUser;     
            account_id = user.ObjectId;
            account_name = user.UserName;
            account_mail = user.Email;
            

            SceneManager.LoadScene("ARable_MainScene");
        }
  }

    

    public void SendAccount(string account_id, string account_name, string account_mail)
    {
        //コルーチンを呼び出す
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
        UnityWebRequest webRequest = UnityWebRequest.Post(URL_UserCreate, post);
        //UnityWebRequestにバッファをセット
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        //URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();
        //エラーが出ていないかチェック
        if (webRequest.isNetworkError)
        {
            //通信失敗
            Debug.Log(webRequest.error);
        }
        else
        {
            //通信成功
            Debug.Log(webRequest.downloadHandler.text);
        }
    }

  public void Create_Menu()
    {
        canvas0.gameObject.SetActive(false);
        canvasCreate.gameObject.SetActive(true);
    }

  public void Login_Menu()
    {
        canvas0.gameObject.SetActive(false);
        canvasLogin.gameObject.SetActive(true);
    }

   public void Back()
    {
        canvas0.gameObject.SetActive(true);
        canvasCreate.gameObject.SetActive(false);
        canvasLogin.gameObject.SetActive(false);
    }

    public void Logout_Button()
    {
        logOut();
        SceneManager.LoadScene("login_check");
    }


    // mobile backendに接続してログアウト ------------------------
    public void logOut()
    {
        NCMBUser.LogOutAsync((NCMBException e) => {
            if (e == null)
            {
                LogIned = false;
                currentPlayerName = null;

            }
        });

    }

    // 現在のプレイヤー名を返す --------------------
    public string currentPlayer()
    {
        return currentPlayerName;
    }
}