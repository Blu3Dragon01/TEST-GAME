 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    //Game Manager Instance
    public static GameManager Instance => instance;
    static GameManager instance;

    //Player Controller Instance
    [SerializeField] PlayerController PlayerPrefab;
    public PlayerController PlayerInstance => playerInstance;
    PlayerController playerInstance = null;
    Transform currentCheckPoint;

    public UnityEvent <int> OnLifeValueChanged;

    //Audio
    AudioSource audioSource;
    [SerializeField] AudioClip gameOver;

    //life and score stuff
    [SerializeField] int maxLives = 2;
    private int _lives;
    public int lives
    {
        get => _lives;
        set
        {
            if (_lives > value)
                Respawn();


            _lives = value;

            //we've increased past our max lives so we should just be set to our max lives
            if (_lives > maxLives)
                _lives = maxLives;

            if (_lives <= 0)
            {
                GameOver();
            }

            //if (OnLifeValueChanged != null)

                OnLifeValueChanged?.Invoke(_lives);

            //if (TestMode) Debug.Log("Lives has been set to: " + _lives.ToString());
        }
    }

    private int _score = 0;
    public int score
    {
        get => _score;
        set
        {
            //if (score < value)
            //invalid setting so throw error = possibly return out of function before setting varible

            _score = value;

            //if (TestMode) Debug.Log("Score has been set to: " + _score.ToString());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene();
        //SceneManager.GetActiveScene();
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        _lives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            int buildIndex = (SceneManager.GetActiveScene().name == "Level") ? 0 : 2;
            SceneManager.LoadScene(buildIndex);

            //  these lines of code behaves the same as the lines above

            /*if (SceneManager.GetActiveScene().name == "Level")
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(1);
            */
            if (SceneManager.GetActiveScene().name == "GameOver")
            {
                SceneManager.LoadScene("Title");
            }
            if (SceneManager.GetActiveScene().name == "Title")
            {
                SceneManager.LoadScene("Level");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UpdateCheckpoint(GameObject.FindGameObjectWithTag("CheckPoint").transform);
            Debug.Log("CheckPoint Updated");
        }
    }
    public void ChangeScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        
    }
    public void PlayerSpawn (Transform spawnLocation)
    {
        playerInstance = Instantiate(PlayerPrefab, spawnLocation.position, spawnLocation.rotation);
        currentCheckPoint = spawnLocation;
    }

    public void UpdateCheckpoint (Transform updateCheckpoint)
    {
        Debug.Log("CheckPoint Updated");
        currentCheckPoint = updateCheckpoint;
    }

    void Respawn()
    {
        Debug.Log("Calling Respawn");
        Debug.Log("Lives:" + _lives);
        playerInstance.transform.position = currentCheckPoint.position;
    }

    void GameOver()
    {
        Debug.Log("GameOver Being Called");
        SceneManager.LoadScene("GameOver");
        audioSource.PlayOneShot(gameOver);
    }
}
