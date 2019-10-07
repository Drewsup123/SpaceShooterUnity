using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Defining variables in C# basically the same as C++
    // (Private or Public) (Data type int, float, bool, string) (Name of variable) (Optional Value if I want)
    // [SerializeField] Use this if you want designers to see and edit a private variable

    private float _speed = 3.5f;
    [SerializeField]
    public GameObject _laser;
    // Start is called before the first frame update
    void Start()
    {
        //Starting Position -> position = new position(0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        // if space key is hit
        // Spawn laser
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(_laser, transform.position, Quaternion.identity);
        }
    }

    void Movement(){
        // horizontal input will be -1, 0, or 1
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
                            // This is equal to new Vector3(1, 0, 0) same with .left .up etc..
        // transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        // transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0)* _speed * Time.deltaTime);
        if(transform.position.x >= 9.25f){
            transform.position = new Vector3(-9.25f, transform.position.y, 0);
        }
        else if(transform.position.x <= -9.25f){
            transform.position = new Vector3(9.25f, transform.position.y, 0);
        }
        if(transform.position.y >= 6f){
            transform.position = new Vector3(transform.position.x, 6f, 0);
        }
        else if(transform.position.y <= -3.9f){
            transform.position = new Vector3(transform.position.x, -3.9f, 0);
        }
    }
}
