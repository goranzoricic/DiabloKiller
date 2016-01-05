using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public GameObject player;

	//private Vector3 offset;
	Vector3 position = new Vector3(0, 12, -8);
	Quaternion rotation = Quaternion.Euler(45, 0, 0);
	// Use this for initialization
	void Start () {
		GameObject main = GameObject.Find("Main Camera");
		if (main != null) {
			main.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + position;
		transform.LookAt(player.transform.position);
		//transform.position = offset;
	}
}
