using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponManager))]
public class PlayerShooter : MonoBehaviour {

	[SerializeField]
	private Camera m_camera;
	[SerializeField]
	private LayerMask m_mask;
	[SerializeField]
	private float m_impactForce = 30f;

	private WeaponManager m_weaponManager;
	private PlayerWeapon m_currentWeapon;
	public Animator m_animator;

	void Start(){
		if (m_camera == null) {
			Debug.Log ("PlayerShooter: no reference to a camera");
			this.enabled = false;
		}
		m_weaponManager = GetComponent<WeaponManager> ();
	}

	void Update(){
		m_currentWeapon = m_weaponManager.GetCurrentWeapon ();

		if (GameManager.isRestarting == false) {
			
			if (m_currentWeapon.FireRate <= 0f) {
				if (Input.GetButtonDown ("Fire1")) {
					Shoot ();
				}
			} else {
				if (Input.GetButtonDown ("Fire1")) {
					InvokeRepeating ("Shoot", 0f, 1f / m_currentWeapon.FireRate);
				} else if (Input.GetButtonUp ("Fire1")) {
					CancelInvoke ("Shoot");
					//FindObjectOfType<AudioManager> ().Stop ("Shoot");
					m_animator.SetBool ("shoot", false);
				}
			}

		}
		else {
			CancelInvoke ("Shoot");
			FindObjectOfType<AudioManager> ().Stop ("Shoot");
			m_animator.SetBool ("shoot", false);
		}
	}

	private void Shoot (){			
		Debug.Log ("SHOOT");
		m_animator.SetBool ("shoot", true);
		m_weaponManager.GetWeaponVFX ().muzzleFlash.Play ();

		/*if (FindObjectOfType<AudioManager> ().IsPlaying ("Shoot")) {
		} else*/
			FindObjectOfType<AudioManager> ().Play ("Shoot");

		RaycastHit hit;
		if (Physics.Raycast (m_camera.transform.position, m_camera.transform.forward, out hit, m_currentWeapon.Range, m_mask)) {
		
			Debug.Log ("We hit " + hit.collider.name);
			if (hit.collider.tag == "Destroyable") {
				Life life = hit.transform.GetComponent<Life> ();
				life.amount -= m_currentWeapon.Damage;
				if (hit.rigidbody != null)
					hit.rigidbody.AddForce (-hit.normal * m_impactForce);
			}

			HitEffect (hit.point, hit.normal);
		}
			
	}

	private void HitEffect(Vector3 pos, Vector3 normal){
		GameObject hitEffect = Instantiate (m_weaponManager.GetWeaponVFX ().hitEffect, pos, Quaternion.LookRotation (normal));
		Destroy (hitEffect, 0.2f);
	}
}
