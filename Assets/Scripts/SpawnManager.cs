using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject[] _fruitPrefab;

    [SerializeField]
    private GameObject _bombPrefab;

    

    void Start()
    {
        StartCoroutine(FruitSpawner());
        StartCoroutine(BombSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FruitSpawner()
    {
        while (true)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-2.8f, 2.8f), 3f, 0);
            Instantiate(_fruitPrefab[Random.Range(0,3)], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(1f); // this waitforseconds means that once the fruit is droped, it will wait for few seconds to respawn new fruits 
        }
         
    }

    IEnumerator BombSpawner()
    {
        while (true)
        {
            Vector3 posToBombSpawn = new Vector3(Random.Range(-2.9f, 2.9f), 3f, 0);
            Instantiate(_bombPrefab, posToBombSpawn, Quaternion.identity);
            yield return new WaitForSeconds(15f);
        }
    }

    
}
