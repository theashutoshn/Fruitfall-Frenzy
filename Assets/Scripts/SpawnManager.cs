using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject _fruitPrefab;


    void Start()
    {
        StartCoroutine(FruitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FruitSpawner()
    {
        while (true)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-2.9f, 2.9f), 3f, 0);
            Instantiate(_fruitPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(6f); // this waitforseconds means that once the fruit is droped, it will wait for few seconds to respawn new fruits 
        }
         
    }
}
