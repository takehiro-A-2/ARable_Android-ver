using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coordinate : MonoBehaviour
{
    [SerializeField] public Text info;
    public Camera ARCamera;
    void Update()
    {
        info.text = ARCamera.transform.position.ToString();
    }
}
