using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class preview1 : MonoBehaviour {
	public Canvas Canvas_UI;
    public Toggle ToggleText;
	public GameObject script;
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount >0)
        //if(Input.GetMouseButton(0))
	{
 		Debug.Log("Touched!");
		Canvas_UI.gameObject.SetActive (true);

		script.gameObject.SetActive (false);
        ToggleText.isOn=true;
	}
	    }
}
