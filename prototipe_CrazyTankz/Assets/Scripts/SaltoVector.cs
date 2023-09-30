using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoVector : MonoBehaviour
{
    public float alturaMaxima = 2f;
    public LayerMask sueloLayer;

    private bool enSuelo = false;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {

            float velocidadInicialY = Mathf.Sqrt(2 * alturaMaxima * Mathf.Abs(Physics.gravity.y));

            // Aplicar la velocidad inicial al Rigidbody para el salto
            Vector3 velocidadInicialVector = new Vector3(0f, velocidadInicialY, 0f);
            rb.velocity = velocidadInicialVector ;
        }

        // Dibujar el Raycast para visualizar la altura máxima del salto en todo momento
        Vector3 origen = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 direccion = new Vector3(0, 1 * alturaMaxima, 0);
        Debug.DrawRay(origen, direccion, Color.red);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == sueloLayer)
        {
            enSuelo = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == sueloLayer)
        {
            enSuelo = false;
        }
    }
}