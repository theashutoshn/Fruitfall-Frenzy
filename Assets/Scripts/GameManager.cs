using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;

    [SerializeField]
    private GameObject _pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RestartGame();
        PauseGame();
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void RestartGame()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (_isGameOver == true)
            {
                SceneManager.LoadScene(1);
            }

        }
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

    public void ResumeGame()
    {
        _pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
