using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class pickUP : MonoBehaviour
{

  
    private Scene scene; // scene manager stuff
    public GameObject objPosition;
    bool canPickup;
    public GameObject item;
    public GameObject itemChild;
    public bool hasItem;
    public AudioSource pickupSound;
    public AudioClip pickupClip;
    public int kidsCollected = 0;
    public TMP_Text kidsCollectedText;
    public bool hasBone;

    MoveChild mc;
    public List<GameObject> kids;

    public GameObject bone;
    public GameObject dog;

    Scene curScene;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        item = null;
        canPickup = false;
        hasItem = false;

        curScene = SceneManager.GetActiveScene();
        sceneName = curScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (item == kids[0])
        {
            mc = kids[0].GetComponent<MoveChild>();
        }
        if (item == kids[1])
        {
            mc = kids[1].GetComponent<MoveChild>();
        }
        if (item == kids[2])
        {
            mc = kids[2].GetComponent<MoveChild>();
        }
        if (item == kids[3])
        {
            mc = kids[3].GetComponent<MoveChild>();
        }
        if (item == kids[4])
        {
            mc = kids[4].GetComponent<MoveChild>();
        }


        if (canPickup == true) // if youve entered the objects collider
        {
            if (Input.GetKeyDown("e")) 
            {
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.position = objPosition.transform.position;
                item.transform.parent = objPosition.transform;
                hasItem = true;
                mc.agent.enabled = false;
            }
        }
        if (Input.GetKeyDown("q") && hasItem == true)
        {
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = null;
            mc.agent.enabled = true;
            item = null;


        }
        

        if(kidsCollected >= 5)
        {
            Invoke("Winner", 0.5f);
        }
        if (kidsCollected == 10 && sceneName == "LevelTwo")
        {
            Invoke("Winner", 1.0f);
        }
        kidsCollectedText.text = "Kids Collected: " + kidsCollected;

    }

    private void FixedUpdate()
    {
        if (sceneName != "LevelOne" && sceneName != "LevelTwo")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            canPickup = true;
            item = other.gameObject;
            //itemChild = other.gameObject.transform.GetChild(0).gameObject;
        }
        if(other.gameObject.tag == "child")
        {
            canPickup = true;
            item = other.gameObject;
            pickupSound.clip = pickupClip;
            pickupSound.Play(); //play pickup sound

        }
        if(other.gameObject.tag == "bone")
        {
            canPickup = true;
            item = other.gameObject;
            hasBone = true;
        }
        if (other.gameObject.tag == "dog" && item == bone)
        {
            dog.GetComponent<Rigidbody>().isKinematic = true;
        }
       
    }

    public void Winner()
    {
       if (sceneName == "LevelOne")
       {
           SceneManager.LoadScene("Transition"); //Change to Win Scene what created
       }

       if (sceneName == "LevelTwo")
       {
           SceneManager.LoadScene("Win");
       }
            
    }
    
    private void OnTriggerExit(Collider other)
    {
        canPickup = false;
    }

   
}
