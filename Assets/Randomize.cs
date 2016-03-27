using UnityEngine;
using System.Collections;

public class Randomize{
	private int creatures;
	private int tournaments;
	private int trialDuration;

	public Randomize() {

		creatures = 0;
		tournaments = 0;
		trialDuration = 0;

	}

	public int getCreatures()
	{
		creatures = (int)(Random.Range (2, 200));
		return creatures;
	}

	public int getTournaments()
	{
		tournaments = (int)(Random.Range (1, creatures));
		return tournaments;
	}

	public int getTrialDuration()
	{
		trialDuration = (int)(Random.Range (5, 200));
		return trialDuration;
	}
}
