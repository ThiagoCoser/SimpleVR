using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBehaviour : MonoBehaviour
{

    public Material matA;
    public Material matB;



    public int ID;

    public GameObject Facamp_F;
    public GameObject Facamp_A;
    public GameObject Facamp_C;
    public GameObject Facamp_A2;
    public GameObject Facamp_M;
    public GameObject Facamp_P;


    private bool isColliding;

    void Start()
    {
        // Cria uma instância do material para não alterar o material compartilhado

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EyeCollider"))
        {
            gameObject.GetComponent<Renderer>().material = matB;
            isColliding = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EyeCollider"))
        {
            gameObject.GetComponent<Renderer>().material = matA;
            isColliding = false;
        }
    }

    void Update()
    {

        if (Input.GetButton("Action") && isColliding == true)
        {

            if (ID == 1)
            {
                Facamp_F.GetComponent<Renderer>().material = matB;
            }

            if (ID == 2)
            {
                Facamp_A.GetComponent<Renderer>().material = matB;
            }


            if (ID == 3)
            {
                Facamp_C.GetComponent<Renderer>().material = matB;
            }


            if (ID == 4)
            {
                Facamp_A2.GetComponent<Renderer>().material = matB;
            }
            if (ID == 5)
            {
                Facamp_M.GetComponent<Renderer>().material = matB;
            }

            if (ID == 6)
            {
                Facamp_P.GetComponent<Renderer>().material = matB;
            }


            Destroy(gameObject);

        }

    }





}
