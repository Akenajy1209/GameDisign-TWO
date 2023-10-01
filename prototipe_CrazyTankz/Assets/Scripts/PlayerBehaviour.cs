using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerBehaviour : MonoBehaviour
{
    public int vidaMax;
    public float vidaActual;
    public Image ImagenBarraVida;
    private PositionBehavier Datos;
    private TimeController DatosTiempo; 

    //Sonido
    public AudioClip sonidoDaño;
    public AudioClip sonidoMuerte;
    public AudioClip DañoEnemigo;
    private AudioSource audio;


    private void Start()
    {
        Datos = GameObject.FindWithTag("Player").GetComponent<PositionBehavier>();
        DatosTiempo = GameObject.FindWithTag("Player").GetComponent<TimeController>();
        vidaActual = vidaMax;
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        RevisarVida();
        if (vidaActual <= 0 || DatosTiempo.TiempoActual == 0f)
        {
            if(Datos.Level == 1)
            {
                Debug.Log("Perdio");
               // SceneManager.LoadScene(5);
            }
            if (Datos.Level == 2)
            {
              //  SceneManager.LoadScene(6);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Daño"))
        {
            ReproducirSonido(sonidoDaño);
            audio.Play();
            vidaActual -= 25;
            if (vidaActual <= 0)
            {
                ReproducirSonido(sonidoMuerte);
            }
        }
    }
    public void RevisarVida()
    {
        ImagenBarraVida.fillAmount = vidaActual / vidaMax;
    }
    public void ReproducirSonido(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
}

