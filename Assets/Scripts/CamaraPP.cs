using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPP : MonoBehaviour
{
    public float Velocidad = 100f;
    float RotacionX = 0f;

    public Transform Jugador;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MauseX = Input.GetAxis("Mouse X") * Velocidad * Time.deltaTime;
        float MauseY = Input.GetAxis("Mouse Y") * Velocidad * Time.deltaTime;

        RotacionX -= MauseY;
        RotacionX = Mathf.Clamp(RotacionX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(RotacionX, 0f, 0f);
        Jugador.Rotate(Vector3.up * MauseX);

        // Asegurarse de que el jugador no se incline ni en el eje X ni en el eje Z
        Vector3 eulerAngles = Jugador.eulerAngles;
        eulerAngles.x = 0f; // Bloquear inclinación en X
        eulerAngles.z = 0f; // Bloquear inclinación en Z
        Jugador.eulerAngles = eulerAngles;
    }

}
