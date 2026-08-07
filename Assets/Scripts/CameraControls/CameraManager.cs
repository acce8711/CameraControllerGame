using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public GameObject picture_camera;
    public RenderTexture picture_texture;
    public RawImage picture_display;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakePicture()
    {
        picture_camera.SetActive(true);
        Camera camera = picture_camera.GetComponent<Camera>();
        camera.targetTexture = picture_texture;
        camera.Render();
        camera.targetTexture = null;
        picture_camera.SetActive(false);

        picture_display.texture = picture_texture;
    }

    public void RotateCamera()
    {

    }
}
