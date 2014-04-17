using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	#region Variables
	public bool pNum; // Tracks whose turn it is
	public GameObject X_Piece, O_Piece, gameBoardSpace;
	public Transform myTransform;
	public static int turnCount;
	public int labelWidth = 100, labelHeight = 50;
	GUIStyle p1Text = new GUIStyle();
	GUIStyle p2Text = new GUIStyle();
	static string p1name, p2name;
	#endregion

	#region Functions
	void Start () {
		p1name = "Player 1";
		p2name = "Player 2";
		turnCount = 0; // stores # of turns
		pNum = true; // sets player order, need this to change based on menu option
		p1Text.normal.textColor = Color.green;
		p2Text.normal.textColor = Color.gray;
	}

	void Update () {
		if(Input.GetMouseButtonUp(0))
		{
			// get object the player clicked on
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 10))
			{
				myTransform = hit.transform.gameObject.transform;
				gameBoardSpace = hit.transform.gameObject;
				// Debug.Log(hit.transform.gameObject.name);
			}

			// Gets the location on the board that the piece 
			Vector3 boardLocation = new Vector3(myTransform.position.x, myTransform.position.y + 0.1f, myTransform.position.z);

			// Check if object is vacant. If vacant, place piece of that player
			if(pNum && gameBoardSpace.tag != "Occupied")
			{
				Instantiate(O_Piece, boardLocation, Quaternion.identity);
				pNum = false;
				gameBoardSpace.tag = "Occupied";
				BoardSpace thisSpace = (BoardSpace)gameBoardSpace.GetComponent("BoardSpace");
				thisSpace.UpdateSpaceState("Player1");
				turnCount++;
				p2Text.normal.textColor = Color.green;
				p1Text.normal.textColor = Color.gray;
			}
			else if(!pNum && gameBoardSpace.tag != "Occupied")
			{
				Instantiate(X_Piece, boardLocation, Quaternion.identity);
				pNum = true;
				gameBoardSpace.tag = "Occupied";
				BoardSpace thisSpace = (BoardSpace)gameBoardSpace.GetComponent("BoardSpace");
				thisSpace.UpdateSpaceState("Player2");
				turnCount++;
				p1Text.normal.textColor = Color.green;
				p2Text.normal.textColor = Color.gray;
			}

			if(BoardArray.gameOver || turnCount >= 25) {
				// Load game over sceen
				Application.LoadLevel("End");
			};
		}
	}

	//Label Template -->  GUI.Label (new Rect(, , , ), "");
	void OnGUI() {
		GUI.Label (new Rect((Screen.width/2) - (labelWidth/2) + (labelWidth/4), // loc x
		                    (Screen.height/11) - (labelHeight/2) - (labelHeight/4), // loc y
		                    labelWidth, labelHeight), "Turn Count: " + turnCount.ToString()); // size x, size y, text

		GUI.Label (new Rect((Screen.width/8) - (labelWidth/2), //(Screen.width/11) - (labelWidth/2)
		                    (Screen.height/2) - (labelHeight/2),
		                    labelWidth, labelHeight), p1name, p1Text);

		GUI.Label (new Rect((Screen.width) - ((Screen.width/6) - (labelWidth/2)),
		                    (Screen.height/2) - (labelHeight/2),
		                    labelWidth, labelHeight), p2name, p2Text); //Replace "Player 2" with imported name
	}
	#endregion
}