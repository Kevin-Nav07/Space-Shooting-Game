using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawn = false;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerDeathTrue()
    {
        _stopSpawn = true;
    }

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawn == false)//infinite coroutine loop
        {
            //instantiate object called _enemyPrefab, at location with random x and fixed y and z, then quaternion.identity(which is rotation irrelevent)
            GameObject newEnemy = Instantiate (_enemyPrefab, new Vector3(Random.Range(-8f, 8f), 7, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds (5);//yield and wait for 5 seconds

        }
    }
}
