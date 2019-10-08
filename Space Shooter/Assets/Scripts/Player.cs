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
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _nextFire = -1f;
    [SerializeField]
    private SpawnManager _spawnManager;
    private int _lives = 3;
    // Need a variable for triple shot
    [SerializeField]
    private GameObject _tripleShot;
    private bool _tripleShotActive = false;
    [SerializeField]
    private UI_Manager _uiManager;
    [SerializeField]
    private Game_Manager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //Starting Position -> position = new position(0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
        // Updates variable spawn manager to the spawn manager component
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _gameManager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(Input.GetKeyDown(KeyCode.Space) && Time.time >= _nextFire){
            fireLaser();
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

    void fireLaser(){
        // if space key is hit
        // Spawn laser
        _nextFire = Time.time + _fireRate;
        if(_tripleShotActive){
            Instantiate(_tripleShot, new Vector3(transform.position.x, transform.position.y + 0.7f, 0), Quaternion.identity);
        }else{
            Instantiate(_laser, new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), Quaternion.identity);
        }
    }

    public void Damage(){
        _lives--;
        // Communicate with the spawn manager
        if(_uiManager != null && _gameManager != null){
            _uiManager.updateLives(_lives);
        }
        if(_lives < 1){
            if(_spawnManager != null){
                _spawnManager.StopSpawnRoutine();
            }
            if(_gameManager != null){
                _gameManager.setGameOver();
            }else{
                Debug.Log("_gamemanager is null");
            }
            Destroy(this.gameObject);
        }
    }

    public void TripleActivate(){
        // Triple shot becomes active
        // Triple shot is turned off after some odd seconds
        _tripleShotActive = true;
        StartCoroutine(PowerupActive());
    }

    IEnumerator PowerupActive(){
        yield return new WaitForSeconds(5.0f);
        _tripleShotActive = false;
    }
}
