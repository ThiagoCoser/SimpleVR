using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FacampLogo : MonoBehaviour
{


    public int collectedCount;
    public GameObject lightEnd;


    void Update()
    {


        if (Input.GetButton("Reset"))
        {

            SceneManager.LoadScene(0);
        }

        if (collectedCount == 6)
        {

            lightEnd.SetActive(true);

        }

    }
}
