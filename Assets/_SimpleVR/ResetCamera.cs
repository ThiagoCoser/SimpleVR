using UnityEngine;


public class ResetCamera : MonoBehaviour
{


    public GameObject cameraHead;


    public void resetCamera()
    {

        cameraHead.transform.localPosition = new Vector3(0f, 0f, 0f);
    }

}
