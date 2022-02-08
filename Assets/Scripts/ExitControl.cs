using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitControl : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject gameWinCanvas;
    [SerializeField] GameObject activeGameCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (playerPrefab)
        {
            Time.timeScale = 0f;
            activeGameCanvas.SetActive(false);
            gameWinCanvas.SetActive(true);

        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
