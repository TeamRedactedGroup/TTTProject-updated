using UnityEngine;
using System.Collections;

public class BoardSpace : MonoBehaviour {
	
	#region Variables
	public int h_val, v_val;
	public int h, v;
	public string thisSpaceName;
	#endregion

	#region Functions
	void Start () {
		thisSpaceName = this.name;
		h_val = thisSpaceName[5] - 48; 
		v_val = thisSpaceName[7] - 48;
		h = h_val - 1;
		v = v_val - 1;
	}

	public void UpdateSpaceState (string player) {
		//Debug.Log("This is coming from piece " + thisSpaceName + ", and Player = " + player);
		//Debug.Log("h = " + h + " and v = " + v);
		for(int i = 0; i < 28; i++) {
			//Debug.Log("h = " + h + " and v = " + v + " and i = " + i);
			if(BoardArray.winCheckBoard[h, v, i]) {
				//Debug.Log("Checking space " + h_val + "," + v_val);
				if(player == "Player1") {
					BoardArray.winCheckSumO[i]++;
					//Debug.Log("Added one to O @ " + h_val + "," + v_val + " to give us " + BoardArray.winCheckSumO[i]);
				}
				if(player == "Player2") {
					BoardArray.winCheckSumX[i]++;
					//Debug.Log("Added one to X @ " + h_val + "," + v_val + " to give us " + BoardArray.winCheckSumX[i]);
				}
			}
		}

		// Checks both win state arrays for victory condition
		for(int i = 0; i < 28; i++) {
			if(BoardArray.winCheckSumX[i] == 4) {
				BoardArray.gameOver = true;
				break; };
			if(BoardArray.winCheckSumO[i] == 4) {
				BoardArray.gameOver = true;
				break; }; };
	}
	#endregion
}