using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{

	// initialization of what is 'usable' on the menu
	public Canvas quitMenu;
	public Button StartText;
	public Button ExitText;
	void Start ()
	{
		//Initialization of the buttons on the menu
		quitMenu = quitMenu.GetComponent<Canvas> ();
		StartText = StartText.GetComponent<Button> ();
		ExitText = ExitText.GetComponent<Button> ();
		quitMenu.enabled = false; //wont quit by itself
	}

	public void ExitPress() //To exit the game, menu, disables other buttons
	{
		quitMenu.enabled = true;
		StartText.enabled = false;
		ExitText.enabled = false;
	}

	public void NoPress() //enables other options when not in exit menu
	{
		quitMenu.enabled = false;
		StartText.enabled = true;
		ExitText.enabled = true;
	}

	public void StartLevel()
	{
		Application.LoadLevel (1); //Insert scene or level number here instead of 1
	}

	public void ExitGame()
	{
		Application.Quit ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
