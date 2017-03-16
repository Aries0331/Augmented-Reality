using UnityEngine;
using System.Collections;
using SimpleJSON;

public partial class Wit3D : MonoBehaviour {

	void Handle(string textToParse) {

		// Reference.cs call Handle(witAiResponse) textToParse is the command get from wit.ai ??
		print (textToParse);
		var N = JSON.Parse (textToParse);
		print ("SimpleJSON: " + N.ToString());

		string intent = N["outcomes"] [0] ["intent"].Value.ToLower ();

		// what function should I call?
		switch (intent)
		{
		case "move_object":
			print ("Intent is MOVE OBJECT");
			MoveObject(textToParse);
			break;
		// Do I need this function? I don't think so.
		// But I do need some others like sit or run or walk etc.
		case "create_object":
			print ("Intent is CREATE OBJECT");
			CreateObjectHandler (textToParse);
			break;
		default:
			print ("Sorry, didn't understand your intent.");
			break;
		}


	}
}