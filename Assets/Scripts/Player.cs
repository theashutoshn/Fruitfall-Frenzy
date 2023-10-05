using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 5f;

    [SerializeField]
    private int _lives = 3;

    

    void Start()
    {
        
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
        _lives -= 1;

        if(_lives < 1)
        {
            Destroy(this.gameObject);
        }
        
    }
}
