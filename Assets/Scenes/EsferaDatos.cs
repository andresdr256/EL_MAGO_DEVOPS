using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaDatos : MonoBehaviour
{

    public GameObject esfera;        // Objeto para manipular la esfera
    public Transform sujetadorMano;  // Se utiliza para obtener la posición de las manos del NPC
    public Transform destinoEsferas; // Se utiliza para obtener la posición del destino a donde se llevan las esferas

    public bool esferaCapturada; // Indica el estado de una esfera cuando está capturada o no
    public bool esferaEnDestino; // Indica el estado de una esfera cuando está en su destino o fuera de el

    void Update()
    {
        // Si la esfera ha sido capturada, se transporta a las manos del NPC
        if(esferaCapturada == true)
        {
            esfera.transform.SetParent(sujetadorMano);  
            esfera.transform.position = sujetadorMano.position;
            esfera.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // Comprueba si un objeto toca la esfera
    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que toca la esfera es un NPC y la esfera no está en su destino, entonces la esfera es capturada
        if(other.tag=="NPC" && esferaEnDestino != true)
        {
            esferaCapturada = true;
        }

        // Si la esfera llega a su destino, el NPC la suelta para que se mueva libremente
        if(other.tag=="DestinoEsferas")
        {
            esferaEnDestino = true;
            esferaCapturada = false;
            esfera.GetComponent<Rigidbody>().isKinematic = false;
            GameObject.Find("EsferaEntregada").GetComponent<BoxCollider>().enabled = false;
        }
    }
}
