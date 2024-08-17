using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input_text : MonoBehaviour
{
    public GameObject GameObject;
    public Slider Slider;
    public InputField inputField;
    public TextMesh Text;

    void Start()
    {
        inputField=inputField.GetComponent<InputField> ();
		TextMesh textObject = GameObject.Find("3D Text").GetComponent<TextMesh>();
    }
    void Update()
    {
        Text.text=inputField.text;
        int a=Text.text.Length;

        if(a == 0)
    {
      Text.transform.localScale=new Vector3(0,0,0);
    }
    else{

        Text.text = Text.text.Replace("\r\n", "\\n");
        float width = 0f;
		float height = 1f;
        width=Text.text.Length;
        height=1+(float)1.75*(CountChar(Text.text, '\n'));
		GameObject.transform.localScale=new Vector3((((float)(width/4.3f))),height,0.00001f);
        Text.transform.localScale=new Vector3((-1)*(Slider.value*0.4f), (Slider.value*0.4f), 0.00001f);
        }
    }
    public static int CountChar(string s, char c) 
    {
        return s.Length - s.Replace(c.ToString(), "").Length;
    }
}
