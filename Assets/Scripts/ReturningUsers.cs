using UnityEngine;
using System.Collections;
//Application Level 2
public class ReturningUsers : MonoBehaviour {

    

    void OnGUI()
    {

        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 500, 500));
        // Make a background boxGUI.Label ( new Rect (50, 100, 230, 20), "Robert  -Team Lead");
        GUI.Box(new Rect(10, 10, 250, 300), "Users");
        // Make standard text saying enter name
        if (PlayerPrefs.HasKey("player1"))
        {
            if (GUI.Button(new Rect(20, 100, 230, 20), PlayerPrefs.GetString("player1") + ": Win(s) = " + PlayerPrefs.GetInt("score1")))
            {
                Application.LoadLevel(0);
                //Save Player 1 win state/tie state/lose state
            }
        }
        else
        {
            GUI.Label(new Rect(50, 100, 230, 20), "No Users Yet");
        }

        if (PlayerPrefs.HasKey("player2"))
        {
            if (GUI.Button(new Rect(20, 130, 230, 20), PlayerPrefs.GetString("player2") + ": Win(s) = " + PlayerPrefs.GetInt("score2")))
            {
                Application.LoadLevel(0);
                //Save Player 2 winstate/tie state/ lose state
            }
        }
      

        if (GUI.Button(new Rect(20, 260, 230, 20), "Clear Scores"))
        {
            PlayerPrefs.DeleteAll();
        }

        if (GUI.Button(new Rect(20, 280, 230, 20), "Main Menu"))
        {
            Application.LoadLevel(0);
        }


        GUI.EndGroup();
    }
}
