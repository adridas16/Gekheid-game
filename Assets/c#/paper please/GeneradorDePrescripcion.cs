using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GeneradorDePrescripcion : MonoBehaviour
{
    public TMP_Text MedicosValidos;
    // Start is called before the first frame update
    public string[] nombreDemedicinas = { "Sortol", "Crisonil", "Vertesten", "Eridiol", "Artisan", "Morcasen", "Vestaforte", "Ibrasen", };
    public string[] dosis = { "50g", "100g", "200g", "500g", "750g", "1000g" };
    public string[]DoctoresInvalidos= { "Dr.Milazzo", "Dr.Morales", "Dr.Osuna", "Dr.Wiesner", "Dr.Berm�dez", "Dr.Borrero", "Dr.Escobar", 
        "Dr.Estrada", "Dr.G�mez", "Dr.Hinestrosa",};
    public string[] DoctoresValidos= { "Dr.Kalgan", "Dr.Alarc�n", "Dr.Amador", "Dr.Archila", "Dr.Arias", "Dr.Barrera", "Dr.Bernal", "Dr.Lucena" };
  
    // Start is called before the first frame update
    void Start()
    {
        //nombreDemedicinas = new List<string> { " Sortol ", " Crisonil ", " Vertesten ", " Eridiol ", " Artisan ", " Morcasen ", " Vestaforte ", " Ibrasen ",};
        //dosis = new List<string> { " 50g", "100g", "200g", "500g", "750g", "1000g" };
        //nombresdeDoctores = new List<string> { " Dr.Kalgan ", " Dr.Alarc�n ", " Dr.Amador ", " Dr.Archila ", 
        //    " Dr.Arias ", " Dr.Barrera ", " Dr.Bernal ", " Dr.Berm�dez ", "Dr.Borrero", " Dr.Escobar ", " Dr.Estrada ", " Dr.G�mez ", " Dr.Hinestrosa ", 
        //    " Dr.Lucena ", " Dr.Milazzo ", " Dr.Morales ", " Dr.Osuna ", " Dr.Wiesner" };
        MedicosValidos.text ="Medicos Presentes\n" + "Dr.Kalgan\n" + "Dr.Alarc�n\n" + "Dr.Amador\n" + "Dr.Archila\n" + "Dr.Arias\n" + "Dr.Barrera\n" + "Dr.Bernal\n" + "Dr.Lucena";
    }

    // Update is called once per frame
    void Update()
    {

    }// Start is called before the first frame update
    public PrescripcionMedica GenerateRandomPrescription()
    {
        string nombremedicina = nombreDemedicinas[Random.Range(0, nombreDemedicinas.Length)];
        string Dosi = dosis[Random.Range(0, dosis.Length)];




        float randoD = Random.value;
        string nombredeDoctores;
            if(randoD<=0.5f)
        {
            nombredeDoctores = DoctoresValidos[Random.Range(0, DoctoresValidos.Length)];
        }
        else
        {
            nombredeDoctores= DoctoresInvalidos[Random.Range(0, DoctoresInvalidos.Length)];
        }
            
            //string NombreValidoDeDoctor = nombresdeDoctores[random.Next(nombresdeDoctores.Count)];
            //return new PrescripcionMedica("Random Dosis", "Random Medicina",NombreValidoDeDoctor);
   
        //string Nombremedicina = nombreDemedicinas[random.Next(nombreDemedicinas.Count)];
        //string Dosi = dosis[random.Next(dosis.Count)];
        //string RandomNombreDoctor = nombresdeDoctores[random.Next(nombresdeDoctores.Count)];
        

        return new PrescripcionMedica(nombremedicina, Dosi,nombredeDoctores,randoD<=0.5f);
    }



}
