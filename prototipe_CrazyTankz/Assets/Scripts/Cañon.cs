using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public Transform player;
    private float difX;
    private float difZ;
    private float Angulo;

    public GameObject bala; //objeto que sera instanciado

    public float tiempoMinInstancia = 2f; // Tiempo mínimo entre instancias
    public float tiempoMaxInstancia = 5f; // Tiempo máximo entre instancias
    [SerializeField]
    private float tiempoSigInstancia; // Tiempo restante hasta la próxima instancia

    //Sonido
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        tiempoSigInstancia = Random.Range(tiempoMinInstancia, tiempoMaxInstancia);
    }

    // Update is called once per frame
    void Update()
    {
        difX = player.position.x - transform.position.x;
        difZ = player.position.z - transform.position.z;
        Angulo = Mathf.Atan2(difX, difZ) * Mathf.Rad2Deg;
        //Debug.Log(Angulo);
        transform.rotation = Quaternion.Euler(0f, Angulo, 0f);
        // Dibujar el Raycast para visualizar la altura máxima del salto en todo momento
        Vector3 origen = new Vector3(transform.position.x, 0, transform.position.z);


        Vector3 direccion = new Vector3(difX, 0, difZ);
        Debug.DrawRay(origen, direccion, Color.red);



        tiempoSigInstancia -= Time.deltaTime;

        if (tiempoSigInstancia <= 0f)
        {
            // Instanciar un objeto con la misma orientación
            Vector3 posicionInstancia = transform.position + transform.forward * 2f; // 2 unidades hacia adelante
            Instantiate(bala, posicionInstancia, transform.rotation);

            //Reproduce sonido de disparo
            audio.Play();

            // Reiniciar el contador de tiempo para la próxima instancia
            tiempoSigInstancia = Random.Range(tiempoMinInstancia, tiempoMaxInstancia);
        }
        // Restaurar la escala original después de realizar los cálculos y la instancia
        transform.localScale = Vector3.one;
    }
}
