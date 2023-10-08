using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 3f;

    [SerializeField]
    private int _lives = 3;

    
    private UIManager _uiManager;

    [SerializeField]
    private int _score;

    [SerializeField]
    private GameObject _shieldVisual;

    [SerializeField]
    private bool _isShieldActive = false;

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(1, 0, 0) * _playerSpeed * horizontalInput * Time.deltaTime);

        if (transform.position.x >= 2.75f)
        {
            transform.position = new Vector3(2.75f, transform.position.y, 0);
        }
        else if (transform.position.x <= -2.75)
        {
            transform.position = new Vector3(-2.75f, transform.position.y, 0);
        }

        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(0, 1, 0) * _playerSpeed * verticalInput * Time.deltaTime);

        if(transform.position.y >= 0.8f)
        {
            transform.position = new Vector3(transform.position.x, 0.8f, 0);
        }
        else if (transform.position.y <= -0.35f)
        {
            transform.position = new Vector3(transform.position.x, -0.35f, 0);
        }

    }
    public void Damage()
    {
        if (_isShieldActive == true)
        {
            _isShieldActive = false;
            _shieldVisual.SetActive(false);
            return;
        }

        _lives -= 1;

        _uiManager.UpdateLives(_lives);
        if(_lives < 1)
        {
            
            Destroy(this.gameObject);
        }
        
    }

    public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }

    public void ShieldActive()
    {
        _isShieldActive = true;
        _shieldVisual.SetActive(true);
        StartCoroutine(ShieldOffRoutine());
    }
    IEnumerator ShieldOffRoutine()
    {
        yield return new WaitForSeconds(3f);
        _shieldVisual.SetActive(false);
    }
    public void SpeedBoost()
    {
        _playerSpeed = 8f;
        StartCoroutine(SpeedReturnROutine());
    }
    IEnumerator SpeedReturnROutine()
    {
        yield return new WaitForSeconds(3f);
        _playerSpeed = 3f;
    }
    

}
