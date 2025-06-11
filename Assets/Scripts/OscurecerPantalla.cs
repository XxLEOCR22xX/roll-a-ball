using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OscurecerPantalla : MonoBehaviour
{
    public Image panelOscuro;
    public float duracionTransicion = 1f;
    public float tiempoOscura = 2f;
    public float tiempoClara = 5f;

    void Start()
    {
        StartCoroutine(CicloOscurecer());
    }

    IEnumerator CicloOscurecer()
    {
        while (true)
        {
            // Oscurecer (alfa de 0 a 1)
            yield return StartCoroutine(Fade(0f, 1f));

            // Espera en oscuro
            yield return new WaitForSeconds(tiempoOscura);

            // Aclarar (alfa de 1 a 0)
            yield return StartCoroutine(Fade(1f, 0f));

            // Espera en claro
            yield return new WaitForSeconds(tiempoClara);
        }
    }

    IEnumerator Fade(float inicio, float fin)
    {
        float t = 0;
        while (t < duracionTransicion)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(inicio, fin, t / duracionTransicion);
            panelOscuro.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        panelOscuro.color = new Color(0, 0, 0, fin);
    }
}

