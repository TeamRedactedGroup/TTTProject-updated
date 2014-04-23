//C#
using UnityEngine;
using System.Collections;
//Application Level 1
public class Newuser : MonoBehaviour {
    public string stringToEdit;
	void OnGUI () {
		//Create centered box
		GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 500, 500));
		// Make a background box

		GUI.Box(new Rect(10,10,500,500), "New User Input");
		// Make standard text saying enter name
		GUI.Label ( new Rect (50, 90, 280, 20), "  Please Enter Your Name  :");
		//Create text inputbox.
		stringToEdit = GUI.TextField(new Rect(20,150,280,30), stringToEdit,25);
		//create Enter button to input text

        if (GUI.Button(new Rect(20, 200, 280, 20), "Enter"))
            if (!PlayerPrefs.HasKey("player1"))
            {
                PlayerPrefs.SetInt("score1", 0);
                PlayerPrefs.SetString("player1", stringToEdit);
                Application.LoadLevel(0);
            }
            else if (PlayerPrefs.HasKey("player1"))
            {
                PlayerPrefs.SetInt("score2", 0);
                PlayerPrefs.SetString("player2", stringToEdit);
                Application.LoadLevel(0);
            }

		if(GUI.Button(new Rect(20,250,280,20), "Main Menu")) 
        {
			Application.LoadLevel(0);
		}
		
		GUI.EndGroup ();

	}
}