using UnityEngine;
using System.Collections;

public class CubemapReflection : MonoBehaviour {
	public Cubemap cubemap;
	public Material currentMaterial;
	public float updateRate = 1.0f;
	private double lastUpdateTime = -1.0;
	
	void Start () {

	}
	
	void Update () {
		if(Time.time - updateRate > lastUpdateTime){
			lastUpdateTime = Time.time - Time.deltaTime;
			RenderMe();
			currentMaterial.SetTexture("_Cube",cubemap);
			GetComponent<Renderer>().material = currentMaterial;
		}
	}
	
	void RenderMe(){
		GameObject renderCamera = new GameObject( "CubemapCamera"+Random.seed, typeof(Camera) );
		
		renderCamera.GetComponent<Camera>().backgroundColor = Color.black;
		renderCamera.GetComponent<Camera>().cullingMask = ~(1<<8); 
		renderCamera.transform.position = transform.position;
		if(transform.GetComponent<Renderer>() )
		{
			renderCamera.transform.position = transform.GetComponent<Renderer>().bounds.center;
		}
		renderCamera.transform.rotation = Quaternion.identity;
		
		renderCamera.GetComponent<Camera>().RenderToCubemap( cubemap );
		
		DestroyImmediate( renderCamera );
	}
}
