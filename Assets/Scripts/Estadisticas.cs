using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Estadisticas : MonoBehaviour //UnityEvent<LoadSceneMode>
{
    public TextMeshProUGUI partida;
    public TextMeshProUGUI usuario;
    public TextMeshProUGUI equipo;
    public TextMeshProUGUI duracion;
    public TextMeshProUGUI dificultad;
    public TextMeshProUGUI mensaje;
    public TextMeshProUGUI ganado;
    public Servidor servidor;

    UnityEvent m_MyEvent;

    public void OnEnable()
    {
        GeneraEstadisticas();
    }

    public void GeneraEstadisticas()
    {

        StartCoroutine(estadisticas());
    }


    IEnumerator estadisticas()
    {
        string[] datos = new string[1];
        datos[0] = servidor.username;
        Debug.Log(servidor.username);


        StartCoroutine(servidor.ConsumirServicio("Estadistica", datos));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        mensaje.text = servidor.respuesta.mensaje.ToString();
        cargaEstadisticas();
    }

    void cargaEstadisticas()
    {
        Debug.Log(servidor.respuesta.respuesta.idPartida.ToString());
        partida.text = "ID de Partida:\n" + servidor.respuesta.respuesta.idPartida.ToString();
        usuario.text = "Usuario:\n" + servidor.respuesta.respuesta.usuario.ToString();
        equipo.text = "Equipo:\n" + servidor.respuesta.respuesta.equipo.ToString();
        duracion.text = "Duracion:\n" + servidor.respuesta.respuesta.duracion.ToString();
        dificultad.text = "Dificultad:\n" + servidor.respuesta.respuesta.dificultad.ToString();
        if (servidor.respuesta.respuesta.ganado == 1)
        {
            ganado.text = "Ganado:\n" + "Si";
        }
        else
        {
            ganado.text = "Ganado:\n" + "No";
        }
    }

}