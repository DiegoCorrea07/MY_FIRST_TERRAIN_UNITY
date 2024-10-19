using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jugador; // Asigna el cubo en el Inspector
    public Vector3 offset;    // Offset de la c�mara
    public float velocidad = 100f;
    float rotacionX = 0f;

    void LateUpdate()
    {
        // La c�mara sigue al jugador manteniendo el offset
        transform.position = jugador.position + offset;

        // La c�mara mira al jugador
        transform.LookAt(jugador);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * velocidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * velocidad * Time.deltaTime;

        // Rotaci�n vertical (eje X) solo para la c�mara
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f); // Limitar rotaci�n vertical

        // Aplicar rotaci�n vertical solo a la c�mara
        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

        // Rotar solo al jugador en el eje Y (izquierda/derecha)
        jugador.Rotate(Vector3.up * mouseX);

        // Asegurarse de que el jugador no se incline ni en el eje X ni en el eje Z
        Vector3 eulerAngles = jugador.eulerAngles;
        eulerAngles.x = 0f; // Bloquear inclinaci�n en X
        eulerAngles.z = 0f; // Bloquear inclinaci�n en Z
        jugador.eulerAngles = eulerAngles;
    }
}
