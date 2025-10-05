using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public string horizontalAxis = "Look X";
    public string verticalAxis = "Look Y";
    public float rotationAmount = 2f; // graus por frame
    public float minPitch = -80f;
    public float maxPitch = 80f;

    private float pitch = 0f; // rotação vertical acumulada

    void Update()
    {
        float horizontal = Input.GetAxis(horizontalAxis);
        float vertical = Input.GetAxis(verticalAxis);

        // Atualiza pitch com limite
        pitch -= vertical * rotationAmount;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // Aplica rotação combinando pitch e yaw
        transform.localRotation = Quaternion.Euler(pitch, transform.localEulerAngles.y + horizontal * rotationAmount, 0f);
    }
}
