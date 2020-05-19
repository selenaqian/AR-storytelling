using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActiveActions : MonoBehaviour
{
    public List<GameObject> SceneObjects; // chairs, broken chairs, porridge, eaten porridge, beds, beds asleep, trees, bridge/river, broken bridge
    public List<GameObject> CharacterObjects; // goldilocks is index 0, bears is 1
    public int goldilocksLocation; // same order as scene, starting with index 0
    public int bearsLocation;
    public bool chairsBroken;
    public bool porridgeEaten;
    public bool bedsAsleep;
    public bool bridgeBroken;
    public bool suspicious;
    public int totalScenes; // number of scenes so far
    public TextMeshProUGUI error;
    public bool valid;
    public TextMeshProUGUI brokenMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void LateUpdate()
    {
        //if(brokenMessage.text == "") {
            if(CheckActiveCharObjects() < 1)
            {
                error.text = "Add a character.";
                brokenMessage.text = "";
                valid = false;
            }
            else if(CheckActiveSceneObjects() < 1)
            {
                error.text = "Add a scene.";
                brokenMessage.text = "";
                valid = false;
            }
            else if(CheckActiveCharObjects() > 1)
            {
                error.text = "Too many characters!";
                brokenMessage.text = "";
                valid = false;
            }
            else if(CheckActiveSceneObjects() > 1)
            {
                error.text = "Too many scenes!";
                brokenMessage.text = "";
                valid = false;
            }
            else
            {
                error.text = "";
                CheckActives();
                // valid also need to check if bedsAsleep - not valid if goldilocks is the character and is already asleep - then need show message that goldilocks is asleep!
                if(bedsAsleep && CharacterObjects[0].activeSelf)
                {
                    valid = false;
                    brokenMessage.text = "Goldilocks is fast asleep!";
                }
                else valid = true;
                // check if locations are equal
            }
        //}
    }
    
    //method to check the number of active objects
    int CheckActiveSceneObjects()
    {
        int activeSceneObjects = 0;
        foreach (GameObject o in SceneObjects)
        {
            if(o.activeSelf)
            {
                activeSceneObjects++;
            }
        }
        return activeSceneObjects;
    }
    
    int CheckActiveCharObjects()
    {
        int activeCharObjects = 0;
        foreach (GameObject o in CharacterObjects)
        {
            if(o.activeSelf)
            {
                activeCharObjects++;
            }
        }
        return activeCharObjects;
    }
    
    //method to check which objects are active + do stuff - need a combo of Scene and Character
    //TODO: FIX THIS - most of the stuff is happening in the objects themselves
    void CheckActives()
    {
        //goldilocks
        if(CharacterObjects[0].activeInHierarchy)
        {
            for(int i=0; i < SceneObjects.Count; i++)
            {
                if(SceneObjects[i].activeInHierarchy)
                {
                    goldilocksLocation = i;
                    Debug.Log("goldilocks " + i);
                }
            }
            
            //chairs
            /*if(SceneObjects[0].activeInHierarchy)
            {
                //need the chairs object to do the stuff so idk if there needs to be much here?
            }
            //porridge
            else if(SceneObjects[1].activeInHierarchy)
            {
            
            }
            //beds
            else if(SceneObjects[2].activeInHierarchy)
            {
            
            }
            //trees
            else if(SceneObjects[3].activeInHierarchy)
            {
            }
            //bridge/river
            else if(SceneObjects[4].activeInHierarchy)
            {
            
            }*/
        }
        
        //bears
        if(CharacterObjects[1].activeInHierarchy)
        {
            for(int i=0; i < SceneObjects.Count; i++)
            {
                if(SceneObjects[i].activeInHierarchy)
                {
                    bearsLocation = i;
                    Debug.Log("bears " + i);
                }
            }
            
            //chairs
            /*if(SceneObjects[0].activeInHierarchy)
            {
                //need the chairs object to do the stuff so idk if there needs to be much here?
            }
            //porridge
            else if(SceneObjects[1].activeInHierarchy)
            {
            
            }
            //beds
            else if(SceneObjects[2].activeInHierarchy)
            {
            
            }
            //trees
            else if(SceneObjects[3].activeInHierarchy)
            {
                //check goldilock's location and send to end scene if reached an outcome
                //if not an outcome and broken then just show some text about dismay and stuff
                // put this stuff in bears!
            }
            //bridge/river
            else if(SceneObjects[4].activeInHierarchy)
            {
            
            }*/
        }
    }
}
