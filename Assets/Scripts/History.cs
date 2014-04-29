using UnityEngine;
using System.Collections;
using System.IO;

public class History : MonoBehaviour {

	#region Variables
	const char		DELIM = ',';
	const string	gameHistory = "TTT_Game_History.txt",
					guestName = "Guest";
	const int 		numRecords 	= 100,
					numOfFields = 4,
					maxCount 	= 999,
					minCount 	= 0,
					nameIndex 	= 0,
					winIndex 	= 1,
					lossIndex 	= 2,
					drawIndex 	= 3;
	static int		playerIndex,
					currentRecords;
	static string 	readIn;
	static string[] inputLine;
	static bool 	playerFound;
	static string[,] PlayerHistory = new string[numRecords, numOfFields];
	#endregion

	#region Functions
	// Opens the history file and reads all content into PlayerHistory
	public static void PopulatePlayerHistory() {
		if(File.Exists(gameHistory)) {
			FileStream fileIO = new FileStream(gameHistory, FileMode.Open, FileAccess.Read);
			StreamReader readFile = new StreamReader(fileIO); // Initializes file reader object

			int count = 0;
			readIn = readFile.ReadLine();
			while(count < numRecords && readIn != null) {
				inputLine = readIn.Split(DELIM); // splits line into string array
				for(int j = 0; j < numOfFields; j++) {
					PlayerHistory[count, j] = inputLine[j];
				}
				count++;
				currentRecords = count;
				readIn = readFile.ReadLine();
			}
			readFile.Close();
			fileIO.Close();

			for(int k = count; k < numRecords; k++) {
				for(int i = 0; i < numOfFields; i++) {
					PlayerHistory[k, i] = "";
				}
			}
		}
	}

	public static void UpdatePlayerHistory(string pName, string win) {
		playerFound = false;
		string[] newPlayer = new string[numOfFields];
		if(pName != guestName) {
			int count = 0;
			while(count < currentRecords && !playerFound) {
				if(PlayerHistory[count,nameIndex] == pName) { // If name exists in the history file
					playerIndex = count;
					playerFound = true;
					Debug.Log(pName + " was found");
				}
				count++;
			}

			if(!playerFound) {
				playerIndex = currentRecords;
				currentRecords++;
				newPlayer[nameIndex] = pName;
			}

			//Debug.Log("name: " + pName + " & playerIndex: " + playerIndex);

			if(pName == win) { // if player was the winner
				if(playerFound) {
					//Debug.Log(pName + " wins was " + PlayerHistory[playerIndex, winIndex]);
					PlayerHistory[playerIndex, winIndex] = IncrementValue(PlayerHistory[playerIndex, winIndex]);
					//Debug.Log(pName + " wins is now " + PlayerHistory[playerIndex, winIndex]);
				}
				else {
					//Debug.Log(pName + " win++");
					newPlayer[winIndex] = "1";
					newPlayer[lossIndex] = "0";
					newPlayer[drawIndex] = "0";
				}
			}
			else if (GameInfo.IsItADraw()){
				if(playerFound) {
					//Debug.Log(pName + " draw was " + PlayerHistory[playerIndex, drawIndex]);
					PlayerHistory[playerIndex, drawIndex] = IncrementValue(PlayerHistory[playerIndex, drawIndex]);
					//Debug.Log(pName + " draws is now " + PlayerHistory[playerIndex, drawIndex]);
				}
				else {
					//Debug.Log(pName + " draw++");
					newPlayer[winIndex] = "0";
					newPlayer[lossIndex] = "0";
					newPlayer[drawIndex] = "1";
				}
			}
			else {
				if(playerFound) {
					//Debug.Log(pName + " losses was " + PlayerHistory[playerIndex, lossIndex]);
					PlayerHistory[playerIndex, lossIndex] = IncrementValue(PlayerHistory[playerIndex, lossIndex]);
					//Debug.Log(pName + " losses is now " + PlayerHistory[playerIndex, lossIndex]);
				}
				else {
					//Debug.Log(pName + " loss++");
					newPlayer[winIndex] = "0";
					newPlayer[lossIndex] = "1";
					newPlayer[drawIndex] = "0";
				}
			}

			if(!playerFound) {
				for(int n = 0; n < numOfFields; n++) {
					PlayerHistory[playerIndex, n] = newPlayer[n];
				}
			}
		}
	}

	static string IncrementValue(string s) {
		string tempStr = s;
		int tempInt = System.Convert.ToInt32(s);
		if(tempInt >= minCount && tempInt <= maxCount) {
			tempInt++;
			tempStr = tempInt.ToString();
		}
		return tempStr;
	}


	static public void WriteHistoryFile() {
		FileStream fileIO = new FileStream(gameHistory, FileMode.Create, FileAccess.Write);
		StreamWriter writeFile = new StreamWriter(fileIO); // Initializes file reader object
		string tempStr;

		//Debug.Log("This is coming from WriteHistoryFile, currentRecords = " + currentRecords);

		for(int i = 0; i < currentRecords; i++) {
			tempStr = PlayerHistory[i, 0] + DELIM + PlayerHistory[i, 1] + DELIM + PlayerHistory[i, 2] + DELIM + PlayerHistory[i, 3];
			writeFile.WriteLine(tempStr);
		}
		writeFile.Close();
		fileIO.Close(); 
	}

	static public bool DisplayArray() {
		string[] str = new string[numOfFields];
		for(int i = 0; i < currentRecords; i++) {
			for(int j = 0; j < numOfFields; j++ ) {
				if(PlayerHistory[i, j] == "") {
					return true;
				}
				str[j] = PlayerHistory[i, j];
			}
			Debug.Log(str[0] + " , "  + str[1] + " , " + str[2] + " , " + str[3]);
			str[0] = str[1] = str[2] = str[3] = "";
		}
		return true;
	}
	#endregion
}
