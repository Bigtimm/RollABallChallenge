using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public float speed;
    public Text countText;
    public Text winText;
    public Text lifeText;
    public Text totalText;
    public Text loseText;
    private Rigidbody rb;
    private int count;
    private int life;
    private int total;
    private int lose;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        life = 3;
        total = 0;
        SetCountText ();
        winText.text = "";
        loseText.text = "";
    }

   void FixedUpdate ()
   {
       float moveHorizontal = Input.GetAxis ("Horizontal");
       float moveVertical = Input.GetAxis ("Vertical");

       Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

       rb.AddForce (movement * speed);

       if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
   }
    
     void OnTriggerEnter(Collider other) 
   {
       if (other.gameObject.CompareTag("Pick Up"))
       {
           other.gameObject.SetActive (false);
           count = count + 1;
           SetCountText ();
       }

       if (other.gameObject.CompareTag("Pick Up"))
       {
           other.gameObject.SetActive (false);
           total = total + 1;
           SetCountText ();
       }
      
       if (other.gameObject.CompareTag("Enemy"))
       {
           other.gameObject.SetActive (false);
           count = count - 1;
           SetCountText ();
       }
       
       if (other.gameObject.CompareTag("Enemy"))
       {
           other.gameObject.SetActive (false);
           life = life - 1;
           SetCountText ();
       }
       
   }
     void SetCountText()
     {
         totalText.text = "Total Collected: " + total.ToString();

         lifeText.text = "Lives: " + life.ToString();
         if (life <= 0)
         {
             loseText.text = "You Lose...";
         }
         if (life == 0)
       {
           gameObject.SetActive(false);
       }

       if (count == 15)
       {
           gameObject.SetActive(false);
       }
       

         countText.text = "Score: " + count.ToString();
         if (count >= 15)
         {
             winText.text = "You Win!";
         }
     }
}
