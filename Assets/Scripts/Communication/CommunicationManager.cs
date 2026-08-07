using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicationManager : MonoBehaviour
{
    public SerialController serialController;

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
                break;
            case CommunicationConstants.ADJUST_SPEED:
                Debug.Log("Adjust speed: " + commands[1]);
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
