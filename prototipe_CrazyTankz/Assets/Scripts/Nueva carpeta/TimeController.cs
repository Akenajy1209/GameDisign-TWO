using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public int TiempoMax;
    public float TiempoActual;
    public Image ImagenBarraTiempo;

    // Start is called before the first frame update
    void Start()
    {
        TiempoActual = TiempoMax;
    }

    // Update is called once per frame
    void Update()
    {
        RevisarTiempo();

        TiempoActual -= Time.deltaTime;
        if (TiempoActual <= 0.0f)
        {
            Debug.Log("Tiempo Agotado");
            TiempoActual = 0.0f;
            SceneManager.LoadScene(6);
        }
    }
    void RevisarTiempo()
    {
        ImagenBarraTiempo.fillAmount = TiempoActual / TiempoMax;
    }
}
