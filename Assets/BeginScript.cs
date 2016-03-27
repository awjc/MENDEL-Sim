using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BeginScript : MonoBehaviour {

	public InputField creatures = null;
	public InputField tournaments = null;
	public InputField trialDuration = null;

	public Toggle height = null;
	public Toggle distance = null;
	public Toggle balance = null;

	public void clicked()
	{
		checkValues ();

		Object.DontDestroyOnLoad(GameObject.Find ("CreatureScorer"));
		GameObject.Find ("CreatureScorer").GetComponent<CreatureScorer> ().genSize = int.Parse(creatures.text);
		GameObject.Find ("CreatureScorer").GetComponent<CreatureScorer> ().tournSize = int.Parse(tournaments.text);
		if (height.isOn) {
			GameObject.Find ("CreatureScorer").GetComponent<CreatureScorer> ().Mode = CreatureScorer.ScoreMode.HEIGHT;
		} if (distance.isOn) {
			GameObject.Find ("CreatureScorer").GetComponent<CreatureScorer> ().Mode = CreatureScorer.ScoreMode.DISTANCE;
		}

		Application.LoadLevel ("Playground");
	}

	private void checkValues()
	{
		Randomize r = new Randomize ();
		int creatureValue;
		int tourneyValue;
		int trialValue;

		if(int.TryParse (trialDuration.text, out trialValue))
		{
			if(trialValue > 200)
			{
				trialDuration.text = "200";
			} else if(trialValue < 5)
			{
				trialDuration.text = "5";
			}
		} else
		{
			trialDuration.text = "" + r.getTrialDuration();
		}

		if (int.TryParse (creatures.text, out creatureValue)) 
		{
			if (creatureValue > 200) 
			{
				creatures.text = "200";
			} else if (creatureValue < 2) 
			{
				creatures.text = "2";
			}
		} else 
		{
			creatures.text = "" + r.getCreatures();
		}

		if (int.TryParse (tournaments.text, out tourneyValue)) 
		{
			if (tourneyValue > int.Parse (creatures.text)) 
			{
				tournaments.text = "" + r.getTournaments ();
			} else if (tourneyValue < 1)
			{
				tournaments.text = "1";
			}

		}
		else
		{
			tournaments.text = "" + r.getTournaments ();
		}
	}

}
