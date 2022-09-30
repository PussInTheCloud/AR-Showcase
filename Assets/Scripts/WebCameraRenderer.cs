using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCameraRenderer : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 30;
        Screen.orientation = ScreenOrientation.Portrait; 
        WebCamTexture webcamTexture = new WebCamTexture(Screen.width, Screen.height, 30);
        Material uiMat = GetComponent<Image>().material;
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height, Screen.width);
        uiMat.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
