using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomizeButton : MonoBehaviour {

	public InputField creatures = null;
	public InputField tournaments = null;
	public InputField trialDuration = null;

	Randomize randomize = new Randomize();

	public Toggle height = null;
	public Toggle distance = null;
	public Toggle balance = null;

	public void clicked()
	{
		creatures.text = "" + randomize.getCreatures ();
		tournaments.text = "" + randomize.getTournaments ();
		trialDuration.text = "" + randomize.getTrialDuration();

		int ch = (int)(Random.Range (1, 4));

		if(ch == 1)
		{
			height.isOn = true;
		} else if(ch == 2)
		{
			distance.isOn = true;
		}
		else if(ch == 3)
		{
			balance.isOn = true;
		}

	}//
}
