using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] Transform levelStart;
    [SerializeField] AudioClip levelMusic;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1;
        GameManager.Instance.PlayerSpawn(levelStart);
        audioSource.Play();
    }

    private void Update()
    {
        //GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
}
