using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour


{
    public float speed;
    public Text countText;
    private Rigidbody2D rb2d;
    private int count;
    public int life;
    public Text winText;
    public Text lifeText;
    public Text looseText;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        winText.text = "";
        life = 3;
        SetLifeText();
        looseText.text = "";
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

    }
    private void Update()
    {
        if (Input.GetKey("escape"))
            {
            Application.Quit();
            }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            life = life - 1;
            SetLifeText();
        }

        if (count == 12)
        {
            transform.position = new Vector2(0.0f, 50.0f);
        }

    }
    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 20)
        {
            winText.text = "You win! Game created by Tennyson Branch";
        }
        
    }
    void SetLifeText()
    {
        lifeText.text = "Lives: " + life.ToString();
        if (life <= 0)
        {
            looseText.text = "Loooooser";
            Destroy(this);
        }
    }
}
