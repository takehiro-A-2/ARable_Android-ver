﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class canvasvc : MonoBehaviour {
	public Canvas CanvasUI;
	public Canvas Canvasimage; 
	//public Canvas Canvasmovie;
public void Start(){
	//Canvasimage.gameObject.SetActive(false);
	//Canvasmovie.gameObject.SetActive(false);
}
	// Use this for initialization
	public void onClickimage(){
		CanvasUI.gameObject.SetActive(false);
		//Canvasmovie.gameObject.SetActive(false);
		Canvasimage.gameObject.SetActive(true);
	}
	
	public void offClickimage() {
		Canvasimage.gameObject.SetActive(false);
		//Canvasmovie.gameObject.SetActive(false);
		CanvasUI.gameObject.SetActive(true);
	}

	public void onClickmovie(){
		CanvasUI.gameObject.SetActive(false);
		Canvasimage.gameObject.SetActive(false);
		//Canvasmovie.gameObject.SetActive(true);
	}
	public void offClickmovie() {
		Canvasimage.gameObject.SetActive(false);
		//Canvasmovie.gameObject.SetActive(false);
		CanvasUI.gameObject.SetActive(true);
	}

}
