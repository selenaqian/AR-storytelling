using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class trees_inScene : MonoBehaviour
{
    public GameObject worldScripts;
    public GameObject goldilocks;
    public GameObject bears;
    public TextMeshProUGUI brokenMessage;
    
    private bool valid;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        valid = worldScripts.GetComponent<ActiveActions>().valid;   
        if(valid && goldilocks.activeSelf)
        {
            brokenMessage.text = "Goldilocks flounces through the forest...\nWhat next?";
        }
        
        if(valid && bears.activeSelf)
        {
            brokenMessage.text = "The bears continue on their walk through the forest.\nWhat next?";
        }
    }
}
