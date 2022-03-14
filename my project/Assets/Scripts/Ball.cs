using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject splashPrefab;
    private GameManager gm;


    public float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        rb.AddForce(Vector3.up * jumpForce);
        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0f,-0.2f,0f), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);

        string metarialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        Debug.Log("Metaryal adý: " + metarialName);

       
        if(metarialName == "Unsafe Color (Instance)")
        {
            gm.RestartGame();

        }
        else if(metarialName == "Last Ring (Instance)")
        {
            Debug.Log("Next Level");
        }
}
}
