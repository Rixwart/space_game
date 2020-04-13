using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstSpawner : MonoBehaviour
{
    int randomShance;
    public GameObject[] bullet;
    public Transform shoot;
    float boost = 1f;
    public float timeShoot = 5f;

    // Start is called before the first frame update
    void Start()
    {
        shoot.transform.position = new Vector3(transform.position.x, transform.position.y , transform.position.z);
        StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            boost = 2.5f;
        }
        else
        {
            boost = 1f;
        }
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(timeShoot);
        randomShance =Mathf.RoundToInt(Random.Range(0.0f, 1.0f));
        Instantiate(bullet[randomShance], shoot.transform.position, transform.rotation);
        bullet[randomShance].SetActive(true);
        StartCoroutine(Shooting());
    }

}
