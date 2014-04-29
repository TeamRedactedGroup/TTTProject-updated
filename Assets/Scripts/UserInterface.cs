using UnityEngine;
using System.Collections;

public class UserInterface : MonoBehaviour 
{
	#region Variables
	// Variables for screen and button size
	private float screenHeight,
				  screenWidth,
				  buttonHeight,
				  buttonWidth;

	// Variables for scores screen
	private Vector2 scrollViewVector = Vector2.zero;
	private string 	innerText 		 = "Scores";
	private float 	vScrollbarValue;

	// Variables that indicates different screens
	public bool MenuScreen 		= true,
				StartScreen 	= false,
				ScoresScreen 	= false,
				AboutScreen 	= false,
				NewPlayerScreen = false,
				IsThereAI 		= false,
				DoesP1GoFirst 	= true, // This should be default true, but changeable below
				DoesAIGoFirst 	= false,
				//Player2First = false, // Don't need, if 2 players Player 1 is first
				Random 			= false;

	public string stringToEdit,
				  player1Name,
				  player2Name;

	public int AIDifficultyLevel = 0; // 0 easy, 1 normal, 2 hard
									/*Maybe default to -1 as a null state, but
	 								not currently handled in Player*/
	#endregion
				

	// Sets screen and button size
	void Start () 
	{
		screenHeight 	= Screen.height;
		screenWidth 	= Screen.width;

		buttonHeight 	= screenHeight * 0.1f;
		buttonWidth 	= screenWidth * 0.4f;
	}
		
	// Utilizes Unity GUI class
	void OnGUI()
	{
		if (MenuScreen) 
		{
			mainMenu ();
		}
		else if (StartScreen) 
		{
			startMenu ();
		} 
		else if (ScoresScreen) 
		{
			scoresMenu ();
		} 
		else if (AboutScreen) 
		{
			aboutMenu ();
		}
		else if (NewPlayerScreen) 
		{
			startMenu ();
			newMenu ();
		}
	}

	// Displays main menu screen
	void mainMenu()
	{
		// Button that directs to "Start" screen
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.4f, buttonWidth, buttonHeight), "Start")) 
		{
			MenuScreen = false;
			StartScreen = true;
			ScoresScreen = false;
			AboutScreen = false;
			Application.LoadLevel ("Start");
		}

		// Button that directs to "Scores" screen
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.5f, buttonWidth, buttonHeight), "Scores")) 
		{
			MenuScreen = false;
			StartScreen = false;
			ScoresScreen = true;
			AboutScreen = false;
			Application.LoadLevel ("Scores");
		}

		// Button that directs to "About" screen
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.6f, buttonWidth, buttonHeight), "About")) 
		{
			MenuScreen = false;
			StartScreen = false;
			ScoresScreen = false;
			AboutScreen = true;
			Application.LoadLevel ("About");
		}

		// Button that quits game
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.7f, buttonWidth, buttonHeight), "Quit")) 
		{
			Application.Quit ();
		}
	}

	void startMenu()
	{
		//Player 1 options box
		GUI.Box (new Rect (screenWidth * 0.1f, screenHeight * 0.05f, screenWidth * 0.25f, screenHeight * 0.5f), "Player1");

		//Player 1 has the ability to create a username
		if (GUI.Button (new Rect (screenWidth * 0.11f, screenHeight * 0.1f, buttonWidth * 0.58f, buttonHeight * 0.5f), "New User")) 
		{
			MenuScreen = false;
			StartScreen = false;
			ScoresScreen = false;
			AboutScreen = false;
			NewPlayerScreen = true;
			newMenu ();
			player1Name = stringToEdit;
		}
		
		// Player 1 has the ability to choose from a list of saved names
		if (GUI.Button (new Rect (screenWidth * 0.11f, screenHeight * 0.15f, buttonWidth * 0.58f, buttonHeight * 0.5f), "Returning User")) 
		{
			//Application.LoadLevel (2);
			
		}

		//Player 1 has the ability to play as a guest
		if (GUI.Button (new Rect (screenWidth * 0.11f, screenHeight * 0.2f, buttonWidth * 0.58f, buttonHeight * 0.5f), "Guest")) 
		{
			//Application.LoadLevel ("Guest");
		}

		//Player 1 will be able to choose an AI as a player/opponent
		if (GUI.Button (new Rect (screenWidth * 0.11f, screenHeight * 0.25f, buttonWidth * 0.58f, buttonHeight * 0.5f), "AI")) 
		{
			//Application.LoadLevel ("Guest");
		}

		//Ready flag
		if (PlayerPrefs.HasKey ("player1")) 
		{
			GUI.Box (new Rect (screenWidth * 0.11f, screenHeight * 0.35f, buttonWidth * 0.58f, buttonHeight * 0.6f), "Ready");
		}
		
		//Player 2 options text box
		GUI.Box (new Rect (screenWidth * 0.65f, screenHeight * 0.05f, screenWidth * 0.25f, screenHeight * 0.5f), "Player2");
		
		//Player 2 has the ability to create a username		
		if (GUI.Button (new Rect (screenWidth * 0.66f, screenHeight * 0.1f, buttonWidth * 0.58f, buttonHeight * 0.5f), "New User")) 
		{
			MenuScreen		= false;
			StartScreen		= false;
			ScoresScreen	= false;
			AboutScreen		= false;
			NewPlayerScreen = true;
			newMenu ();
			player2Name = stringToEdit;
		}
		
		//Player 2 has the ability to choose from a list of saved names
		if (GUI.Button (new Rect (screenWidth * 0.66f, screenHeight * 0.15f, buttonWidth * 0.58f, buttonHeight * 0.5f), "Returning User")) 
		{
			//Application.LoadLevel (2);
			
		}

		//Player 2 has the ability to play as a guest
		if (GUI.Button (new Rect (screenWidth * 0.66f, screenHeight * 0.2f, buttonWidth * 0.58f, buttonHeight * 0.5f), "Guest")) 
		{
			//Application.LoadLevel (0);
		}

		//Player 2 will be chosen as an AI oppenent
		if (GUI.Button (new Rect (screenWidth * 0.66f, screenHeight * 0.25f, buttonWidth * 0.58f, buttonHeight * 0.5f), "A.I.")) 
		{
			IsThereAI = true;
		}

		//Ready flag 2
		if (PlayerPrefs.HasKey ("player2")) 
		{
			GUI.Box (new Rect (screenWidth * 0.66f, screenHeight * 0.35f, buttonWidth * 0.58f, buttonHeight * 0.6f), "Ready!!");
		}
		
		// Menu button box
		GUI.Box (new Rect (screenWidth * 0.1f, screenHeight * 0.6f, screenWidth * 0.25f, screenHeight * 0.25f), "");
	
		//Player can return to the main menu
		if (GUI.Button (new Rect (screenWidth * 0.11f, screenHeight * 0.62f, buttonWidth * 0.58f, buttonHeight * 2.0f), "Main Menu")) 
		{
			Application.LoadLevel ("Menu");
		}

		//Start button box
		GUI.Box (new Rect (screenWidth * 0.65f, screenHeight * 0.6f, screenWidth * 0.25f, screenHeight * 0.25f), "");

		//Player will be directed to the game screen
		if (GUI.Button (new Rect (screenWidth * 0.66f, screenHeight * 0.63f, buttonWidth * 0.58f, buttonHeight * 0.7f), "Play!")) 
		{
			//Creates the Player class and initializes it based on choices made on the main menu
			new Player("Player 1 name" /*player1Name*/, "Player 2 name"/*player2Name*/, IsThereAI, DoesAIGoFirst, AIDifficultyLevel);
			Application.LoadLevel ("Gameplay");
		}

		//Player can quit the game
		if (GUI.Button (new Rect (screenWidth * 0.66f, screenHeight * 0.73f, buttonWidth * 0.58f, buttonHeight * 0.7f), "Quit")) {
			Application.Quit ();
		}

		//Radio Buttons for which player goes first
		GUI.Box (new Rect(screenWidth * 0.4f, screenHeight * 0.65f, screenWidth * 0.2f, screenHeight * 0.2f), "Who goes first?");
		/*Only one of these options can be selected at a time, and
		 * selecting the unselected one deselects the currently selected one*/
		DoesP1GoFirst = GUI.Toggle (new Rect(screenWidth * 0.43f, screenHeight * 0.7f, 100, 30), DoesP1GoFirst, "Player 1");
		if (DoesP1GoFirst == true) {
			DoesAIGoFirst = false;
			//Random = false;
		}
		DoesAIGoFirst = GUI.Toggle (new Rect (screenWidth * 0.43f, screenHeight * 0.75f, 100, 30), DoesAIGoFirst, "AI");
		//Random = GUI.Toggle (new Rect (screenWidth * 0.43f, screenHeight * 0.8f, 100, 30), Random, "Random");
		if (DoesAIGoFirst == true) {
			DoesP1GoFirst = false;
			//Random = false;
		}
	}

	// Enable player to create a username
	void newMenu()
	{
		// Make a background box
		GUI.Box(new Rect(screenWidth * 0.375f, screenHeight * 0.05f, screenWidth * 0.25f, screenHeight * 0.5f), "New User");

		// Make standard text saying enter name
		GUI.Label (new Rect (screenWidth * 0.4f, screenHeight * 0.135f, buttonWidth * 0.5f, buttonHeight * 0.5f), "Enter Name:");

		//Create text inputbox.
		stringToEdit = GUI.TextField(new Rect(screenWidth * 0.4f, screenHeight * 0.2f, buttonWidth * 0.5f, buttonHeight * 0.4f), stringToEdit,25);

		//create Enter button to input text
		if(GUI.Button(new Rect(screenWidth * 0.4f, screenHeight * 0.3f, buttonWidth * 0.5f, buttonHeight * 0.4f), "Enter")) 
		{
			Application.LoadLevel("Start");
		}
		
		// Return to previous screen
		if(GUI.Button(new Rect(screenWidth * 0.4f, screenHeight * 0.4f, buttonWidth * 0.5f, buttonHeight * 0.4f), "Return")) 
		{
			Application.LoadLevel("Start");
		}
	}

	// Displays scores
	void scoresMenu()
	{
		scrollViewVector = GUI.BeginScrollView(new Rect(screenWidth * 0.3f, screenHeight * 0.25f, screenWidth * 0.4f, screenHeight * 0.4f), scrollViewVector, new Rect(0, 0, 400, 400));
		innerText = GUI.TextArea (new Rect (0, 0, screenWidth * 0.5f, screenHeight * 0.5f), innerText);
		GUI.EndScrollView ();

		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.85f, buttonWidth, buttonHeight), "Main Menu")) 
		{
			Application.LoadLevel ("Menu");
		}
	}

	// Displays team info
	void aboutMenu()
	{
		if (GUI.Button (new Rect ((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.85f, buttonWidth, buttonHeight), "Main Menu")) 
		{
			Application.LoadLevel ("Menu");
		}
	}

}
