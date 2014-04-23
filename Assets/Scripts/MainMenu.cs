//C#
using UnityEngine;
using System.Collections;



public class MainMenu : MonoBehaviour
{
    //Declaring font
    GUIStyle Font;
    public int labelWidth = 100, labelHeight = 50;

    //Radio button variables
    public bool Player1First = false;
    public bool Player2First = false;
    public bool Random = false;
    
       
    void OnGUI()
    {
        //Font object
        Font = new GUIStyle();
        Font.fontSize = 30;



        
        // All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

        // We'll make a box so you can see where the group is on-screen.


        // Make a background box
        //GUI.Box(new Rect(Screen.width / 2  ,0,Screen.width,800), "Tic Tac Toe " , Font);
        //GUI.Label (new Rect (Screen.width/2, Screen.height/2, 100, 50), "Tic Tac Toe", centeredStyle );

       

        //Pkayer 1 option box
        GUI.Box(new Rect(Screen.width / 8,30, 300, 350), "Tic Tac Toe Player 1");
        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        //Player 1 options button box
        if (GUI.Button(new Rect(Screen.width / 8 + 10, 60, 280, 40), "New User"))
        {
            Application.LoadLevel(1);
        }

        // Make the second button.
        if (GUI.Button(new Rect(Screen.width / 8 + 10, 110, 280, 40), "Returning User"))
        {
            Application.LoadLevel(2);

        }
        if (GUI.Button(new Rect(Screen.width / 8 + 10, 160, 280, 40), "Guest"))
        {
            
        }
        if (PlayerPrefs.HasKey("player1"))
        {
            GUI.Box(new Rect(Screen.width / 8 + 10, 310, 280, 40), "Ready");
        }
        //Player 2 options text box
        GUI.Box(new Rect(Screen.width / 8 + 600, 30, 300, 350), "Tic Tac Toe Player2");

        //Player 2 options button box		
        if (GUI.Button(new Rect(Screen.width / 8 + 610, 60, 280, 40), "New User"))
        {
            Application.LoadLevel(1);
        }

        // Make the second button.
        if (GUI.Button(new Rect(Screen.width / 8 + 610, 110, 280, 40), "Returning User"))
        {
            Application.LoadLevel(2);

        }
        if (GUI.Button(new Rect(Screen.width / 8 + 610, 160, 280, 40), "Guest"))
        {
            Application.LoadLevel(0);
        }
        if (GUI.Button(new Rect(Screen.width / 8 + 610, 210, 280, 40), "A.I."))
        {
            Application.LoadLevel("Ai");
        }

        if (PlayerPrefs.HasKey("player2"))
        {
            GUI.Box(new Rect(Screen.width / 8 + 610, 310, 280, 40), "Ready");
        }


        // History button box
        GUI.Box(new Rect(Screen.width / 8, 400, 300, 150), "");
        //history button
        if (GUI.Button(new Rect(Screen.width / 8 + 10, 410, 280, 120), "History"))
        {
            Application.LoadLevel(4);
        }
        //
        //Start button box
        GUI.Box(new Rect(Screen.width / 8 + 600, 400, 300, 150), "");
        //Start button
        if (GUI.Button(new Rect(Screen.width / 8 + 610, 410, 280, 120), "Start!"))
        {
            Application.LoadLevel(3);
        }
        //Radio Buttons for which player goes first
        GUI.Box(new Rect(Screen.width / 8 + 325, 400, 250, 150), "");
        Player1First = GUI.Toggle(new Rect(Screen.width / 8 + 325, 420, 230, 20), Player1First, "Player 1");
        Player2First = GUI.Toggle(new Rect(Screen.width / 8 + 325, 440, 230, 20), Player2First, "Player 2");
        Random = GUI.Toggle(new Rect(Screen.width / 8 + 325, 460, 230, 20), Random, "Random");
        if (Player1First == false || Player2First == false || Random == false)
        {
            if (Player1First == true)
            {
                Player2First = false;
                Random = false;
                //Insert code for Player 1 goes first
            }

            if (Player2First == true)
            {
                Player1First = false;
                Random = false;
                //Insert code for Player 2 goes first
            }

            if (Random == true)
            {
                Player1First = false;
                Player2First = false;
                //Insert code for Random
            }
        }







        //exit button box
        GUI.Box(new Rect(Screen.width / 8 + 600, 590, 280, 120), "");
        //exit button
        if (GUI.Button(new Rect(Screen.width / 8 + 610, 590, 260, 100), "Exit"))
        {
            Application.Quit(); ;
        }

         

      
      
    }

}