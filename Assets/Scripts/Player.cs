using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]//makes all private variables acessible by the Unity developers, but still keeps private status so other scripts cant change it
    private float _speed = 1.0f;
    public 
    void Start()

    {

        //current position of player will be , x=0, y =0, z= 0

        transform.position =  new Vector3(0, 0, 0);


        
    }

    // Update is called once per frame
    void Update()
    {
      CalcualteMovement();//every frame we run the movement code checking for user input

    }
    void CalcualteMovement()
    {
        //acess the player object, then acesses the translate function of the transform aspect to move it 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        //(move the vector3 to the right by (1,0,0),then multiply by factor of "speed" var and multiply further by the real time aspect
        transform.Translate(direction * _speed * Time.deltaTime);

       

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0),0);

        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);

        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }
}
