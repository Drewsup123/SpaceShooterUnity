using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private bool _B_gameOver = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && _B_gameOver == true){
            SceneManager.LoadScene(0); // Game Scene
        }
    }

    public void setGameOver(){
        _B_gameOver = true;
    }
}
