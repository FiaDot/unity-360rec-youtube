using UnityEngine;
using System.Collections;

public class ObjPingPong : MonoBehaviour 
{

	Vector3 src;
	Vector3 dst;

	public float dist = 0.5f;
	float startTime;

	public float timeTakenDuringLerp = 2f;
	public bool yAxis = true;
	public bool zAxis = false;

	bool toggle = false;

	public float pauseDelay = 0.5f;

	void Awake()
	{
		src = transform.position;
		dst = transform.position;

		if ( yAxis )
		{	
			src.y -= dist/2;
			dst.y += dist/2;
		}
		else
		{
			src.x -= dist/2;
			dst.x += dist/2;
		}	

		if (zAxis) {
			src.z -= dist / 2;
			dst.z += dist / 2;
		}
	}

	IEnumerator Start()
	{
		while (true) 
		{ 
			float timeSinceStarted = Time.time - startTime;
            float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
 
 			if ( toggle ) 
				transform.position = Vector3.Lerp(src, dst, percentageComplete);
			else	
				transform.position = Vector3.Lerp(dst, src, percentageComplete);

			yield return null;

			if (percentageComplete > 1.0f)
			{				
				toggle = !toggle;
				yield return new WaitForSeconds(pauseDelay);
				startTime = Time.time;
			}
		}
	}
}
