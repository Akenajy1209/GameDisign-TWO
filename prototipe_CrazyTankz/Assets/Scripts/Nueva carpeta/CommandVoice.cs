using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class CommandVoice : MonoBehaviour
{
    // Start is called before the first frame update
    KeywordRecognizer keywordRecognizer; // creo mi reconocedor de comandode voz

    Dictionary<string, Action> actions = new Dictionary<string, Action>(); // creo las comando

    void Start()
    {
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
        Debug.Log("Se mueve a la pos: 1");
        //WindowsVoice.speak("uno");
    }
    private void MoverDos()
    {
        Debug.Log("Se mueve a la pos: 2");
        //WindowsVoice.speak("dos");
    }
    private void MoverTres()
    {
        Debug.Log("Se mueve a la pos: 3");
        //WindowsVoice.speak("tres");
    }
    private void MoverCuatro()
    {
        Debug.Log("Se mueve a la pos: 4");
        //WindowsVoice.speak("cuatro");
    }
    private void MoverCinco()
    {
        Debug.Log("Se mueve a la pos: 5");
        //WindowsVoice.speak("cinco");
    }
    private void MoverSeis()
    {
        Debug.Log("Se mueve a la pos: 6");
        //WindowsVoice.speak("seis");
    }
    private void MoverSiete()
    {
        Debug.Log("Se mueve a la pos: 7");
        //WindowsVoice.speak("siete");
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
