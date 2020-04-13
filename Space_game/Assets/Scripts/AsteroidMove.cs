using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    [SerializeField] float astSpeed = 0.5f;
    float boost = 1;
    float DisableTime = 20f;
    int RotXYZ;
    
    // Start is called before the first frame update
    void Start()
    {
        
        RotXYZ = Random.Range(0, 3);
        Invoke("SetDisabled",20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        FlyRotation();
        if (Input.GetKey(KeyCode.W)) { boost = 7f; } else {  if (boost != 1f) StartCoroutine(BoostSlower()); }     
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-astSpeed*Time.deltaTime*boost);

        
    }

    private void SetDisabled()
    {
        Destroy(gameObject); 
    }

    IEnumerator BoostSlower()
    {
        yield return new WaitForSeconds(1);
            if(boost > 1) { boost -= 0.25f;
            StartCoroutine(BoostSlower()); }        
    }

    private void FlyRotation()
    {
        switch (RotXYZ)
        {
            case (0): transform.Rotate(15 * Time.deltaTime, 0, 0); break;
            case (1): transform.Rotate(0, 15 * Time.deltaTime, 0); break;
            case (2): transform.Rotate(0, 0, 15 * Time.deltaTime); break;
        }
        
    }
}
