
using UnityEngine;

public class EnemigoMovement : MonoBehaviour
{
    public PlayerMovement DatosPlayer;
    public Transform player;
    public float VelMovimiento = 3f;
    public float rangoDeDeteccion = 5f;
    //public Color ColorAtaque = Color.red;
    public float DistAtaque = 0.5f;
    public float pendiente;
    public float ordenadaOrigen;
    public enum EnemyState { Alerta, Inactivo }
    public EnemyState currentState;

    //Sonido
    public AudioClip DañoEnemigo;

    private void Start()
    {
        DatosPlayer = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        
    }
    void Update()
    {
        float distanceToPlayer = CalculateDistanceToPlayer();

        if (distanceToPlayer <= DistAtaque)
        {
            //GetComponent<Renderer>().material.color = ColorAtaque;
        }
        else
        {
            //GetComponent<Renderer>().material.color = Color.white;

            if (distanceToPlayer <= rangoDeDeteccion)
            {
                if (currentState == EnemyState.Inactivo)
                {
                    currentState = EnemyState.Alerta;
                    //Debug.Log("Estado: Alerta");
                }

                Vector3 direction = (player.position - ApplyOrdenadaAlOrigen()).normalized;
                transform.Translate(direction * VelMovimiento * Time.deltaTime);
                //ApplyOrdenadaAlOrigen();
            }
            else
            {
                currentState = EnemyState.Inactivo;
                //Debug.Log("Estado: Inactivo");
            }
        }
    }
    float CalculateDistanceToPlayer()
    {
        Vector3 delta = player.position - transform.position;
        float distance = Mathf.Sqrt(delta.x * delta.x + delta.z * delta.z);
        return distance;
    }
     Vector3 ApplyOrdenadaAlOrigen()
    {
        pendiente = (player.position.z - transform.position.z) / (player.position.x - transform.position.x);
        ordenadaOrigen = player.position.z - pendiente * player.position.x;
        // Aplicar la ordenada al origen en el movimiento del enemigo
        transform.position = new Vector3(transform.position.x, transform.position.y, pendiente * transform.position.x + ordenadaOrigen);
        return transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Daño"))
        {
            DatosPlayer.ReproducirEnemigo();
            DatosPlayer.EnemiActual -= 1;
            Destroy(gameObject);
        }
    }
}
