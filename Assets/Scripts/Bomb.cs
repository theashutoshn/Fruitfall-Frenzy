using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float _bombSpeed = 2f;

    [SerializeField]
    private AudioClip _bombClip;

    

    void Start()
    {
        transform.position = new Vector3(Random.Range(-2.19f, 2.91f), 3f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        BombMoveDown();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(_bombClip, transform.position);

            if(player != null)
            {
                player.Damage();
            }
            
            Destroy(this.gameObject);

        }
    }

    public void BombMoveDown()
    {
        transform.Translate(Vector3.down * _bombSpeed * Time.deltaTime);

        if (transform.position.y < -1)
        {
            transform.position = new Vector3(Random.Range(-2.19f, 2.91f), 3f, 0);
        }
    }

    
}
