using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinControl : MonoBehaviour
{

    [SerializeField] GameObject gameWinCanvas;
    [SerializeField] GameObject activeGameCanvas;

    [SerializeField] int winCondition;
    [SerializeField] public int currentWinConditionCount = 0;

    private void Update()
    {
        if (currentWinConditionCount == winCondition)
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
