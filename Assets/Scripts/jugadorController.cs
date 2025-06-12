using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jugadorController : MonoBehaviour
{
    private Rigidbody rb;
    private int contador;
    public Text TextoContador, textoGanar, textoTiempo;
    public float velocidad;

    private bool enSuelo = true; // NUEVO: variable para controlar si está tocando el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        setTextoContador();
        textoGanar.text = "";
    }

    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
        rb.AddForce(movimiento * velocidad);

        // Salto solo si está tocando el suelo
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            enSuelo = false; // Ya no está en el suelo hasta que vuelva a tocarlo
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            setTextoContador();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("suelo")) // Asegúrate de que el suelo tenga el tag "Suelo"
        {
            enSuelo = true;
        }
    }

    void LoadNextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings <= SceneManager.GetActiveScene().buildIndex + 1)
        {
            textoGanar.text = "¡Ganaste! Volviendo al menú...";
            Invoke("RestartLevel", 5f); // Espera 3 segundos antes de reiniciar
        
            return;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

void Update()
{
    if (transform.position.y < -10)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    float tiempoTotal = 120f;
    float tiempoRestante = tiempoTotal - Time.timeSinceLevelLoad;

    if (tiempoRestante <= 0)
    {
        textoTiempo.text = "Tiempo: 0";
        textoTiempo.color = Color.red; // Forzamos rojo final por seguridad
        textoGanar.text = "¡Perdiste!.";
        Invoke("RestartLevel", 3f);
        enabled = false;
    }
    else
    {
        textoTiempo.text = "Tiempo: " + Mathf.Ceil(tiempoRestante).ToString();

        // Cambiar el color de verde a rojo progresivamente
        float t = 1f - (tiempoRestante / tiempoTotal); // De 0 a 1
        textoTiempo.color = Color.Lerp(Color.green, Color.red, t);
    }
}


// Función para reiniciar el nivel
void RestartLevel()
{
    UnityEngine.SceneManagement.SceneManager.LoadScene(0); 
}

    void setTextoContador()
    {
        TextoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12) // Cambia este valor si necesitas más ítems
        {

            textoGanar.text = "¡Ganaste!";
            Invoke("LoadNextLevel", 2f); // Espera 2 segundos antes de cargar el siguiente nivel
             
        }
    }
}
