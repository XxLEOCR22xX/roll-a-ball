using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotulacion : MonoBehaviour
{
      private float velocidadRotacion;

    void Start()
    {
        // Asigna una velocidad aleatoria una sola vez
        velocidadRotacion = Random.Range(10f, 100f);
    }

    void Update()
    {
        // Rota el cubo constantemente usando la velocidad asignada
        transform.Rotate(0, velocidadRotacion * Time.deltaTime, 0);
    }
}
