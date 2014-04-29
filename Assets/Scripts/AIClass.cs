using UnityEngine;
using System.Collections;

public class AIClass : PlayerClass {
	#region Variables
	int AILevel;
	#endregion

	#region Functions
	public AIClass() {}
	
	public AIClass (GameObject piece, char pShape, int difficulty) {
		gamePiece	= piece;
		shape		= pShape;
		AILevel		= difficulty;
	}
	
	public override bool GetMove() {
		if(AILevel == 0) {
			if(AIEasy()) {
				return true;
			}
		}
		else if(AILevel == 1) {
			if(AINormal()) {
				return true;
			}
		}
		else if(AILevel == 2) {
			if(AIHard()) {
				return true;
			}
		}
		return false;
	}

	bool AIEasy() {
		int		AIPieceCoordX, AIPieceCoordZ;
		float	AIPieceCoordY;
		System.Random ran = new System.Random();
		
		do {
			AIPieceCoordX = ran.Next (BoardArray.nAcross);
			AIPieceCoordY = Player.pieceHeightFromBoard;
			AIPieceCoordZ = ran.Next (BoardArray.nAcross);
			
			//StartCoroutine(WaitForAI());
			
			// Check if object is occupied by a game piece. If vacant, place piece of that player 
			gameBoardSpace = GameObject.Find("piece" + AIPieceCoordX + "," + AIPieceCoordZ);
			Vector3 boardLocation = new Vector3(AIPieceCoordX, AIPieceCoordY, AIPieceCoordZ);
			Debug.Log("Placing piece at (" + AIPieceCoordX + ", " + AIPieceCoordZ + ")");
			
			// Check if object is vacant. If vacant, place piece of that player
			if(gameBoardSpace.tag != "Occupied") {
				// Create player's game piece in game space
				Instantiate(gamePiece, boardLocation, Quaternion.identity);
				
				// Tag player-clicked space as occupied
				gameBoardSpace.tag = "Occupied";
				
				// Get a reference to the GameObject that was clicked
				BoardSpace thisSpace = (BoardSpace)gameBoardSpace.GetComponent("BoardSpace");
				// Call the function of the clicked piece to update win state information
				thisSpace.UpdateSpaceState(shape);
				
				Player.CheckWinState();
				// Alternate player name UI colors to denote whose turn it is
				GameInfo.ChangeColor();
				// Increment turn counter
				GameInfo.IncrementTurnCount();
				return true;
			}
		} while(gameBoardSpace.tag == "Occupied");
		return false;
	}

	bool AINormal() {
		// Normal AI routine goes here
		return true;
	}

	bool AIHard() {
		// Hard AI routine goes here
		return true;
	}

	/*IEnumerator WaitForAI() {
		yield return new WaitForSeconds(2.0f);
	}*/
	#endregion
}
