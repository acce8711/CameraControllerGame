using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicationManager : MonoBehaviour
{
    public SerialController serialController;
    public CameraManager cameraManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InterpretReceivedMessage(string message)
    {
        string[] commands = message.Split(',');
        switch (commands[0])
        {
            case CommunicationConstants.TAKE_PICTURE:
                Debug.Log("Take picture");
                cameraManager.TakePicture();
                break;
            case CommunicationConstants.ADJUST_SPEED:
                if(commands.Length > 1)
                    Debug.Log("Adjust speed: " + commands[1]);
                break;
            case CommunicationConstants.ROTATE_CAMERA:
                if (commands.Length > 1 && int.TryParse(commands[1], out int angle))
                {
                    Debug.Log("Rotate camera: " + commands[1]);
                    cameraManager.RotateCamera(angle);
                }
                break;
            default:
                Debug.Log("Another command received");
                break;
        }
    }

    public void SendMessageToArduino(string message)
    {
        serialController.SendSerialMessage(message);
    }
}
