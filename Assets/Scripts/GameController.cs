using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    // The player prefab.
    [Header("Player prefab")]
    public GameObject player;
    public GameObject ocean;
    // The actual instanced player which we control and interact with.
    public GameObject playerInstance;

    GameObject[] oceanInstance;
    private InputController input;

    void Awake()
    {
        input = GameObject.Find("InputController").GetComponent<InputController>();
        Application.targetFrameRate = 60;
        Screen.SetResolution(1280, 720, false);
    }


    void Start () {
        playerInstance = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        oceanInstance = new GameObject[9] {
            Instantiate(ocean, new Vector3(-64, -64, 0), Quaternion.identity) as GameObject,
            Instantiate(ocean, new Vector3(0, -64, 0), Quaternion.identity) as GameObject,
            Instantiate(ocean, new Vector3(64, -64, 0), Quaternion.identity) as GameObject,
            Instantiate(ocean, new Vector3(-64, 0, 0), Quaternion.identity) as GameObject,
            Instantiate(ocean, new Vector3(0, 0, 0), Quaternion.identity) as GameObject,
            Instantiate(ocean, new Vector3(64, 0, 0), Quaternion.identity) as GameObject,
            Instantiate(ocean, new Vector3(-64, 64, 0), Quaternion.identity) as GameObject,
            Instantiate(ocean, new Vector3(0, 64, 0), Quaternion.identity) as GameObject,
            Instantiate(ocean, new Vector3(64, 64, 0), Quaternion.identity) as GameObject,
        };
    }


    void Update () {

    }
}
