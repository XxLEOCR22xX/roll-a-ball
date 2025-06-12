using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atras : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        

    }
    //volverr a la escena con indice 0
    public void Retroceder()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);  
     }
        

    // Update is called once per frame
    void Update()
    {
        
    }
}
