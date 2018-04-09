using UnityEngine;

public class PlayerUI : MonoBehaviour {

	[SerializeField]
	private RectTransform m_thrusterFuelFill;

	private PlayerController m_playerController;
	private GameObject m_player;

	void Start(){
		m_player = GameObject.Find ("Player");
		m_playerController = m_player.GetComponent<PlayerController> ();
	}

	void Update(){
		SetFuelAmount (m_playerController.GetThrusterFuel ());
	}

	void SetFuelAmount(float amount){
		m_thrusterFuelFill.localScale = new Vector3 (1f, amount, 1f);
	}

	public void SetPlayerController(PlayerController controller){
		m_playerController = controller;
	}
}
