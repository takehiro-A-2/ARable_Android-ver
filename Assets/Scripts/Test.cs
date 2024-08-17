using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NCMBObject testClass = new NCMBObject("TestClass");

        // オブジェクトに値を設定
        testClass["message"] = "Hello, NCMB!";
        // データストアへの登録
        testClass.SaveAsync();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
