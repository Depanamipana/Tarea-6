using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;

public class SirenaAutoPolicia : MonoBehaviour
{
    public AudioClip sirenaAudioClip; // Asigna el AudioClip en el Inspector
    public Transform objetivo; // Asigna el objeto (por ejemplo, el auto del jugador) en el Inspector
    public float distanciaActivacion = 10f; // Ajusta la distancia a la que el personaje puede escuchar la sirena

    private AudioSource sirenaAudioSource; // AudioSource para reproducir la sirena

    void Start()
    {
        // Agrega un componente AudioSource al GameObject para reproducir el sonido
        sirenaAudioSource = gameObject.AddComponent<AudioSource>();
        sirenaAudioSource.clip = sirenaAudioClip;
        sirenaAudioSource.loop = true; // Para que la sirena se reproduzca continuamente
    }

    void Update()
    {
        // Verifica si el objetivo (por ejemplo, el auto del jugador) está dentro de la distancia de activación
        if (objetivo != null && Vector3.Distance(transform.position, objetivo.position) < distanciaActivacion)
        {
            // Si está dentro de la distancia, reproduce la sirena
            if (!sirenaAudioSource.isPlaying)
            {
                sirenaAudioSource.Play();
                Debug.Log("Sirena activada");
            }
        }
        else
        {
            // Si está fuera de la distancia, detén la sirena
            if (sirenaAudioSource.isPlaying)
            {
                sirenaAudioSource.Stop();
                Debug.Log("Sirena detenida");
            }
        }
    }
}
