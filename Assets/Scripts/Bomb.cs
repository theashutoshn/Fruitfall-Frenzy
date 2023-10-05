using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float _bombSpeed = 5f;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-2.19f, 2.91f), 3f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _bombSpeed * Time.deltaTime);

        if(transform.position.y < -1)
        {
            transform.position = new Vector3(Random.Range(-2.19f, 2.91f), 3f, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }
            
            Destroy(this.gameObject);

        }
    }
}
