using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommunicationConstants
{
    //Receiving messages
/*    public enum ReceiveMessages
    {
        takePicture, 
        increaseSpeed,
        decreaseSoeed,
    };*/

    public const string TAKE_PICTURE = "takePicture";
    public const string ADJUST_SPEED = "adjustSpeed";
    public const string ROTATE_CAMERA = "rotateCamera";
}
