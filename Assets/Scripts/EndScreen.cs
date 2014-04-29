using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour {

	#region Variables
	static float 	screenHeight,
					screenWidth,
					buttonWidth,
					buttonHeight,
					labelWidth,
					labelHeight;
	static GUIStyle winLabelText	= new GUIStyle();
	static string[] winMsgArr 		= new string[numMsgs] {" so best!", " is King of the Wooooorld!",
													" is better than the other guy!",
													" is liek O.K. i guess i mean wutevs...",
													".rar", " is Tic Tac Toe-tally AWESOME :D",
													": YOU DEFEATED"};
	static string p1n, p2n, w;
	static bool draw;
	//static bool resetAIfirst;
	static string winMsg;
	const int numMsgs = 7;
	#endregion

	#region Functions
	void Start () {
		screenHeight 			= Screen.height;
		screenWidth 			= Screen.width;
		//resetAIfirst			= false;
		buttonWidth				= screenWidth/4;
		buttonHeight			= screenHeight/12;
		labelWidth				= screenWidth/2;
		labelHeight				= screenHeight/5;
		winLabelText.fontSize	= 36;
		winLabelText.normal.textColor = Color.yellow;
		GUI.backgroundColor		= Color.gray;
		winLabelText.alignment	= TextAnchor.UpperCenter;
		w = GameInfo.GetWinner();
		draw = GameInfo.IsItADraw();
		SetWinMsg();
	}
	//Label Template -->  GUI.Label (new Rect(loc x, loc y, size x, size y), "contents");

	void OnGUI () {

		GUI.Label (new Rect((screenWidth/2) - (labelWidth/2),
		                    (screenHeight/2) - (labelHeight/0.75f),
		                    labelWidth, labelHeight), w + winMsg, winLabelText);

		if(GUI.Button (new Rect((screenWidth/2) - (buttonWidth/2), // Retry button
		                        (screenHeight/2) - (buttonHeight/1.25f),
		                        buttonWidth, buttonHeight), "Retry?")) {
			Application.LoadLevel("Gameplay");
		};

		if(GUI.Button (new Rect((screenWidth/2) - (buttonWidth/2), // Main menu button
		                        (screenHeight/2) + (buttonHeight/1.25f),
		                        buttonWidth, buttonHeight), "Main Menu")) {
			Application.LoadLevel("Menu");
		};
	}

	public static void ExecuteHistorySystem() {
		//Debug.Log("In EndScreen, p1name = " + Player.GetPlayer1Name() + "  & winner = " + GameInfo.GetWinner());
		//Debug.Log("In EndScreen, p2name = " + Player.GetPlayer2Name() + "  & winner = " + GameInfo.GetWinner());
		History.PopulatePlayerHistory();
		History.UpdatePlayerHistory(Player.GetPlayer1Name(), GameInfo.GetWinner());
		History.UpdatePlayerHistory(Player.GetPlayer2Name(), GameInfo.GetWinner());
		History.DisplayArray();
		History.WriteHistoryFile();
	}

	void SetWinMsg() {
		if(draw) {
			winMsg = "Everybody loses!!! :(";
		}
		else {
			System.Random msgNum = new System.Random ();
			winMsg = winMsgArr[msgNum.Next(numMsgs)];
		}
	}

	/*public static void ResetRAF() {
		resetAIfirst = true;
	}*/
	#endregion
}
