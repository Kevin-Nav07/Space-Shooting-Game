using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float _speed = 4f;
    void Start()
    {
        transform.position = new Vector3(Random.Range(-8f, 8f), 7.39f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move down at 4m per sec
        transform.Translate(Vector3.down * Time.deltaTime* _speed);

        //once enemy reaches bottom of screen, respawn at top with a rand x pos
        if(transform.position.y < -5f)
        {
            
            transform.position = new Vector3(Random.Range(-8f,8f), 7, 0);
        }


        
    }
    private void OnTriggerEnter(Collider other)// other specifies what is being colided with
    {
        Debug.Log("Hit " + other.transform.name);
        //if other is player, then damage player, and then destroy this enemy object
        if(other.tag == "Player")
        {
            //accesses the Player script component of the other object to call the damage method
            Player player = other.transform.GetComponent<Player>(); 
           if( player != null)//null check
            {
                player.Damage();
               
            }
            else
            {
           
            }
            Destroy(this.gameObject);
        }

        //if other is laser, then destroy enemy
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);//destroys laser
            Destroy(this.gameObject);//destroys enemy
        }
    }
}
