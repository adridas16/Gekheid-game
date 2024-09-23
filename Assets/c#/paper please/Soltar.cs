using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Soltar : MonoBehaviour
{
    public int PersonasEquivocadas = 0;
    public PrescripcionGameManager manager;
    public GameObject PrefAdvertencia;
    public GameObject prefNPC1;
    public GameObject prefNPC2;
    public GameObject prefNPC3;
    public GameObject prefNPC4;
    public GameObject prefNPC5;
    public GameObject prefNPC6;
    public int NPCrandom = 0;

    // Start is called before the first frame update
    void Start()
    {
        NpcRandom();
    }
    
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D other) // Usa Collider2D para colisiones 2D
    {
        

        Pastillas pastilla = other.GetComponent<Pastillas>();
        papel Papel=other.GetComponent<papel>();
        Denegar denegar= other.GetComponent<Denegar>();
        ConfirmacionDePrescripcion confirmacion=other.GetComponent<ConfirmacionDePrescripcion>();

        // print(other.name);
        
        if (pastilla != null && !pastilla.isBeingDragged) // Accede a 'isBeingDragged' porque ahora es público
        {
            NpcRandomVuelta();
            //Destroy(other.gameObject); // Destruye el objeto al soltarlo en el trigger
            if (other.name==manager.EstaPrescripcion.NombreMedicina)
            {
                Debug.Log("pastilla correcta");
                if (manager.EstaPrescripcion.DoctorCorrecto)
                {
                    Debug.Log("nombe de doctor correcto");
                    NpcRandom();
                }
                else 
                {
                    Debug.Log("nombre de doctor incorrecto");
                    //informar de que el doctor no esta has fallado
                    PonerAdvertencia();
                    NpcRandom();


                }
                
               
            }
            else 
            {
                Debug.Log("pastilla incorrecta");

                //informar de que el doctor no esta has fallado
                PonerAdvertencia();
                NpcRandom();
            }
            pastilla.transform.position = pastilla.Posicionvuelta;
            manager.CrearReceta();

            
        } 
        if (denegar != null && !denegar.isBeingDragged) // Accede a 'isBeingDragged' porque ahora es público
        {
            //Destroy(other.gameObject); // Destruye el objeto al soltarlo en el trigger
            NpcRandomVuelta();


                 if (manager.EstaPrescripcion.DoctorCorrecto)
                {
                    Debug.Log("Te has equivocado era correcto " +manager.EstaPrescripcion.NombreDeDoctor);
                    PonerAdvertencia();
                    NpcRandom();
                   }
                else 
                {
                    Debug.Log("has acertado era una trampa " + manager.EstaPrescripcion.NombreDeDoctor);
                    //informar de que el doctor no esta has fallado
                     NpcRandom();
                 }



            
            denegar.transform.position = denegar.PosicionvueltaDenegar;
            manager.CrearReceta();
            
        }
        
    }
    public void PonerAdvertencia()
    {
        GameObject clon = Instantiate(PrefAdvertencia);
        PersonasEquivocadas++;
        clon.transform.position = new Vector3(-3.61999989f, -6.058336f, 0);
    }
    public void NpcRandom()
    {
        NPCrandom = Random.Range(0, 6);
        if (NPCrandom == 0)
        {
            prefNPC1.transform.position = new Vector3(-3.55999994f, 0.409999996f, 0.5f);
        }
        else if (NPCrandom == 1)
        {
            prefNPC2.transform.position = new Vector3(-3.55999994f, 0.409999996f, 0.5f);
        }
        else if (NPCrandom == 2)
        {
            prefNPC3.transform.position = new Vector3(-3.55999994f, 0.409999996f, 0.5f);
        }
        else if (NPCrandom == 3)
        {
            prefNPC4.transform.position = new Vector3(-3.55999994f, 0.409999996f, 0.5f);
        }
        else if (NPCrandom == 4)
        {
            prefNPC5.transform.position = new Vector3(-3.55999994f, 0.409999996f, 0.5f);
        }
        else if (NPCrandom == 5)
        {
            prefNPC6.transform.position = new Vector3(-3.55999994f, 0.409999996f, 0.5f);
        }
    }
    public void NpcRandomVuelta()
    {
        NPCrandom = Random.Range(0, 6);
        if (NPCrandom >= 0)
        {
            prefNPC1.transform.position = new Vector3(-38.7299957f, 0.379999995f, 0.5f);
            prefNPC2.transform.position = new Vector3(-38.7299957f, 0.379999995f, 0.5f);
            prefNPC3.transform.position = new Vector3(-38.7299957f, 0.379999995f, 0.5f);
            prefNPC4.transform.position = new Vector3(-38.7299957f, 0.379999995f, 0.5f);
            prefNPC5.transform.position = new Vector3(-38.7299957f, 0.379999995f, 0.5f);
            prefNPC6.transform.position = new Vector3(-38.7299957f, 0.379999995f, 0.5f);
        }
    }
}
       