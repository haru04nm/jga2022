using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thorn : MonoBehaviour
{
    public string SceneName;

    void OnCollisionEnter(Collision collision)
    {
            Debug.Log("!");

        if (collision.gameObject.tag == "trap")
        {
            Debug.Log("!");
            SceneManager.LoadScene(SceneName);
        }
    }
    
}
