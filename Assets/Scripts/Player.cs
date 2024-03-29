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

    //[SerializeField]
    //private GameObject _level_01;

    //[SerializeField]
    //private GameObject _level_02;

    private SpawnManager _spawnManager;
    

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");
        }

        
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

        //float verticalInput = Input.GetAxis("Vertical");

        //transform.Translate(new Vector3(0, 1, 0) * _playerSpeed * verticalInput * Time.deltaTime);

        //if(transform.position.y >= 0.8f)
        //{
        //    transform.position = new Vector3(transform.position.x, 0.8f, 0);
        //}
        //else if (transform.position.y <= -0.35f)
        //{
        //    transform.position = new Vector3(transform.position.x, -0.35f, 0);
        //}

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
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
            
        }
        
    }

    public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);

        // Background Change
        //if (_score >= 100)
        //{
        //    _level_01.SetActive(false);
        //    _level_02.SetActive(true);
        //}


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
