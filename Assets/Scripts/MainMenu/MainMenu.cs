using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
    {
        float guiRectWidth = 0.3f;
        float guiRectHeight = 0.15f;
        int sw = Screen.width;
        int sh = Screen.height;
        Rect guiRect = new Rect(sw / 2 - sw * guiRectWidth / 2, sh / 2 + 10,
                                sw * guiRectWidth, sh * guiRectHeight);

        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height / 2));
        {
            GUILayout.BeginVertical();
            {
                GUILayout.BeginHorizontal();
                {
                    GUILayout.FlexibleSpace();
                    GUILayout.Label("<size=36><color=white>MENDEL-Sim</color></size>");
                    GUILayout.FlexibleSpace();
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                {
                    GUILayout.FlexibleSpace();
                    GUILayout.Label("<size=24><color=white>Multi-agent, configurable ENvironment, Darwinian EvoLution Simulator</color></size>");
                    GUILayout.FlexibleSpace();
                }
                GUILayout.EndHorizontal();

                GUILayout.FlexibleSpace();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.FlexibleSpace();
                    GUILayout.Label("<size=24><color=white>A project by Adam Campbell</color></size>");
                    GUILayout.FlexibleSpace();
                }
                GUILayout.EndHorizontal();

                GUILayout.FlexibleSpace();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.FlexibleSpace();
                    GUILayout.Label("<size=24><color=white>Choose a mode:</color></size>");
                    GUILayout.FlexibleSpace();
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(guiRect);
        {
            GUILayout.BeginVertical();
            {
                if (GUILayout.Button("<size=24>Single Agent</size>"))
                {
                    Application.LoadLevel("SingleAgent");
                }
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("<size=24>Multi Agent</size>"))
                {
                    Application.LoadLevel("MultiAgent");
                }
            }
            GUILayout.EndVertical();
        }
        GUILayout.EndArea();
    }
}
