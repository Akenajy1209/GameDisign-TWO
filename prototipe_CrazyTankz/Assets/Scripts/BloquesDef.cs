using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class BloquesDef : MonoBehaviour
{
    InstanciaBloque Instancia;
    public int Fila;
    public int Columna;
    private Animator anim;
    public GameObject Enemigo;


    // Start is called before the first frame update
    void Start()
    {
        Instancia = GameObject.FindWithTag("Plano").GetComponent<InstanciaBloque>(); 
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("Mover", Instancia.matriz[Fila, Columna]);
    }
    // Update is called once per frame
    public void SubeBloque()
    {
        anim.SetBool("Mover", true);
    }
    public void BloqueBaja()
    {
        Instancia.matriz[Fila, Columna] = false;
    }
    public void GenerarEnem()
    {
        Instantiate(Enemigo, (new Vector3(transform.position.x, 0.91f, transform.position.z)), transform.rotation);
    }
}
