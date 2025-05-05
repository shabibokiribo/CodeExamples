using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour {
    public GameObject[] pauseItems;
    private bool isPaused;

    private void Awake() {
        Time.timeScale = 1;
        isPaused = false;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            switch(isPaused) {
                case(true):
                    OnClickUnpause();
                    isPaused = false;
                    break;
                case(false):
                    OnClickPause();
                    isPaused = true;
                    break;
            }
        }
    }

    public void OnClickPause() {
        Time.timeScale = 0;
        foreach(Transform child in gameObject.transform) {
            child.gameObject.SetActive(false);
        } foreach(GameObject item in pauseItems) {
            item.gameObject.SetActive(true);
        }
    }

    public void OnClickUnpause() {
        Time.timeScale = 1;
        foreach(Transform child in gameObject.transform) {
            child.gameObject.SetActive(true);
        } foreach(GameObject item in pauseItems) {
            item.gameObject.SetActive(false);
        }
    }

    public void OnClickQuit() {
        SceneManager.LoadScene("MENU");
    }
}
