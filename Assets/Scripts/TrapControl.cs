using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapControl : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject activeGameCanvas;

    [SerializeField] GameObject mouseOverControl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerPrefab)
        {
            Time.timeScale = 0f;
            activeGameCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
        }
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void QuitButton()
    {

        Application.Quit();
    }


    private void OnMouseOver()
    {
        mouseOverControl.GetComponent<ReverseButtonControl>().StopDraw();
    }

    private void OnMouseExit()
    {
        mouseOverControl.GetComponent<ReverseButtonControl>().StartDraw();
    }
}
