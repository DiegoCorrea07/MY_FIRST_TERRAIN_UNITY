using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1; // Cámara principal (por defecto)
    public Camera camera2; // Cámara que sigue al jugador

    // Rotaciones predeterminadas para ambas cámaras
    private Quaternion rotacionInicialCamera1;
    private Quaternion rotacionInicialCamera2;

    private void Start()
    {
        // Asegúrate de que solo la cámara principal esté activa al inicio
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);

        // Guardar la rotación inicial de ambas cámaras
        rotacionInicialCamera1 = camera1.transform.rotation;
        rotacionInicialCamera2 = camera2.transform.rotation;
    }

    private void Update()
    {
        // Cambiar de cámara al presionar la tecla "C"
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

            // Reiniciar la rotación de la cámara 2
            camera2.transform.rotation = rotacionInicialCamera2;
        }
        else
        {
            // Desactivar camera2 y activar camera1
            camera2.gameObject.SetActive(false);
            camera1.gameObject.SetActive(true);

            // Reiniciar la rotación de la cámara 1
            camera1.transform.rotation = rotacionInicialCamera1;
        }
    }
}
