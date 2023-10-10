using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BalaMov : MonoBehaviour
{
    public float velMovBala;
    private float tiempo=0.5f;

    // Update is called once per frame
    void Update()
    {
        //Se traslada en su eje Z positivo
        transform.Translate(Vector3.forward * velMovBala * Time.deltaTime);
        tiempo -= Time.deltaTime;

        if (tiempo <= 0f)
        {
            Transform objetoHijo = transform.Find("luz");

            if (objetoHijo != null)
            {
                // Hacer algo con el objeto encontrado.
                objetoHijo.gameObject.SetActive(false);
            }
        }

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("muro"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
