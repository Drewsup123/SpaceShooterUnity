using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text _GameOverText;
    void Start()
    {
        //  Makes sure that the game object is not visible at the start
        _GameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateLives(int livesLeft){
        if(livesLeft < 1){
            _GameOverText.gameObject.SetActive(true);
        }
    }
}
