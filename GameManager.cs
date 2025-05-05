using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    #region settings
    public int Money { get; set; }
    public int CostToMoveOn { get; private set; }
    public List<Worker> OwnedWorkers { get; set; } = new List<Worker>();
    private int fee;
    private int award;
    public bool GameEnd { get; private set; } = false;
    
    private string sceneToLoad;
    public string SceneToLoad {
        get {
            return sceneToLoad;
        } private set {
            if(value.Length != 0)
                sceneToLoad = value;
            else
                Debug.LogError("Scene name left unspecified");
        }
    }
    private string sceneName;

    public void TakeFee() => Money -= fee;
    public void GiveAward() => Money += award;
    #endregion

    #region instance
    private static GameManager _instance;
    public static GameManager Instance { 
        get {
            if(_instance == null) 
                Debug.LogError("GameManager is NULL");
            
            return _instance;
        }
    }

    private void Awake() {
        if(_instance)
            Destroy(gameObject);
        else
            _instance = this;

        DontDestroyOnLoad(this);
        
        Money = 500000;
    }
    #endregion

    #region scene
    private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        sceneName = scene.name;
        Debug.Log(scene.name + ", " + mode);

        switch(sceneName) {
            case("CardboardBox"):
                fee = 5;
                award = 100;
                CostToMoveOn = 300;
                SceneToLoad = "CardboardBox";
                break;
            case("House"):
                fee = 50;
                award = 200;
                CostToMoveOn = 5000;
                SceneToLoad = "House";
                break;
            case("Office"):
                fee = 250;
                award = 500;
                CostToMoveOn = 150000;
                SceneToLoad = "Office";
                break;
            case("Lose"):
            case("Win"):
                Debug.Log("Wow!");
                break;
            case("Tutorial"):
            case("MainMenu"):
            case("HelpMenu"):
            case("CreditsMenu"):
            case("Workers"):
            case("Gamble"):
            case("Graph"):
                Debug.Log("GameManager doing nothing on scene change");
                break;
            default:
                Debug.LogError("Scene not in switch");
                break;
        }
    }
    #endregion
// 
    #region methods
    /// <summary>
    /// Use this so that you don't have to import the UnityEngine.SceneManagement library in every UI script.
    /// </summary>
    /// <param name="scene">the name of the scene to load</param>
    public void LoadNewScene(string scene) {
        if(Money < 0) { // always lose if negative
            SceneManager.LoadScene("Lose", LoadSceneMode.Single);
            return;
        } else if(Money == 0 && OwnedWorkers.Count == 0) { // only lose if no money AND no workers
            SceneManager.LoadScene("Lose", LoadSceneMode.Single);
            return;
        }

        if(SceneManager.GetActiveScene().name == "CardboardBox" && scene == "House")
            Money -= 200;
        if(SceneManager.GetActiveScene().name == "House" && scene == "Office")
            Money -= 4500;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    #endregion
}