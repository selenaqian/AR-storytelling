using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DifferentImageTracking : MonoBehaviour
{
    [Header("The length of this list must match the number of images in Reference Image Library")]
    public List<GameObject> ObjectsToPlace;
    public Text debug;
    //public GameObject preloadedImage;
    private int refImageCount;
    private Dictionary<string, GameObject> allObjects;
    private ARTrackedImageManager arTrackedImageManager;
    private IReferenceImageLibrary refLibrary;
 
    void Awake()
    {
        arTrackedImageManager = GetComponent<ARTrackedImageManager>();
        //debug.text = "Awake";
    }
 
    private void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
 
    }
 
    private void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }
 
    private void Start()
    {
        refLibrary = arTrackedImageManager.referenceLibrary;
        refImageCount = refLibrary.count;
        LoadObjectDictionary();
        //debug.text = "start";
    }
 
    void LoadObjectDictionary()
    {
        allObjects = new Dictionary<string, GameObject>();
        for (int i = 0; i < refImageCount; i++)
        {
            GameObject newARObject = Instantiate(ObjectsToPlace[i], Vector3.zero, Quaternion.identity);
            allObjects.Add(refLibrary[i].name, newARObject);
            newARObject.SetActive(false);
//            allObjects.Add(refLibrary[i].name, ObjectsToPlace[i]);
//            ObjectsToPlace[i].SetActive(false);
            //debug.text = "Dictionary loaded";
        }
    }
 
    void ActivateTrackedObject(string _imageName)
    {
        allObjects[_imageName].SetActive(true);
        debug.text += _imageName;
        //debug.text = "scanned" + _imageName + "preloaded" + preloadedImage.name;
        //if (preloadedImage != allObjects[_imageName])
        //{ preloadedImage.SetActive(false);
            //debug.text = "scannedandreplaced with" + allObjects[_imageName];
         
        //};
        //preloadedImage = allObjects[_imageName];
    }
 
    public void OnImageChanged(ARTrackedImagesChangedEventArgs _args)
    {
        /**foreach (var myObject in allObjects) {
            foreach (var addedImage in _args.added)
            {
            if(Equals(myObject.Key, addedImage.referenceImage.name)) {continue;}
            allObjects[addedImage.referenceImage.name].SetActive(false);
            }
        }*/
        debug.text = "added: ";

        foreach (var addedImage in _args.added)
        {
            if(addedImage.trackingState == TrackingState.Tracking)
            {
                ActivateTrackedObject(addedImage.referenceImage.name);
            }
            /**if (addedImage.referenceImage.name == "DEATH_TAROT_GREYSCALE")
            {
                arTrackedImageManager.trackedImagePrefab = allObjects["DEATH_TAROT_GREYSCALE"];
            }
            else if (addedImage.referenceImage.name == "qr_code")
            {
                arTrackedImageManager.trackedImagePrefab = allObjects["qr_code"];
            }*/
            else
            {
                debug.text += "removed: ";
                foreach(var entry in allObjects)
                {
                    debug.text += entry.Value.name;
                    entry.Value.SetActive(false);
                }
            }
        }
        
        debug.text += "removed: ";
        foreach (var removed in _args.removed)
        {
            allObjects[removed.referenceImage.name].SetActive(false);
            debug.text += removed.referenceImage.name;
        }
 
        foreach (var updated in _args.updated)
        {
            allObjects[updated.referenceImage.name].transform.position = updated.transform.position;
            allObjects[updated.referenceImage.name].transform.rotation = updated.transform.rotation;
        }
    }
}
