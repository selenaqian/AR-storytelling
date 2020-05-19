using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using TMPro;

public class porridge_inScene : MonoBehaviour
{
    public ARSessionOrigin ar_session;
    public GameObject eatenPorridge;
    public GameObject porridge;
    public GameObject worldScripts;
    public TextMeshProUGUI brokenMessage;
    public GameObject goldilocks;
    
    private MarkerPrefabs[] allObjects;
    private Collider goldilocksCollider;
    private bool valid;
    
    // Start is called before the first frame update
    void Start()
    {
        if (ar_session.GetComponent<SwitchPrefab>().markerPrefabCombos != null)
        {
            allObjects = ar_session.GetComponent<SwitchPrefab>().markerPrefabCombos;
        }
        else Debug.Log("marker prefab combos null");
                
        if (goldilocks.GetComponent<Collider>() != null)
        {
            goldilocksCollider = goldilocks.GetComponent<Collider>();
        }
        else Debug.Log("goldilocks collider null");
        
    }

    // Update is called once per frame
    void Update()
    {
    valid = worldScripts.GetComponent<ActiveActions>().valid;
    if(valid && goldilocks.activeSelf) {
        Debug.Log("valid");
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("sending out a ray");
            Debug.Log(Input.GetTouch(0).position);
            var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Debug.Log(ray);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("ray hit!");
                GameObject obj = hit.collider.gameObject;
                Debug.Log(obj);
                
                if(obj == porridge)
                {
                    Debug.Log("hit porridge");
                    allObjects[1].targetPrefab = eatenPorridge;
                    worldScripts.GetComponent<ActiveActions>().porridgeEaten = true;
                    brokenMessage.text = "The porridge is all gone. Wait...that belongs to someone else!";
                    Debug.Log(worldScripts.GetComponent<ActiveActions>().porridgeEaten + " " + allObjects[1].targetPrefab);
                    Debug.Log(gameObject);
                    gameObject.SetActive(false);
                }
            }
        }
        
        if (goldilocksCollider.bounds.Intersects(gameObject.GetComponent<Collider>().bounds))
        {
            Debug.Log("goldilocks ran into porridge");
            allObjects[1].targetPrefab = eatenPorridge;
            worldScripts.GetComponent<ActiveActions>().porridgeEaten = true;
            if(brokenMessage != null) Debug.Log(brokenMessage);
            else Debug.Log("broken message null");
            //brokenMessage.gameObject.SetActive(true);
            brokenMessage.text = "The porridge is all gone. Wait...that belongs to someone else!";
            Debug.Log(gameObject);
            gameObject.SetActive(false);
        }
    }
    }
}
