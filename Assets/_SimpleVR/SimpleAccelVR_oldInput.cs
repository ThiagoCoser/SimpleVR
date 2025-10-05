using UnityEngine;


public class SimpleAccelVR_oldInput : MonoBehaviour
{



    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        // Leitura do acelerômetro
        Vector3 acc = Input.acceleration;

        // Corrige o mapeamento dos eixos
        float rotX = acc.y * 90f;  // Inverte o Y e aplica no pitch (X)
        float rotY = acc.x * -90f;   // Usa X no Yaw (Y)
        float rotZ = acc.z * 0;   // Opcional: inclinação

        // Aplica rotação na câmera
        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
        // feedback.text = transform.rotation.ToString();

    }
}
