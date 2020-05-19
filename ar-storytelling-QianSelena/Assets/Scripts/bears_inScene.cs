using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using TMPro;

public class bears_inScene : MonoBehaviour
{
    public ARSessionOrigin ar_session;
    public TextMeshProUGUI brokenMessage;
    public GameObject worldScripts;
    public GameObject chairs;
    public GameObject porridge;
    public GameObject beds;
    public GameObject trees;
    public GameObject bridge;
    public GameObject chairsBroken;
    public GameObject porridgeEaten;
    public GameObject bedsAsleep;
    public GameObject bridgeBroken;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chairs.activeInHierarchy)
        {
            brokenMessage.text = "The bears take a rest in their chairs.\nWhat next?";
        }
        else if(chairsBroken.activeInHierarchy)
        {
            brokenMessage.text = "The bears see the broken chairs! They're not happy...\nWhat next?";
            worldScripts.GetComponent<ActiveActions>().suspicious = true;
        }
        else if(porridge.activeInHierarchy)
        {
            brokenMessage.text = "The bears enjoy their porridge.\nWhat next?";
        }
        else if(porridgeEaten.activeInHierarchy)
        {
            brokenMessage.text = "The bears see the eaten porridge! They're not happy...\nWhat next?";
            worldScripts.GetComponent<ActiveActions>().suspicious = true;
        }
        else if(beds.activeInHierarchy)
        {
            brokenMessage.text = "The bears take a quick nap.\nWhat next?";
        }
        else if(bedsAsleep.activeInHierarchy)
        {
            brokenMessage.text = "The bears see Goldilocks asleep in their bed! They're not happy...\nWhat next?";
            worldScripts.GetComponent<ActiveActions>().suspicious = true;
        }
        else if(trees.activeInHierarchy)
        {
            brokenMessage.text = "The bears stroll through the forest\nWhat next?";
        }
        else if(bridge.activeInHierarchy)
        {
            brokenMessage.text = "The bears walk across the bridge.\nWhat next?";
        }
        else if(bridgeBroken.activeInHierarchy)
        {
            brokenMessage.text = "The bears see the broken bridge! They're not happy...\nWhat next?";
            worldScripts.GetComponent<ActiveActions>().suspicious = true;
        }
    }
}
