using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    GameController gameController;

    void Awake() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

    // Called at the end of each frame
    void LateUpdate() {
        GameObject player = gameController.playerInstance;
        Camera.main.transform.position = new Vector3(transform.position.x + 8, transform.position.y, Camera.main.transform.position.z);
    }
}
