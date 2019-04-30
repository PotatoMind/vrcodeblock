using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 10f;

    // Whether the Google Cardboard user is gazing at this button.
    private bool isLookedAt = false;

    // Has the object been picked up?
    private bool isPickedUp = false;
 
    // How long the user can gaze at this before the button is clicked.
    public float timerDuration = 5f;

    public float pickUpStopThreshold = 0.01f;

    private float elapsedTime = 0f;
    
    private float pickUpTimer = 0f;
 
    // Count time the player has been gazing at the button.
    private float lookTimer = 0f;

    // Set to reticle growth speed
    public float growthSpeed = 2f;
    
    // Graphical progress indicator.
    private GameObject gazeTimer;

    private Vector3 mLastPosition;

    Color color = Color.red;
 
    // Use this for initialization
    void Start () {
        gazeTimer = GameObject.Find("GvrReticlePointer");
        GvrReticlePointer script = gazeTimer.GetComponent<GvrReticlePointer>();
        if (script) {
            gazeTimer.GetComponent<GvrReticlePointer>().reticleGrowthSpeed = growthSpeed;
        }
        mLastPosition = transform.position;
        color = GetComponent<Renderer>().material.color;
    }
    
    
    void Update ()
    {
        // While player is looking at this button.
        if (isLookedAt) {
            if (isPickedUp) {
                elapsedTime += Time.deltaTime;
                mLastPosition = transform.position;

                Ray ray = new Ray(gazeTimer.transform.position, gazeTimer.transform.forward);
                float dist = Vector3.Distance(gazeTimer.transform.position, transform.position);
                Debug.Log(dist);
                transform.position = ray.GetPoint(dist);

                float speed = (transform.position - this.mLastPosition).magnitude / elapsedTime;
                //Debug.Log(speed);
                if (speed < pickUpStopThreshold) {
                    pickUpTimer += Time.deltaTime * growthSpeed;

                    if (pickUpTimer > timerDuration) {
                        pickUpTimer = 0f;
                        elapsedTime = 0f;
                        isPickedUp = false;
                        GetComponent<Renderer>().material.color = color;
                    }
                }
            } else {
                // Increment the gaze timer.
                lookTimer += Time.deltaTime * growthSpeed;
    
                // Gaze time exceeded limit - button is considered clicked.
                if (lookTimer > timerDuration) {
                    lookTimer = 0f;
                    isPickedUp = true;
                    GetComponent<Renderer>().material.color = Color.grey;
                }
            }
        }
        // Not gazing at this anymore, reset everything.
        else {
            lookTimer = 0f;
        }
    }

    // Record whether Google Cardboard user is gazing at the button.
    // gazedAt: Set it to the value passed from event trigger.
    public void setGazedAt(bool gazedAt) {
        isLookedAt = gazedAt;
    }
}
