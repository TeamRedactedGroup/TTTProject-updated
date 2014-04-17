using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour {

	#region Variables
	public int buttonWidth = 150;
	public int buttonHeight = 50;
	#endregion

	#region Functions
	void OnGUI () {


		if(GUI.Button (new Rect((Screen.width/2) - (buttonWidth/2),
		                        (Screen.height/2) - (buttonHeight/2),
		                        buttonWidth, buttonHeight), "Play Again?")) {

			BoardArray.gameOver = false;
			Application.LoadLevel("Gameplay");
		};
	}
	#endregion
}
