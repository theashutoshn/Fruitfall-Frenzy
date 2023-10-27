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

    [SerializeField]
    private GameObject _shieldPrefab;

    [SerializeField]
    private GameObject _speedPrefab;

    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(FruitSpawner());
        
        StartCoroutine(SpeedSpawner());

        Invoke("DelayBomb", 5f);
        Invoke("DelayShield", 10f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DelayShield()
    {
        StartCoroutine(ShieldSpawner());
    }
    
    public void DelayBomb()
    {
        StartCoroutine(BombSpawner());
    }
    
    IEnumerator FruitSpawner()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-2.8f, 2.8f), 3f, 0);
            Instantiate(_fruitPrefab[Random.Range(0,3)], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(0.5f); // this waitforseconds means that once the fruit is droped, it will wait for few seconds to respawn new fruits 
        }
         
    }

    IEnumerator BombSpawner()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToBombSpawn = new Vector3(Random.Range(-2.9f, 2.9f), 3f, 0);
            Instantiate(_bombPrefab, posToBombSpawn, Quaternion.identity);
            yield return new WaitForSeconds(5f);
            
        }
    }
    
    IEnumerator ShieldSpawner()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToShieldSpawn = new Vector3(Random.Range(-2.85f, 2.85f), 3f, 0);
            Instantiate(_shieldPrefab, posToShieldSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(10f, 15f));
        }
        
    }
    
    IEnumerator SpeedSpawner()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpeedSpawn = new Vector3(Random.Range(-2.85f, 2.85f), 3f, 0);
            Instantiate(_speedPrefab, posToSpeedSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f, 10f));
        }
        
    }

    public void OnPlayerDeath()
    {
        //Debug.Log("Player is Dead");
        _stopSpawning = true;  
    }

}
