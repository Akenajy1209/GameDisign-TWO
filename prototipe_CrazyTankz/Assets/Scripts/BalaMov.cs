using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BalaMov : MonoBehaviour
{
    public float velMovBala;
    // Update is called once per frame
    void Update()
    {
        //Se traslada en su eje Z positivo
        transform.Translate(Vector3.forward * velMovBala * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("muro"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemigo"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
