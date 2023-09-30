using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class CommandVoice : MonoBehaviour
{
    private PositionBehavier AvailablePOS;
    // Start is called before the first frame update
    KeywordRecognizer keywordRecognizer; // creo mi reconocedor de comandode voz

    Dictionary<string, Action> actions = new Dictionary<string, Action>(); // creo las comando

    void Start()
    {
        AvailablePOS = GameObject.FindWithTag("Player").GetComponent<PositionBehavier>();

        //creo las acciones segun el comando de voz
        actions.Add("uno",MoverUno);
        actions.Add("dos",MoverDos);
        actions.Add("tres",MoverTres);
        actions.Add("cuatro", MoverCuatro);
        actions.Add("cinco", MoverCinco);
        actions.Add("seis", MoverSeis);
        actions.Add("siete", MoverSiete);
        //


        //seteo el ronocedor de voz y lo inicio
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();

       // WindowsVoice.speak("Hola a los alumnos y alumnas de diseño de videojuegos 2");
    }

    private void MoverUno()
    {
        if (AvailablePOS.pos1 == true)
        {
            Debug.Log("Se mueve a la pos: 1");
            WindowsVoice.speak("uno");
            transform.position = new Vector3(0f, 1f, 0f);
        }else {
            WindowsVoice.speak("No disponible");
        }
    }
    private void MoverDos()
    {
        if (AvailablePOS.pos2 == true)
        {
            Debug.Log("Se mueve a la pos: 2");
            WindowsVoice.speak("dos");
            transform.position = new Vector3(-2.5f, 1f, 0f);
        }else{
            WindowsVoice.speak("No disponible");
        }
    }
    private void MoverTres()
    {
        if (AvailablePOS.pos3 == true)
        {
            Debug.Log("Se mueve a la pos: 3");
            WindowsVoice.speak("tres");
            transform.position = new Vector3(2.5f, 1f, 0f);
        }else{
            WindowsVoice.speak("No disponible");
        }
    }
    private void MoverCuatro()
    {
        if (AvailablePOS.pos4 == true)
        {
            Debug.Log("Se mueve a la pos: 4");
            WindowsVoice.speak("cuatro");
            transform.position = new Vector3(-5f, 1f, 0f);
        }else{
            WindowsVoice.speak("No disponible");
        }
    }
    private void MoverCinco()
    {
        if (AvailablePOS.pos5 == true)
        {
            Debug.Log("Se mueve a la pos: 5");
            WindowsVoice.speak("cinco");
            transform.position = new Vector3(5f, 1f, 0f);
        }else{
            WindowsVoice.speak("No disponible");
        }
    }
    private void MoverSeis()
    {
        if (AvailablePOS.pos6 == true)
        {
            Debug.Log("Se mueve a la pos: 6");
            WindowsVoice.speak("seis");
            transform.position = new Vector3(-7.5f, 1f, 0f);
        }else{
            WindowsVoice.speak("No disponible");
        }
    }
    private void MoverSiete()
    {
        if (AvailablePOS.pos7 == true)
        {
            Debug.Log("Se mueve a la pos: 7");
            WindowsVoice.speak("siete");
            transform.position = new Vector3(7.5f, 1f, 0f);
        }else{
            WindowsVoice.speak("No disponible");
        }
    }




    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs command)
    {
       // Debug.Log(command.text);
        actions[command.text].Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
            //WindowsVoice.speak("tecla k");
        }
    }
}
