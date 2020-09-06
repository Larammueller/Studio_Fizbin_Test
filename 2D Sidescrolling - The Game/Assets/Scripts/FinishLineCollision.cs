using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineCollision : MonoBehaviour
{
    [SerializeField]
    private int m_iAmountOfScenes;
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.tag == "Player")
        {
            if (this.m_iAmountOfScenes == SceneManager.GetActiveScene().buildIndex)
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
