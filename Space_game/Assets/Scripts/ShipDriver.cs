using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipDriver : MonoBehaviour
{
    int score = 0;
    [SerializeField] Text loseScreen;
    [SerializeField] Text scoreOut;
    [SerializeField] Text DistanceEnd;
    [SerializeField] float shipSpeed = 400f;
    [SerializeField] int step;
    [SerializeField] private GameObject explosion;

    float rightMax = 7, leftMax = -9,now;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
        score += Mathf.RoundToInt(step*Time.deltaTime);
        scoreOut.text = score.ToString()+"m";
    }

    void Fly()
    {
            now = transform.position.x;
            if (Input.GetKey(KeyCode.A) && now > -9)
            {
                rigidbody.AddRelativeForce(Vector3.left * (shipSpeed * Time.deltaTime));

            }
            if (Input.GetKey(KeyCode.D) && now < 7)
            {
                rigidbody.AddRelativeForce(Vector3.right * (shipSpeed * Time.deltaTime));
            }
        if (Input.GetKey(KeyCode.Escape)) SceneManager.LoadScene(0);
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "asteroid":
                Instantiate(explosion, this.transform.position,Quaternion.identity);
                loseScreen.text = "GAME OVER";
                DistanceEnd.text="Distance: "+score.ToString()+"m";
                Invoke("LoseGame",4.0f);
                gameObject.SetActive(false);
                break;
        }

    }

    private void LoseGame()
    {     
        SceneManager.LoadScene(0);
    }


}
