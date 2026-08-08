using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    public GameObject main_camera;
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
        picture_camera.transform.rotation = main_camera.transform.rotation;
        Camera camera = picture_camera.GetComponent<Camera>();
        camera.targetTexture = picture_texture;
        camera.Render();
        camera.targetTexture = null;
        picture_camera.SetActive(false);

        picture_display.texture = picture_texture;
    }

    public void RotateCamera(float angle)
    {
        main_camera.transform.DORotate(new Vector3(0, angle, 0), 10f).SetSpeedBased();
    }
}
