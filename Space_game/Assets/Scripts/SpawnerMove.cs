using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMove : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnerMoving());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnerMoving()
    {
        yield return new WaitForSeconds(4f);
        transform.position = new Vector3(Random.Range(-9.0f, 7.0f), transform.position.y, transform.position.z);
        StartCoroutine(SpawnerMoving());
    }
}
