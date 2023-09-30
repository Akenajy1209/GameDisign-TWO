using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public int vidaMax;
    public float vidaActual;
    public Image ImagenBarraVida;

    public int EnemiAMatar;
    public float EnemiActual;
    public Image ImagenEnemRest;

    //Sonido
    public AudioClip sonidoDaño;
    public AudioClip sonidoMuerte;
    public AudioClip DañoEnemigo;
    private AudioSource audio;

    public int nivel;

    private void Start()
    {
        vidaActual = vidaMax;
        EnemiActual = EnemiAMatar;
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput,0f, verticalInput).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        RevisarVida();
        RevisarEnemigos();
        if (vidaActual <= 0)
        {
            if(nivel == 1)
            {
                SceneManager.LoadScene(5);
            }
            if (nivel == 2)
            {
                SceneManager.LoadScene(6);
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
    public void RevisarEnemigos()
    {
        ImagenEnemRest.fillAmount = EnemiActual / EnemiAMatar;
    }

    public void ReproducirSonido(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
    public void ReproducirEnemigo()
    {
        audio.clip = DañoEnemigo;
        audio.Play();
    }
}

