/*
	Created by: Lech Szymanski
				lechszym@cs.otago.ac.nz
				Dec 29, 2015			
*/


using UnityEngine;
using System.Collections;

/* This is an example script using A* pathfinding to follow 
 * mouse clicks. */

public class Follow : MonoBehaviour {

	// Follower's speed
	// (initialise via the Inspector Panel)
	public float speed;

	// Game object must have a AStarPathfinder component - 
	// this is a reference to that component, which will get initialised
	// in the Start() method
	private AStarPathfinder pathfinder = null; 

	// Position to follow (in world coordinates)
	private Vector2 followPosition;

	// Use this for initialization
	void Start () {
		//Get the references to object's AStarPathfinder component
		pathfinder = transform.GetComponent<AStarPathfinder> ();
		//Initialise the followPosition to the current position
		followPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (pathfinder != null) {
			if (Input.GetButtonDown("Fire1"))
			{
				//On mouse click, update the followPosition.  Mouse click is given in
				//screen coordinates, so must convert it to world coordinates
				followPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			}
			//Move towards the followPosition at specified speed.
			pathfinder.GoTowards (followPosition, speed);
		}

	}
}
