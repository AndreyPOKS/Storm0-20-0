using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform item;

    void Update()
    {
        if (KeysText.Keys >= 10)
            EndGame();
    }
    void EndGame()
    {
        Instantiate(item, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
