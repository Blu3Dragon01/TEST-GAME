 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene();
        //SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            int buildIndex = (SceneManager.GetActiveScene().name == "Level") ? 0 : 1;
            SceneManager.LoadScene(buildIndex);

            /*  these lines of code behaves the same as the lines above
            if (SceneManager.GetActiveScene().name == "Level")
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(1);
            */
            
        }
    }
}
