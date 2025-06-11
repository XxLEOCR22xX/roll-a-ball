using UnityEngine;

public class movimiento : MonoBehaviour
{
    public Vector3 offsetDestino = new Vector3(5, 0, 0); // Movimiento relativo desde la posición inicial
    public float velocidad = 2f;

    private Vector3 puntoA;
    private Vector3 puntoB;
    private Vector3 objetivoActual;

    void Start()
    {
        puntoA = transform.position;
        puntoB = puntoA + offsetDestino;
        objetivoActual = puntoB;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, objetivoActual, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, objetivoActual) < 0.01f)
        {
            objetivoActual = (objetivoActual == puntoA) ? puntoB : puntoA;
        }
    }
}

