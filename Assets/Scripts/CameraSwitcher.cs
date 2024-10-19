using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1; // C�mara principal (por defecto)
    public Camera camera2; // C�mara que sigue al jugador

    // Rotaciones predeterminadas para ambas c�maras
    private Quaternion rotacionInicialCamera1;
    private Quaternion rotacionInicialCamera2;

    private void Start()
    {
        // Aseg�rate de que solo la c�mara principal est� activa al inicio
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);

        // Guardar la rotaci�n inicial de ambas c�maras
        rotacionInicialCamera1 = camera1.transform.rotation;
        rotacionInicialCamera2 = camera2.transform.rotation;
    }

    private void Update()
    {
        // Cambiar de c�mara al presionar la tecla "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            CambiarCamara();
        }
    }

    private void CambiarCamara()
    {
        if (camera1.gameObject.activeSelf)
        {
            // Desactivar camera1 y activar camera2
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(true);

            // Reiniciar la rotaci�n de la c�mara 2
            camera2.transform.rotation = rotacionInicialCamera2;
        }
        else
        {
            // Desactivar camera2 y activar camera1
            camera2.gameObject.SetActive(false);
            camera1.gameObject.SetActive(true);

            // Reiniciar la rotaci�n de la c�mara 1
            camera1.transform.rotation = rotacionInicialCamera1;
        }
    }
}
