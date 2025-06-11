using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaparece : MonoBehaviour
{public float tiempoInactivo = 3f;

    private Renderer rend;
    private Collider col;
    private Material materialInstancia;

    void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
        materialInstancia = rend.material; // instancia única del material

        StartCoroutine(CicloDeAparicion());
    }

    IEnumerator CicloDeAparicion()
    {
        while (true)
        {
            // Genera un tiempo activo aleatorio entre 10 y 20 segundos
            float tiempoActivo = Random.Range(10f, 20f);

            // ACTIVAR suelo
            rend.enabled = true;
            col.enabled = true;

            // Transición de azul a rojo durante el tiempo activo
            for (float t = 0; t < tiempoActivo; t += Time.deltaTime)
            {
                float lerpFactor = t / tiempoActivo;
                Color colorInterpolado = Color.Lerp(Color.blue, Color.red, lerpFactor);
                materialInstancia.color = colorInterpolado;
                yield return null;
            }

            // DESACTIVAR suelo
            rend.enabled = false;
            col.enabled = false;

            // Espera tiempo inactivo
            yield return new WaitForSeconds(tiempoInactivo);

            // Reiniciar color
            materialInstancia.color = Color.blue;
        }
    }
}


