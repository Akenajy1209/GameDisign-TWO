using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public int vidaMax;
    public float vidaActual;
    public Image ImagenBarraVida;

    //Sonido
    public AudioClip sonidoDa�o;
    public AudioClip sonidoMuerte;
    public AudioClip Da�oEnemigo;
    private AudioSource audio;

    private void Start()
    {
        vidaActual = vidaMax;
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        RevisarVida();
        /*if (vidaActual <= 0)
        {
            if(nivel == 1)
            {
               // SceneManager.LoadScene(5);
            }
            if (nivel == 2)
            {
              //  SceneManager.LoadScene(6);
            }
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Da�o"))
        {
            ReproducirSonido(sonidoDa�o);
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
    public void ReproducirEnemigo()
    {
        audio.clip = Da�oEnemigo;
        audio.Play();
    }
}

