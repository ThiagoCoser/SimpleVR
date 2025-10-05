using UnityEngine;

public class ResetCamera : MonoBehaviour
{
    public SimpleAccelVR_oldInput accelScript;

    public void ResetCameraButton()
    {
        accelScript.ResetOrientation();
    }
}
