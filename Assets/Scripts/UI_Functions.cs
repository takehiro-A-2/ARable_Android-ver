using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Functions : MonoBehaviour
{
    public Button File;
    public Button VC_Image;
    public Button Movie;
    public Button Comments;
    public Button Update_Button;
    public Button Setting;
    public Button Good;
    public Button Bad;
    public Button Home;
    public Button Camera;
    public Button Orientation;

    public Button CameraUI_Camera;
    public Button CameraUI_Home;
    public GameObject CameraUI_Panel;

    public RectTransform DeletePanel;
    public ToggleGroup ToggleGroup;
    public Toggle TogglePreview;
    public Toggle ToggleImage;
    public Toggle ToggleText;
    public Toggle Delete_Mode;

    public Slider Slider;
    public InputField InputField;
    public Image Image;

    public Text Imagepath;
    public Text Coordinate;
    public Text Information;

    DeviceOrientation PrevOrientation;

    public Canvas Canvas_UI;
    public Canvas Canvas0;
    public GameObject GameObject1;

    void Start()
    {

        PrevOrientation = DeviceOrientation.Portrait;
        //PrevOrientation = getOrientation();

        File.gameObject.SetActive(true);
        VC_Image.gameObject.SetActive(true);
        Movie.gameObject.SetActive(true);
        Comments.gameObject.SetActive(true);
        Update_Button.gameObject.SetActive(true);
        Setting.gameObject.SetActive(true);
        Good.gameObject.SetActive(true);
        Bad.gameObject.SetActive(true);
        Home.gameObject.SetActive(true);
        Camera.gameObject.SetActive(true);

        ToggleGroup.gameObject.SetActive(true);
        TogglePreview.gameObject.SetActive(true);
        ToggleImage.gameObject.SetActive(true);
        ToggleText.gameObject.SetActive(true);
        Delete_Mode.gameObject.SetActive(true);

        Slider.gameObject.SetActive(true);
        InputField.gameObject.SetActive(true);
        Image.gameObject.SetActive(true);

        Imagepath.gameObject.SetActive(true);
        Coordinate.gameObject.SetActive(true);
        Information.gameObject.SetActive(true);
        
    }
    void Update()
    {
    if(ToggleImage.isOn)
        {
            Information.text="ディレクトリから画像を選択し，     置きたい場所を２秒間タップしてください";
            Information.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);

            Imagepath.gameObject.SetActive(true);
            Slider.gameObject.SetActive(false);
            Image.gameObject.SetActive(true);
            InputField.gameObject.SetActive(false);
            File.gameObject.SetActive(true);
            Orientation.gameObject.SetActive(true);

            VC_Image.gameObject.SetActive(false);////////////////////////////////VC用
            Movie.gameObject.SetActive(false);//////////////今後trueにする予定
            Comments.gameObject.SetActive(true);
            Imagepath.gameObject.SetActive(true);

            Good.gameObject.SetActive(true);
            Bad.gameObject.SetActive(true);
            Update_Button.gameObject.SetActive(true);
            Setting.gameObject.SetActive(true);
        }
    if(ToggleText.isOn)
        {
            Information.text="テキストボックスに入力し，       置きたい場所を２秒間タップしてください";
            Information.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);

            Slider.gameObject.SetActive(true);
            Image.gameObject.SetActive(false);
            InputField.gameObject.SetActive(true);
            File.gameObject.SetActive(false);
            VC_Image.gameObject.SetActive(false);
            Movie.gameObject.SetActive(false);
            Comments.gameObject.SetActive(true);
            Imagepath.gameObject.SetActive(false);
            Orientation.gameObject.SetActive(false);

            Good.gameObject.SetActive(true);
            Bad.gameObject.SetActive(true);
            Update_Button.gameObject.SetActive(true);
            Setting.gameObject.SetActive(true);
        }
    if(Delete_Mode.isOn)
        {
            Information.text="　注意！！  アイテムはタップすると削除されます";
            Information.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);

            Slider.gameObject.SetActive(false);
            Image.gameObject.SetActive(false);
            InputField.gameObject.SetActive(false);
            File.gameObject.SetActive(false);
            VC_Image.gameObject.SetActive(false);
            Movie.gameObject.SetActive(false);
            Good.gameObject.SetActive(false);
            Bad.gameObject.SetActive(false);
            Update_Button.gameObject.SetActive(false);
            Setting.gameObject.SetActive(false);
            Coordinate.gameObject.SetActive(false);
            Imagepath.gameObject.SetActive(false);
            Camera.gameObject.SetActive(false);
            Orientation.gameObject.SetActive(false);

            Comments.gameObject.SetActive(true);
        }
        
        //DeviceOrientation currentOrientation = getOrientation();
        // 画面が横向きの場合の処理
        //if(currentOrientation == DeviceOrientation.LandscapeLeft)
            {
                
        }

        // 画面が縦向きの場合の処理
        //if(currentOrientation==DeviceOrientation.Portrait)
            {
                
           
        }
        //PrevOrientation = currentOrientation;
    }
    // 端末の向きを取得するメソッド
    DeviceOrientation getOrientation() 
    {
        DeviceOrientation result = Input.deviceOrientation;

              // Unkownならピクセル数から判断
        if (result == DeviceOrientation.Unknown)
        {
            if (Screen.width < Screen.height)
            {
                result = DeviceOrientation.Portrait;
            }
            else
            {
                result = DeviceOrientation.LandscapeLeft;
            }
        }
        return result;
    }

    public void Comments_Button()
    {
        ToggleText.isOn=true;
    }

    public void UIBack()
    {
        Canvas0.gameObject.SetActive (false);
        Canvas_UI.gameObject.SetActive (true);
        
	    ToggleText.isOn=true;
    }

    public void PreviewToggleOn()
	{
	Canvas_UI.gameObject.SetActive (false);
	//slider1.gameObject.SetActive (false);
	GameObject1.gameObject.SetActive(true);
	}

    public void Calibration()
    {
       
        SceneManager.LoadScene("Calibration");
        Debug.Log("成功");

    }
    public void Configure()
    {
        
        SceneManager.LoadScene("Configure");

        //#if UNITY_ANDROID
        //string url = "http://40.115.247.138:8080/PBL2019ASARI/web/dellPhp.php";
        //Application.OpenURL(url);
        //#elif UNITY_IPHONE
        //string url = "http://40.115.247.138:8080/PBL2019ASARI/web/dellPhp.php";
        //Application.OpenURL(url);
        //#else
        //#endif
    }
}

