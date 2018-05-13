using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPhoneCam : MonoBehaviour
{

    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBG;

    public GUITexture background;
    public GUITexture starryBG;
    //public RawImage background;
    public AspectRatioFitter fit;

    public void Initialize()
    {

        Debug.Log("Initialize");
        background = gameObject.AddComponent<GUITexture>();
        background.pixelInset = new Rect(0, 0, Screen.width, Screen.height);

        WebCamDevice[] devices = WebCamTexture.devices;
        string backCamName = "";
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log("Device:" + devices[i].name + "IS FRONT FACING:" + devices[i].isFrontFacing);

            if (!devices[i].isFrontFacing)
            {
                backCamName = devices[i].name;
            }
        }

        backCam = new WebCamTexture(backCamName, 10000, 10000, 30);
        backCam.Play();
        background.texture = backCam;
    }
}
