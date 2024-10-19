using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCube : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Mover();
        if (Input.GetButtonDown("Jump") && EsSuelo())
        {
            Saltar();
        }
    }

    void Mover()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical);
        rb.MovePosition(transform.position + movimiento * velocidad * Time.deltaTime);
    }

    void Saltar()
    {
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
    }

    bool EsSuelo()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
