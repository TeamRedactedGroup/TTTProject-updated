using UnityEngine;
using System.Collections;
//Application Level 6
public class Scores : MonoBehaviour
{



    void OnGUI()
    {

        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 500, 500));
        // Make a background boxGUI.Label ( new Rect (50, 100, 230, 20), "Robert  -Team Lead");
        GUI.Box(new Rect(10, 10, 250, 300), "Scores");
        // Make standard text saying enter name
        if (PlayerPrefs.HasKey("player1"))
        {
            GUI.Label(new Rect(20, 100, 230, 20), PlayerPrefs.GetString("player1") + ": Win(s) = " + PlayerPrefs.GetInt("score1"));
        }
        else
        {
            GUI.Label(new Rect(50, 100, 230, 20), "No Users Yet");
        }

        if (PlayerPrefs.HasKey("player2"))
        {
            GUI.Label(new Rect(20, 130, 230, 20), PlayerPrefs.GetString("player2") + ": Win(s) = " + PlayerPrefs.GetInt("score2"));
        }
        /*
        //player 2
        

        if (PlayerPrefs.HasKey("player2"))
        {
            if (GUI.Button(new Rect(20, 100, 230, 20), PlayerPrefs.GetString("player2") + ": Win(s) = " + PlayerPrefs.GetInt("score2")))
            {
                Application.LoadLevel(4);
            }
        }

        //end player 2
        */
        //

        if (GUI.Button(new Rect(20, 280, 230, 20), "Main Menu"))
        {
            Application.LoadLevel(0);
        }


        GUI.EndGroup();
    }
}
