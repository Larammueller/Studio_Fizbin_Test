using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PitCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.tag == "Player")
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
