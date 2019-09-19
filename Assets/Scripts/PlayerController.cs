using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;

    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);
        if (Input.GetKeyDown("space") && GetComponent<Rigidbody>().transform.position.y <= 0.5f)
        {
            rb.AddForce(jump);
        }

        rb.AddForce(movement * speed); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();
        }
        else if (other.gameObject.CompareTag("Pick Up 5pts"))
        {
            other.gameObject.SetActive(false);
            count = count + 5;
            setCountText();
        }
    }
     void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 28)
        {
            winText.text = "You Win!";
        }
    }
}
