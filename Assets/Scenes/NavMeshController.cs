using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public Transform EsferaEntregada;  // Se utiliza para obtener la posición del destino de las esferas 
    public Transform objetivo;         // Se utiliza para obtener la posición del objetivo hacia el que el NPC se dirige 
    public EsferaDatos esfera;         // Objeto para manipular la esfera

    void Update()
    {
        // Se obtiene el NPC y la esfera que se va a manipular
        NavMeshAgent NPC = GetComponent<NavMeshAgent>();
        esfera = GameObject.Find("GameObject").GetComponent<EsferaDatos>();

        // Si la esfera no está en su destino, se comprueba si está capturada por el NPC
        if(esfera.esferaEnDestino == false){
            
            // Si la esfera no ha sido capturada, el NPC se dirige a ella  
            if(esfera.esferaCapturada == false)  
            {
                NPC.destination = objetivo.position;        
            }    
           
            // Si la esfera ha sido capturada, el objetivo del NPC cambia y ahora se dirige al destino final
            if(esfera.esferaCapturada == true)
            {
                objetivo = GameObject.Find("EsferaEntregada").GetComponent<Transform>();
                NPC.destination = objetivo.position;        
            }
        }

        // Si la esfera se encuentra en el destino final, la ruta del NPC finaliza
        if(esfera.esferaEnDestino == true)
        {
            NPC.GetComponent<NavMeshAgent>().enabled = false;
        }
    }
}
