using UnityEngine;

public class camera_move : MonoBehaviour {
	public GameObject player_hero;
	void Update () {
		transform.position = new Vector3( player_hero.transform.position.x, player_hero.transform.position.y - 10f);
	}
}
