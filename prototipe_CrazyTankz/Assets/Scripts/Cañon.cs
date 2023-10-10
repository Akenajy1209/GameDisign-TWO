using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public GameObject bala; //objeto que sera instanciado

    public float tiempoMinInstancia = 2f; // Tiempo mínimo entre instancias
    public float tiempoMaxInstancia = 5f; // Tiempo máximo entre instancias
    [SerializeField]
    private float tiempoSigInstancia; // Tiempo restante hasta la próxima instancia
    private Animator anim;

    //Sonido
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        tiempoSigInstancia = Random.Range(tiempoMinInstancia, tiempoMaxInstancia);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        tiempoSigInstancia -= Time.deltaTime;

        if (tiempoSigInstancia <= 0f)
        {
            //Llama a la animacion
            anim.SetBool("AnimShoot", true);
            // Reiniciar el contador de tiempo para la próxima instancia
            tiempoSigInstancia = Random.Range(tiempoMinInstancia, tiempoMaxInstancia);
            //Debug.Log(tiempoSigInstancia);
        }
        // Restaurar la escala original después de realizar los cálculos y la instancia
        transform.localScale = Vector3.one;
    }
    public void OnShoot()
    {
        // Instanciar un objeto con la misma orientación
        Vector3 posicionInstancia = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
        Instantiate(bala, posicionInstancia, transform.rotation);
        //Reproduce sonido de disparo
        audio.Play();

    }
    public void OffShoot()
    {
        anim.SetBool("AnimShoot", false);
    }
}

