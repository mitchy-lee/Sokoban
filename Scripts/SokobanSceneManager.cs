using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SokobanSceneManager : MonoBehaviour
{
    public LayerMask boxLayer;            // Layer for boxes
    public LayerMask triggerPadLayer;     // Layer for trigger pads
    public float checkRadius = 0.1f;      // Radius for checking if boxes are on trigger pads
    public string nextSceneName;          // The name of the next scene to load
    
    private List<Collider2D> triggerPads; // List of all trigger pads in the scene

    void Start()
    {
        // Find all trigger pads in the scene (ensure trigger pads are tagged appropriately)
        triggerPads = new List<Collider2D>(GameObject.FindGameObjectsWithTag("TriggerPad").Length);
        
        foreach (GameObject pad in GameObject.FindGameObjectsWithTag("TriggerPad"))
        {
            triggerPads.Add(pad.GetComponent<Collider2D>());
        }
    }

    void Update()
    {
        // Check if all trigger pads are covered
        if (AreAllTriggerPadsCovered())
        {
            Debug.Log("All boxes are on trigger pads! Moving to the next level...");
            LoadNextLevel();
        }
    }

    // Check if all trigger pads are covered by boxes
    private bool AreAllTriggerPadsCovered()
    {
        foreach (var pad in triggerPads)
        {
            // Check if a box is covering the trigger pad
            if (!IsPadCoveredByBox(pad))
            {
                return false; // If any trigger pad isn't covered, return false
            }
        }
        return true; // All pads are covered
    }

    // Check if a trigger pad is covered by a box
    private bool IsPadCoveredByBox(Collider2D pad)
    {
        // Overlap circle to check if there's a box on the trigger pad
        return Physics2D.OverlapCircle(pad.transform.position, checkRadius, boxLayer);
    }

    // Load the next level by its scene name
    private void LoadNextLevel()
    {
        // Load the next scene (ensure the scene name is correct)
        SceneManager.LoadScene(nextSceneName);
    }
}
