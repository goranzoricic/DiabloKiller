using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

	[HideInInspector]
	public NavMeshAgent navMeshAgent;

	public float MinDistance = 0.01f;
	public float MovementSpeed = 3000f;

	public bool movementAllowed = true;

	// Use this for initialization
	void Start () {

	}

	public abstract void onDeath(bool allowMovement);

}
