using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class InstanciaBloque : MonoBehaviour
{
    public Boolean[,] matriz;
    public int nroRandomFila;
    public int nroRandomColumn;

    public float tiempoGen = 5f; // Intervalo de tiempo entre generaciones
    public float tiempoTranscurrido = 0f; // Tiempo transcurrido desde la �ltima generaci�n


    void Start()
    {
        Inicializar();
    }
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiempoGen)
        {
            // Generar un n�mero aleatorio entre 0 y 2 (incluyendo ambos)
            nroRandomFila = UnityEngine.Random.Range(0, 3);
            // Generar un n�mero aleatorio entre 0 y 3 (incluyendo ambos)
            nroRandomColumn = UnityEngine.Random.Range(0, 4);

            Debug.Log("Fila"+nroRandomFila + "     Columna "+nroRandomColumn);
            if (matriz[nroRandomFila, nroRandomColumn] == false)
            {
                matriz[nroRandomFila, nroRandomColumn] = true;
            }

            // Reiniciar el contador de tiempo para la pr�xima generaci�n
            tiempoTranscurrido = 0f;
        }
    }
    
    private void Inicializar()
    {
        matriz = new bool[3, 4];
        for (int f = 0; f < matriz.GetLength(0); f++)
        {
            for (int c = 0; c < matriz.GetLength(1); c++)
            {
                matriz[f, c] = false;
            }
        }
    }
}
