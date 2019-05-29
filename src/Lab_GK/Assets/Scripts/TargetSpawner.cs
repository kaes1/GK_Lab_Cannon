using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    //Begin of cube in which objects will be randomly spawned.
    public Vector3 A;
    //End of cube in which objects will be randomly spawned.
    public Vector3 B;
    public GameObject targetPrefab;
    private GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 firstPosition = new Vector3(Random.Range(A.x, B.x), 8.55f, 0);
        target = Instantiate(targetPrefab, firstPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            SpawnTargetRandomly();
    }

    private void SpawnTargetRandomly()
    {
        Vector3 randomPosition = new Vector3(Random.Range(A.x, B.x), Random.Range(A.y, B.y), Random.Range(A.z, B.z));
        target = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
    }

}
