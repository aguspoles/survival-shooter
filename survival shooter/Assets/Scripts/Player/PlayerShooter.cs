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
	public PlayerWeapon currentWeapon;
	public Animator m_animator;

	void Awake(){
		if (m_camera == null) {
			Debug.Log ("PlayerShooter: no reference to a camera");
			this.enabled = false;
		}
		m_weaponManager = GetComponent<WeaponManager> ();
	}

	void Update(){
		currentWeapon = m_weaponManager.GetCurrentWeapon ();
	}

	public void Shoot (){			
		m_animator.SetBool ("shoot", true);
		m_weaponManager.GetWeaponVFX ().muzzleFlash.Play ();

		FindObjectOfType<AudioManager> ().Play ("Shoot");

		RaycastHit hit;
		if (Physics.Raycast (m_camera.transform.position, m_camera.transform.forward, out hit, currentWeapon.Range, m_mask)) {
		
			Debug.Log ("We hit " + hit.collider.name);
			if (hit.collider.tag == "Destroyable") {
				Life life = hit.transform.GetComponent<Life> ();
				life.amount -= currentWeapon.Damage;
				if (hit.rigidbody != null)
					hit.rigidbody.AddForce (-hit.normal * m_impactForce);
			}

			HitEffect (hit.point, hit.normal);
		}
			
	}

	public void ShootRepeating(){
		InvokeRepeating ("Shoot", 0f, 1f / currentWeapon.FireRate);
	}
	public void CancelShoot(){
		CancelInvoke ("Shoot");
		m_animator.SetBool ("shoot", false);
	}

	private void HitEffect(Vector3 pos, Vector3 normal){
		GameObject hitEffect = Instantiate (m_weaponManager.GetWeaponVFX ().hitEffect, pos, Quaternion.LookRotation (normal));
		Destroy (hitEffect, 0.2f);
	}
}
