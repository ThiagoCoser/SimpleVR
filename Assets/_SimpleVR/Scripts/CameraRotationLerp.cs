using UnityEngine;

public class CameraRotationLerp : MonoBehaviour
{
    [Header("Input")]
    public string horizontalAxis = "Look X";
    public string verticalAxis = "Look Y";
    public float rotationAmount = 2f; // graus por frame

    [Header("Limites")]
    public float minPitch = -80f;
    public float maxPitch = 80f;

    [Header("Suavização")]
    public float rotationLerpTime = 1f; // tempo em segundos para atingir rotação

    private float pitch = 0f; // rotação vertical acumulada
    private float yaw = 0f;   // rotação horizontal acumulada
    private Quaternion targetRotation;

    void Start()
    {
        // Inicializa rotação alvo com a rotação atual
        targetRotation = transform.localRotation;
    }

    void Update()
    {
        // Leitura de input
        float horizontal = Input.GetAxis(horizontalAxis);
        float vertical = Input.GetAxis(verticalAxis);

        // Atualiza yaw/pitch acumulados
        yaw += horizontal * rotationAmount;
        pitch -= vertical * rotationAmount;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // Calcula rotação alvo
        targetRotation = Quaternion.Euler(pitch, yaw, 0f);

        // Aplica Lerp para suavizar rotação
        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            targetRotation,
            Time.deltaTime / rotationLerpTime
        );
    }
}
