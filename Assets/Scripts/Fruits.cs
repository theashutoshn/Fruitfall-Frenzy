using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _fruitSpeed = 2f;

    [SerializeField]
    private int _fruitID;

    private Player _player;

    


    void Start()
    {

        
        

        transform.position = new Vector3(Random.Range(-2.80f, 2.80f), 3f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _fruitSpeed * Time.deltaTime);


        if (transform.position.y < -1.5f)
        {
            transform.position = new Vector3(Random.Range(-2.80f, 2.80f), 3f, 0);
        }


        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            Player _player = other.gameObject.GetComponent<Player>();
            if (_player != null)  // Just to be safe
            {
                switch (_fruitID)
                {
                    case 0:
                        _player.AddScore(10);
                        break;
                    
                    case 1:
                        _player.AddScore(20);
                        break;

                    case 2:
                        _player.AddScore(30);
                        break;

                    default:
                        Debug.Log("Defalut");
                        break;
                }
                
            }
            Destroy(this.gameObject);
        }
    }



}
