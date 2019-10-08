using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _B_keepSpawning = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Allows us to Yield events
    IEnumerator SpawnRoutine(){
        // while loop
            // Instantiate enemy
            // yield 5 seconds
        while(_B_keepSpawning){
            Vector3 position = new Vector3(Random.Range(-6, 6), 7, 0);
            GameObject newEnemy = Instantiate(_enemy, position, Quaternion.identity);
            newEnemy.transform.SetParent(_enemyContainer.transform);
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void StopSpawnRoutine(){
        _B_keepSpawning = false;
    }
}
