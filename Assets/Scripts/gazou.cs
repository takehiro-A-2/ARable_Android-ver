
using UnityEngine;


public class gazou : MonoBehaviour
{
    public GameObject Cube;   
    public Texture2D Fujisan_no_gazou;

    // Start is called before the first frame update
    void Start()
    {
        
        Cube.GetComponent<Renderer>().material.mainTexture = Fujisan_no_gazou;

        float x;
        float y;

        if (Fujisan_no_gazou.width > Fujisan_no_gazou.height)
        {
            float AspectRatio = Fujisan_no_gazou.width / Fujisan_no_gazou.height;

            y = (Fujisan_no_gazou.height / Fujisan_no_gazou.height) * 0.6f;
            x = AspectRatio * 0.6f;

            Cube.transform.localScale = new Vector3(x, y, 0.0001f);
        }

        if (Fujisan_no_gazou.height > Fujisan_no_gazou.width)
        {
            float AspectRatio = Fujisan_no_gazou.height / Fujisan_no_gazou.width;

            x = (Fujisan_no_gazou.width / Fujisan_no_gazou.width) * 0.6f;
            y = AspectRatio * 0.6f;

            Cube.transform.localScale = new Vector3(x, y, 0.0001f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
