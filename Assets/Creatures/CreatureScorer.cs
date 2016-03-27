using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class CreatureScorer : MonoBehaviour {

	public enum ScoreMode {
		DISTANCE,
        DISTANCE_INVERSE,
		HEIGHT
	}

	private double record = xxx;
	private double allTime = xxx;
	private double thisGen = xxx;
    static int xxx = -100;
    public bool drawBox;
	public ScoreMode Mode;
	public int genSize;
	public int tournSize;
	private int creatureNum = 0;
	private int generation = 0;
	public bool started = false;
	private bool heightActive = false;
	private List<double> scores = new List<double> ();
	private List<double> newScores = new List<double> ();
	public double timeOffset = 0;
	private List<GameObject> gameObjs = new List<GameObject>();
	private List<GameObject> olds = new List<GameObject>();

	private void SetHeightActive() {
		heightActive = true;
	}

	void OnLevelWasLoaded(int level) {
        init();
	}

    void Start()
    {
        init();
	}

    private void init()
    {
        Physics.gravity = new Vector3(0, -20.0F, 0);
        if (Application.loadedLevelName == "Playground")
        {
            Invoke("doCreature", 2);
        }

        
        if(Mode == ScoreMode.HEIGHT)
        {
            // Move mat aside
            var mat = GameObject.Find("SumoMat");
            var pos = mat.transform.localPosition;

            pos.x = pos.x + 5;
            mat.transform.localPosition = pos;
        }
    }

	public void doCreature() {
        heightActive = false;
		BodySegment.JointConnectionPrefab = JointConnectionPrefab;
		timeOffset = Time.time;

		count = 0;
        System.Random r = new System.Random();
        double dice = r.NextDouble();
		if (generation == 0 || dice < 0.10) {
			createRandomCreature ();
		} else {
			createTournamentCreature ();
		}

        Invoke("SetHeightActive", 2);
		Invoke ("FinishCreature", 5);

		started = true;
	}

	private double getEvalTime() {
		return Time.time - timeOffset;
	}

	void FixedUpdate() {
		if (started) {
			var root = GameObject.Find ("Subject:0");
			var simTime = getEvalTime ();
			root.GetComponent<SegmentHolder> ().segment.update (simTime);

            var mat = GameObject.Find("SumoMat");
            var scale = mat.transform.localScale;
            var score = Math.Max((float)allTime, (float) getScore());

            if(Mode == ScoreMode.DISTANCE)
            {
                scale.x = score;
                scale.z = score;
            }
            if(Mode == ScoreMode.HEIGHT)
            {
                scale.y = score;
            }
            if(Mode == ScoreMode.DISTANCE_INVERSE)
            {
                scale.y = score;
            }

            mat.transform.localScale = scale;
        }

	}


	private void FinishCreature() {
		newScores.Add (record);

		Debug.Log ("Creature " + creatureNum + ": " + record.ToString ("0.000"));

        record = xxx;
		var creature = GameObject.Find ("Subject:0");
		creature.name = "old" + creatureNum;
		creature.SetActive (false);
		gameObjs.Add (creature);

		creatureNum++;

		if (creatureNum >= genSize) {
			doNewGeneration();
		} 

		doCreature ();
	}

	private void doNewGeneration() {
		thisGen = xxx;
		generation++;
		for (int i=0; i<olds.Count; i++) {
			GameObject.Destroy (olds [i]);
		}
		olds.Clear();
		for (int i=0; i < gameObjs.Count; i++) {
			olds.Add(gameObjs[i]);
			gameObjs[i].name = "oldold" + i;
		}
		gameObjs.Clear();
		creatureNum = 0;
		scores = newScores;
		newScores = new List<double> ();
	}

	void OnGUI()
	{
		if (started) {
			var score = getScore ();
            if (Mode != ScoreMode.DISTANCE_INVERSE)
            {
                if (score > record)
                    record = score;
                if (score > allTime)
                    allTime = score;
                if (score > thisGen)
                    thisGen = score;
            }
            else
            {
                
                if (score < record)
                    record = score;
                if (score < allTime)
                    allTime = score;
                if (score < thisGen)
                    thisGen = score;
            }

            if (drawBox)
            {
                GUI.Box(new Rect(Screen.width - 350, Screen.height - 355, 330, 345), "");
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.white;
                style.fontSize = 32;

                GUI.Label(new Rect(Screen.width - 225, Screen.height - 350, 250, 50), "Gen #: " + (generation + 1), style);
                GUI.Label(new Rect(Screen.width - 290, Screen.height - 300, 250, 50), "Creature #: " + (creatureNum + 1), style);
                GUI.Label(new Rect(Screen.width - 210, Screen.height - 250, 250, 50), "Time: " + getEvalTime().ToString("0.00"), style);
                GUI.Label(new Rect(Screen.width - 225, Screen.height - 200, 250, 50), "Score: " + score.ToString("0.000"), style);
                GUI.Label(new Rect(Screen.width - 250, Screen.height - 150, 250, 50), "Highest: " + record.ToString("0.000"), style);
                GUI.Label(new Rect(Screen.width - 330, Screen.height - 100, 250, 50), "Best this gen: " + thisGen.ToString("0.000"), style);
                GUI.Label(new Rect(Screen.width - 320, Screen.height - 50, 250, 50), "Best all time: " + allTime.ToString("0.000"), style);
            }
		}
	}

	private double getScore() {
		if (Mode == ScoreMode.DISTANCE) {
			Vector3 position = GameObject.Find ("Subject:0").transform.position;
			var score = new Vector2 (position.x, position.z).magnitude;
			return score;
        }
        else if (Mode == ScoreMode.DISTANCE_INVERSE)
        {
            Vector3 position = GameObject.Find("Subject:0").transform.position;
            var score = new Vector2(position.x, position.z).magnitude;
            return 100-score;
        }
        else if (Mode == ScoreMode.HEIGHT)
        {
            if (heightActive)
            {
                var seg = GameObject.Find("Subject:0").GetComponent<SegmentHolder>().segment;
                int count = 0;
                var highest = Vector3.zero;
                foreach (var segChild in seg.getAllChildren())
                {
                   // Debug.Log("CHILD " + count++ + segChild.GameObj.transform.position);
                    var pos = segChild.GameObj.transform.position;
                    if (pos.y > highest.y)
                        highest = pos;
                }
                var score = highest.y;
                return score;
            }
            else
            {
                return -1;
            }
        }
        else
        {
            return -1;
        }
	}

	public void createTournamentCreature() {
		var tourn1 = selectRandom (scores, tournSize);
		var highScore1 = tourn1.Max ();
		var winner1 = scores.IndexOf (highScore1);

		var tourn2 = selectRandom (scores, tournSize);
		var highScore2 = tourn2.Max ();
		var winner2 = scores.IndexOf (highScore2);

		mergeCreatures (winner1, winner2);
	}

	public void mergeCreatures(int name1, int name2) {
		var creature1 = olds[name1].GetComponent<SegmentHolder>().segment;
		var creature2 = olds[name2].GetComponent<SegmentHolder>().segment;

		System.Random r = new System.Random ();
		double dice = r.NextDouble ();
		if (dice <= 0.5) {
			BodySegment root = merge(creature1, creature2);
			root.GameObj.transform.position = new Vector3(0, 5, 0);
		} else {
			BodySegment root = merge(creature2, creature1);
			root.GameObj.transform.position = new Vector3(0, 5, 0);
		}
	}

	public JointBrainTree mergeBrains(JointBrainTree one, JointBrainTree two) {
		System.Random r = new System.Random ();
        double dice = r.NextDouble();
        if (dice < 0.1)
        {
            dice = r.NextDouble();
            if (dice < 0.8)
            {
                return one;
            }
            else
            {
                return two;
            }
        }
        else 
        {
            dice = r.NextDouble();
            if (dice < 0.8)
            {
                return new JointBrainTree(mutateBrainTree(one.Root, r));
            }
            else
            {
                return new JointBrainTree(mutateBrainTree(two.Root, r));
            }
        } 
	}

    public BrainTreeNode mutateBrainTree(BrainTreeNode one, System.Random r)
    {
        var ctor = one.GetType().GetConstructors()[0];
        var children = one.getChildren();
        int count = one.getChildren().Count;
        var newChildren = new List<BrainTreeNode>();
        for (int i = 0; i < count; i++)
        {
            double dice = r.NextDouble();
            if (dice < 0.8)
            {
                newChildren.Add(children[i]);
            } else {
                newChildren.Add(BrainTreeGenerator.generateRandomNode(r, 0.5));
            }
        }

        return (BrainTreeNode)ctor.Invoke(newChildren.ToArray());
    }

	public BodySegment merge(BodySegment main, BodySegment other) {
		BodySegment bs = new BodySegment (mergeBrains(main.brain1, other.brain2), mergeBrains(main.brain2, other.brain2));
		bs.setName ("Subject:" + count);
		count++;
		bs.setColor (main.getColor ());
		bs.setScale (main.getScale ());

		System.Random r = new System.Random ();
		foreach (var con in main.getConnections()) {
			double dice = r.NextDouble ();
			if (dice < 0.10) {
				var seg = getRandomSegment(other);
				seg.setName("Subject:" + count);
				count++;
				Vector3 positionOnParent = new Vector3( (r.Next(2)*2-1)*.5f,
				                                       (r.Next(2)*2-1)*.5f,
				                                       (r.Next(2)*2-1)*.5f);
				Vector3 positionOnChild = new Vector3( (r.Next(2)*2-1)*.5f,
				                                      (r.Next(2)*2-1)*.5f,
				                                      (r.Next(2)*2-1)*.5f);

				bs.AddChild(seg, positionOnParent, positionOnChild);
			} else if (dice < 0.20) {
				// don't add segment
			} else if (dice < 0.30) {
				BodySegment seg = genRandBodySegment(r, 0.4);
				Vector3 positionOnParent = new Vector3( (r.Next(3)-1)*.5f,
				                                       (r.Next(3)-1)*.5f,
				                                       (r.Next(3)-1)*.5f);
				Vector3 positionOnChild = new Vector3( (r.Next(3)-1)*.5f,
				                                      (r.Next(3)-1)*.5f,
				                                      (r.Next(3)-1)*.5f);
				bs.AddChild(seg, positionOnParent, positionOnChild);
			} else {
				var seg = deepCopyOf(con.connectedSegment);
				seg.setName("Subject:" + count);
				count++;
				bs.AddChild(seg, con.positionOnParent, con.positionOnChild);
			}
		}

		return bs;
	}

	public BodySegment getRandomSegment(BodySegment bs) {
		System.Random r = new System.Random ();
		int size = getSize (bs);
		int x = r.Next (size);

		return segToArray (bs) [x];
	}

	public List<BodySegment> segToArray(BodySegment bs) {
		if (bs.getConnections ().Count == 0) {
			return new List<BodySegment> { bs };
		}

		var list = new List<BodySegment> ();
		foreach (var con in bs.getConnections()) {
			list.AddRange(segToArray(con.connectedSegment));
		}
		return list;
	}


	public int getSize(BodySegment bs) {
		int accum = 0;
		if (bs.getConnections ().Count == 0) {
			return 1;
		}

		foreach (var con in bs.getConnections()) {
			accum += getSize(con.connectedSegment);
		}
		return accum;
	}

	public BodySegment deepCopyOf(BodySegment orig) {
		BodySegment bs = new BodySegment (orig.brain1, orig.brain2);
		bs.setName (orig.getName ());
		bs.setColor (orig.getColor ());
		bs.setScale (orig.getScale ());

		foreach (var con in orig.getConnections()) {
			var seg = deepCopyOf(con.connectedSegment);
			bs.AddChild(seg, con.positionOnParent, con.positionOnChild);
		}
		return bs;
	}


	public double[] selectRandom(List<double> scores, int tournSize) {
		System.Random r = new System.Random ();
		return scores.OrderBy (x => r.Next ()).Take (tournSize).ToArray();
	}


	public GameObject JointConnectionPrefab;
	public int count = 0;
	public void createRandomCreature()
	{
		System.Random rand = new System.Random();
		BodySegment root = genRandBodySegment(rand, 0);
		root.GameObj.transform.position = new Vector3 (0, 5, 0);
	}
	
	public BodySegment genRandBodySegment(System.Random rand, double probTerm)
	{
		double dice = rand.NextDouble ();
		if (dice <= probTerm) {
			return genRandBodySegmentTerminal (rand);
		} else {
			int numChildren = rand.Next (4) + 1;
			BodySegment bs = genRandBodySegmentTerminal(rand);
			for (int i = 0; i < numChildren; i++) {
				double nextProb;
				if(probTerm == 0)
					nextProb = 0.0001;
				else 
					nextProb = probTerm + 0.5;

				BodySegment seg = genRandBodySegment(rand, nextProb);
                Vector3 positionOnParent = new Vector3((rand.Next(3) - 1) * .5f,
                                                   (rand.Next(3) - 1) * .5f,
                                                   (rand.Next(3) - 1) * .5f);
                Vector3 positionOnChild = new Vector3((rand.Next(3) - 1) * .5f,
                                                      (rand.Next(3) - 1) * .5f,
                                                      (rand.Next(3) - 1) * .5f);
				bs.AddChild(seg, positionOnParent, positionOnChild);
				
			}
			return bs;
		}
	}
	
	public BodySegment genRandBodySegmentTerminal(System.Random rand)
	{
		JointBrainTree brain1 = BrainTreeGenerator.generateRandomBrainTree ();
		JointBrainTree brain2 = BrainTreeGenerator.generateRandomBrainTree ();
		BodySegment bs = new BodySegment (brain1, brain2);
		bs.setColor (new Color((float)rand.NextDouble(),
		                       (float)rand.NextDouble(),
		                       (float)rand.NextDouble(),
		                       1.0f));
		bs.setScale (new Vector3((float)(rand.NextDouble()*.7+.3),
		                         (float)(rand.NextDouble()*.7+.3),
		                         (float)(rand.NextDouble()*.7+.3)));
		bs.setName ("Subject:" + count);
		count++;
		return bs;
	}
}