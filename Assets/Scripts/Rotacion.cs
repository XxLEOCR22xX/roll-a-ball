﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    // Use this for initialization
void Start () {
}
// Update is called once per frame
void Update () {
//Rota el elemento una cantidad diferente en cada dirección y encada intervalo de tiempo
transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
}

}