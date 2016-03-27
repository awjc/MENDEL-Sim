using UnityEngine;
using System.Collections;

public class ValueLimiter : MonoBehaviour {

	int value = 0;

	public void valueUpdate(int number)
	{
		value = number;
		if (value > 200) 
		{
			value = 200;
		}


	}


}
