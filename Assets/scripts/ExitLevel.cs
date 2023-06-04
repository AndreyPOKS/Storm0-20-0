using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{   
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.tag == collisionTag)
        {
            SceneManager.LoadScene("Menu");
        }
    } 

}
