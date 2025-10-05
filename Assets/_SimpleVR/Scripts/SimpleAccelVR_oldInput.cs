using UnityEngine;

public class SimpleAccelVR_oldInput : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    private Quaternion targetRotation;
    private Quaternion rotationOffset = Quaternion.identity;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    void Update()
    {
        Vector3 acc = Input.acceleration.normalized;

        // Limitamos a leitura para dar mais estabilidade
        float rotX = Mathf.Clamp(acc.y * 90f, -80f, 80f);   // Pitch (olhar pra cima/baixo)
        float rotY = Mathf.Clamp(acc.x * -90f, -90f, 90f);  // Yaw (olhar pros lados)
        float rotZ = 0f;

        Quaternion baseRotation = Quaternion.Euler(rotX + 90f, rotY, rotZ);
        targetRotation = rotationOffset * baseRotation;

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * rotationSpeed
        );
    }

    public void ResetOrientation()
    {
        Vector3 acc = Input.acceleration.normalized;
        Quaternion currentRotation = Quaternion.Euler(acc.y * 90f + 90f, acc.x * -90f, 0f);
        rotationOffset = Quaternion.Inverse(currentRotation);
    }
}
