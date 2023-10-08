using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _powerUpSpeed = 2f;

    [SerializeField]
    private int _powerUpID;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-2.85f, 2.85f), 3.10f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down* _powerUpSpeed * Time.deltaTime);
        if (transform.position.y < -1.3f)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            
            if (player != null)
            {
                switch (_powerUpID)
                {
                    case 0:
                        player.ShieldActive();
                        break;

                    case 1:
                        player.SpeedBoost();
                        break;

                    default:
                        Debug.Log("Default Value");
                        break;
                    
                }
            }
            
            player.ShieldActive();
            Destroy(this.gameObject);
        }
    }
}
