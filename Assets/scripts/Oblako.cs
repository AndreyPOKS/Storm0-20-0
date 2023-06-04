using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oblako : MonoBehaviour
{
    public Vector2 direction;

    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }
}
