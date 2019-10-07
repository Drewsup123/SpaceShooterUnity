using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn at the top
        // Move down at 4 meters per second
        // When / if it hits the bottom of the screen respawn at the top with random x position
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -4f){
            float randInt = Random.Range(-9, 6);
            transform.position = new Vector3(randInt, 6f, 0);
        }
    }
}
