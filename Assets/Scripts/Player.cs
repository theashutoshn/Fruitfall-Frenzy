using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 5f;

    [SerializeField]
    private float _playerPoints = 0f;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(1, 0, 0) * _playerSpeed * horizontalInput * Time.deltaTime);

        if (transform.position.x >= 2.05f)
        {
            transform.position = new Vector3(2.05f, transform.position.y, 0);
        }
        else if (transform.position.x <= -2.05)
        {
            transform.position = new Vector3(-2.05f, transform.position.y, 0);
        }

        public void Points()
        {

        }

    }
}
