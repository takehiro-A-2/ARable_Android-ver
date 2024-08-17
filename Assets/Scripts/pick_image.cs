using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.Networking;
using System;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Video;
using FantomLib;
using UnityEngine.XR.ARSubsystems;

public class pick_image : MonoBehaviour
{

    public Image image;                  //Image to apply texture.    //テクスチャを適用する画像
    private int defaultWidth = 384;     //Reference value of width, substitute value when acquisition fails (It will be initialized with UI size).     //幅の基準値、または取得に失敗したときの代替値（UIのサイズで初期化されます）
    private int defaultHeight = 384;    //Reference value of height, substitute value when acquisition fails (It will be initialized with UI size).    //高の基準値、または取得に失敗したときの代替値（UIのサイズで初期化されます）
    public GameObject clone; 
    private GameObject cube;

   // public GameObject Imageclone;
    public Text Imagepath;


    
    void Start()
    {
        
    }

    void Update()
    {
        clone=cube;
    }
    public void OnGalleryPick(ImageInfo info)
    {
        XDebug.Log("OnGalleryPick: " + info);
        bool fitOrientation = true;

        int width = info.width > 0 ? info.width : defaultWidth;         //Alternate value when width get failed.    //幅の取得に失敗したときの代替値
        int height = info.height > 0 ? info.height : defaultHeight;     //Alternate value when height get failed.   //高さの取得に失敗したときの代替値
        int orientation = fitOrientation ? info.orientation : 0;        //It also becomes 0 even if get failed.     //取得に失敗したときにも 0 となる

        cube=GameObject.Instantiate(clone);       //重要!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        LoadAndSetImage(info.path, width, height, orientation);


        Imagepath.text=info.path;
        
    }
    public void OnErro(string message)
    {
        XDebug.Log("GalleryPickTest2.OnError : " + message);
    }
    public void LoadAndSetImage(string path, int width, int height, int orientation)
    {
        Texture2D texture = LoadToTexture2D(path, width, height, TextureFormat.ARGB32, false, FilterMode.Bilinear);//imageについてはリサイズ，textureについては何も行わず
        

        if (texture != null && image != null)
        {
            RectTransform rt = image.rectTransform;
            orientation = (int)Mathf.Repeat(orientation, 360);

            int w, h;
            if (orientation == 90 || orientation == 270)
            {
                w = defaultWidth;
                h = height * w / width;
            }
            else
            {
                h = defaultHeight;
                w = width * h / height;
            }

            rt.sizeDelta = new Vector2(w, h);   //Make it the same ratio as the image.  //画像と同じ比率にする
            rt.localRotation = Quaternion.Euler(0, 0, -orientation);
            
            try
            {
                Sprite sprite = Sprite.Create(texture, new Rect(0,0,width, height), new Vector2(0.5f, 0.5f));
                image.sprite = sprite;

                cube.GetComponent<Renderer>().material.mainTexture  = texture;
                float wi = image.GetComponent<RectTransform>().sizeDelta.x;        //重要？？
		        float he = image.GetComponent<RectTransform>().sizeDelta.y;

                cube.transform.localScale = new Vector3 (-wi/400, -he/400, 0.000001f);

                //Vector3 placePosition = new Vector3(10000,10000,10000);
                //Imageclone=GameObject.Instantiate(cube);
                
                //Imageclone.transform.localPosition=placePosition;
            }
            catch (Exception)
            {
                XDebug.Log("Sprite.Create failed.");
            }
        }
        else
        {
            XDebug.Log("CreateTexture2D failed.");
#if !UNITY_EDITOR && UNITY_ANDROID
            XDebug.Log("'READ_EXTERNAL_STORAGE' permission = " + AndroidPlugin.CheckPermission("android.permission.READ_EXTERNAL_STORAGE"));
#endif 
        }
    }
    //Load the image from the specified path and generates a Texture2D.     //指定パスから画像を読み込み、テクスチャを生成する。
    public Texture2D LoadToTexture2D(string path, int width, int height, TextureFormat format, bool mipmap, FilterMode filter)
    {
        if (string.IsNullOrEmpty(path))
            return null;
        try
        {
            byte[] bytes = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(width, height, format, mipmap);
            texture.LoadImage(bytes);
            texture.filterMode = filter;
            texture.Compress(false);
            return texture;
        }
        catch (Exception e)
        {
            XDebug.Log(e.ToString());
            return null;
        }
    }
}
