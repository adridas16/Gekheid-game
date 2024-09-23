using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogeManager : MonoBehaviour
{
    public bool mostrar = false;
    public string[] Textos;
    public int indiceTextos = 0;
    public string FraseAhora = "";
    public int indiceFrase = 0;
    public GameObject canvasDialogue;
    
    public TMP_Text textDialogue;


    //sigleton
    public static DialogeManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && mostrar)
        {
            if (indiceFrase < FraseAhora.Length)
            {
                textDialogue.text = FraseAhora;
                indiceFrase = FraseAhora.Length;
                CancelInvoke();
            }
            else if (indiceTextos < Textos.Length)
            {
                FraseAhora = Textos[indiceTextos];
                indiceFrase = 0;
                textDialogue.text = "";
                InvokeRepeating("LetraAletra", 0,0.05f);

                indiceTextos++;
            }
            else
            {
                OcultarTexto();
            }
        }
    }
    void LetraAletra()
    {
        if (indiceFrase < FraseAhora.Length)
        {
            textDialogue.text += FraseAhora[indiceFrase];
            indiceFrase++;
        }
        else
        {
            CancelInvoke();
        }
    }
    public void MostrarTexto(string texto)
    {
        
        canvasDialogue.SetActive(true);
        textDialogue.text = texto;
    }
    public void MostrarTexto(string[] _Textos)
    {
        if (!mostrar)
        {
            mostrar = true;
           
            canvasDialogue.SetActive(true);
            Textos = _Textos;
            indiceTextos = 0;
        }
    }
    public void MostrarTexto(string[] _Textos, Sprite[] _caras)
    {
    }

    public void OcultarTexto()
    {
        
        canvasDialogue.SetActive(false);
        mostrar = false;
    }

}
