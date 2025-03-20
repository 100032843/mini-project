using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // This script should be on the same GameObject as the TMP Text component
  
    private TMP_Text timerText; // This is the TMP Text component
    public TMP_Text goalText;
    public string playerModel;
    private float time;         // This keeps track of the time in seconds
    private bool stopFirstTimer;
    private bool stopSecondTimer;
    private string currentPlayerMesh;
    public string destroyableTag = "SmallObject"; // Set this in the Inspector
    void Start()
    {
        // Search this GameObject and get access to the TMP Text component
        timerText = GetComponent<TMP_Text>();
        time = 0f;              // Set the starting time to zero seconds
        stopFirstTimer = false;
        stopSecondTimer = true;
        DestroyRandomObjects();
    }

    void Update()
    {
        time += 30 * Time.deltaTime; // Add the fraction of a second that has passed this frame
        if (stopFirstTimer == false)
        {
            updateTimer(time);      // Update the UI display with the new time
        }

        if (stopSecondTimer == false)
        {
            updateTimer2(time);
        }
        currentPlayerMesh = PlayerPrefs.GetString("PlayerModel");
    }

    private void updateTimer(float currentTime)
    {
        // Use division and modulus operator to convert the float "time" into two integers
        // For the number of minutes and seconds that have passed
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Set the UI text to display this
        timerText.text = string.Format("Time Remaining: " + "{0:00}:{1:00}", minutes, 40 - seconds);
        
        if (seconds == 40)
        {   
            goalText.text = "You are the seeker!\nThe hider has transformed into an object somewhere.\nClick on objects that are out of place to find them!";
            time = 0f;
            stopFirstTimer = true;
            stopSecondTimer = false;
            
        }
    // string.Format() will display text how you want
        // ex: string.Format("Here is variable 1 {0} and variable 2 {1}, var1, var2);
        // The {0} and {1} refer to the first and second variable at the end of the format call
        // In the original line of code, the {0:00} means:
        // First zero means it is referring to the first variable after the comma (minutes)
        // The colon and two zeros after means display it as a two-digit number
    }
    private void updateTimer2(float currentTime)
    {
        // Use division and modulus operator to convert the float "time" into two integers
        // For the number of minutes and seconds that have passed
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Set the UI text to display this
        timerText.text = string.Format("Time Remaining: " + "{0:00}:{1:00}", 1-minutes, 60 - seconds);
        if (minutes == 2)
        {   
            goalText.text = "Times up!\nThe hider has won!\nThe hider was a "+currentPlayerMesh;
            time = 0f;
            stopSecondTimer = true;
        }
        // string.Format() will display text how you want
        // ex: string.Format("Here is variable 1 {0} and variable 2 {1}, var1, var2);
        // The {0} and {1} refer to the first and second variable at the end of the format call
        // In the original line of code, the {0:00} means:
        // First zero means it is referring to the first variable after the comma (minutes)
        // The colon and two zeros after means display it as a two-digit number
    }


    public void DestroyRandomObjects()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(destroyableTag);

        if (objectsToDestroy.Length > 0)
        {
            foreach (GameObject obj in objectsToDestroy)
            {       
                    if (Random.Range(0,4) == 0)
                    {
                        Destroy(obj); 
                    }
            }
        }
    }
}