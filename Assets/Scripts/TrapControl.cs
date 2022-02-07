using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapControl : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (playerPrefab)
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }


}
