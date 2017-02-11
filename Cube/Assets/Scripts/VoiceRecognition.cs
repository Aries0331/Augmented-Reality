using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceRecognition : MonoBehaviour {


	// create an object called keywordRecognizer
	KeywordRecognizer keywordRecognizer;
	// use string for recognition and action for call back
	// create a dictionary coutaing words and actions according to the words
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

	// create keywordrecognition and set it up 
	// Use this for initialization
	void Start () {
		//initialize stuff
		keywords.Add("blue", () =>
			{
				GoCalled("blue");
			} );

		keywords.Add("yellow", () =>
			{
				GoCalled("yellow");
			} );

		keywords.Add("black", () =>
			{
				GoCalled("black");
			} );

		keywords.Add("red", () =>
			{
				GoCalled("red");
			} );

		keywordRecognizer = new KeywordRecognizer (keywords.Keys.ToArray ());
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnPharseRecognized;
		keywordRecognizer.Start ();
	}

	void KeywordRecognizerOnPharseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;

		if(keywords.TryGetValue(args.text, out keywordAction)) // args.text is the word we just said
		{
			keywordAction.Invoke ();
		}
	}

	public Material mat;

	void GoCalled (string color) {
		if (color == "red") {
			mat.color = Color.red;
		}
		if (color == "blue") {
			mat.color = Color.blue;
		}
		if (color == "black") {
			mat.color = Color.black;
		}
		if (color == "yellow") {
			mat.color = Color.yellow;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
