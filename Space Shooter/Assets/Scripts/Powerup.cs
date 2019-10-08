using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move down at the speed of 3m/s
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        // destroy at the bottom of the screen
        if(transform.position.y < -3.9f){
            Destroy(this.gameObject);
        }
    }

    //OnTriggerCollision 
        // If player is collision
            //Destroy(this.gameObject)
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Player player = other.gameObject.GetComponent<Player>();
            if(player != null){
                player.TripleActivate();
            }
            Destroy(this.gameObject);
        }
    }
}
