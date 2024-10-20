using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCube : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 5f;
    public float boostedSpeed = 10f;   
    public float limiteTerreno = 900f; //Dimensión del terreno
    public KeyCode boostKey = KeyCode.LeftShift; // Tecla que activa el boost (puedes cambiarlo por otra)
    private Rigidbody rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Mover();
        LimitarPosicion(); // Llamar la función para limitar la posición del personaje

        if (Input.GetButtonDown("Jump") && EsSuelo())
        {
            Saltar();
        }
    }

    void Mover()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical).normalized;

        // Aumentar la velocidad si la tecla de boost está presionada
        float velocidadActual = (Input.GetKey(boostKey)) ? boostedSpeed : velocidad;

        rb.MovePosition(transform.position + movimiento * velocidadActual * Time.deltaTime);
    }

    void Saltar()
    {
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
    }

    bool EsSuelo()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    // Función para limitar la posición del personaje dentro del terreno
    void LimitarPosicion()
    {
        // Limitar la posición del personaje, pero solo si se sale del terreno
        if (transform.position.x < 0 || transform.position.x > limiteTerreno || transform.position.z < 0 || transform.position.z > limiteTerreno)
        {
            // Si el personaje está fuera del terreno, reducimos la velocidad a 0 para que no atraviese el borde
            rb.velocity = new Vector3(0, rb.velocity.y, 0);

            // Reposicionamos el personaje justo en el borde sin que quede bloqueado
            float x = Mathf.Clamp(transform.position.x, 0, limiteTerreno);
            float z = Mathf.Clamp(transform.position.z, 0, limiteTerreno);
            transform.position = new Vector3(x, transform.position.y, z);
        }
    }
}
