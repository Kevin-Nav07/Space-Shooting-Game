using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 8f;
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*speed*Time.deltaTime);//translates the laser upward 

        //if laser has a position of > 8, get rid of cloned laser object to reduce space
        if(transform.position.y > 8f)
        {
            Destroy(this.gameObject);//destroys the current game object attatched to the script
        }

        
    }
  
}
