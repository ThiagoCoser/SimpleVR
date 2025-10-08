using UnityEngine;
using TMPro;
public class CameraGiroscope : MonoBehaviour
{


    [Header("Sensibilidade da Rotação")]
    public float rotationSpeed = 100f;

    private bool gyroSupported;
    private Gyroscope gyro;

    private Vector3 currentRotation;

    void Start()
    {
        gyroSupported = SystemInfo.supportsGyroscope;

        if (gyroSupported)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyro.updateInterval = 0.0167f; // 60Hz
        }
        else
        {
            Debug.LogWarning("Giroscópio não suportado neste dispositivo.");
        }

        currentRotation = transform.eulerAngles;
    }

    void Update()
    {
        if (!gyroSupported) return;

        // Rotação baseada na velocidade angular do giroscópio
        Vector3 rotationRate = gyro.rotationRateUnbiased; // em rad/s
        rotationRate *= Mathf.Rad2Deg; // converter para graus/s

        // Inverte os eixos X e Y
        currentRotation.x -= rotationRate.x * rotationSpeed * Time.deltaTime; // inverte X
        currentRotation.y -= rotationRate.y * rotationSpeed * Time.deltaTime; // inverte Y

        // Aplica rotação ao objeto
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0f);
    }
}
