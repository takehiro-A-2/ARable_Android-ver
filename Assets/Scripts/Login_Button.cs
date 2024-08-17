using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Login_Button : MonoBehaviour


{
    public Canvas canvas0;
    public Canvas canvasCreate;
    public Canvas canvasLogin;
    // Start is called before the first frame update
    void Start()
    {
        canvas0.gameObject.SetActive(true);
        canvasCreate.gameObject.SetActive(false);
        canvasLogin.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create_Account()
    {
        canvas0.gameObject.SetActive(false);
        canvasCreate.gameObject.SetActive(true);
    }

    public void Login_Account()
    {
        canvas0.gameObject.SetActive(false);
        canvasLogin.gameObject.SetActive(true);
    }
}
