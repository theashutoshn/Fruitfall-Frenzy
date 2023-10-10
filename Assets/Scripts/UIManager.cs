using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    
    [SerializeField]
    private Image _livesImg;
    
    [SerializeField]
    private Sprite[] _basketLives;

    [SerializeField]
    private TextMeshProUGUI _gameOverText;

    //private float _flickerRate = 0.2f;

    [SerializeField]
    private TextMeshProUGUI _restart;

    private GameManager _gameManager;

    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
        _restart.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _basketLives[currentLives];

        if (currentLives == 0)
        {
            _gameOverText.gameObject.SetActive(true);
            StartCoroutine(GameOverTextFlickerRoutine());
            _restart.gameObject.SetActive(true);
            _gameManager.GameOver();
        }
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();  
    }

    IEnumerator GameOverTextFlickerRoutine()
    {
        while(true)
        {
            _gameOverText.enabled = !_gameOverText.enabled;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
