using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	[SerializeField]
	private string m_weaponLayerName = "Weapon";
	[SerializeField]
	private PlayerWeapon m_primaryWeapon;
	//[SerializeField]
	private PlayerWeapon m_currentWeapon;
	[SerializeField]
	private Transform m_weaponHolder;
	private WeaponVFX m_weaponVFX;

	void Start () {
		m_currentWeapon = m_primaryWeapon;
		m_weaponVFX = m_currentWeapon.Graphics.GetComponent<WeaponVFX> ();
		if (m_weaponVFX == null)
			Debug.LogError ("No WeaponVFX on the weapon object: " + m_currentWeapon.Graphics.name);

		Util.SetLayerRecursively (m_currentWeapon.Graphics, LayerMask.NameToLayer (m_weaponLayerName));
	}
	

	void Update () {
		
	}

	void EquipWeapon(PlayerWeapon weapon){
		m_currentWeapon = weapon;
		GameObject wepIns = Instantiate(weapon.Graphics, m_weaponHolder);
		wepIns.transform.SetParent (m_weaponHolder);

		m_weaponVFX = wepIns.GetComponent<WeaponVFX> ();
		if (m_weaponVFX == null)
			Debug.LogError ("No WeaponVFX on the weapon object: " + wepIns.name);
		
		Util.SetLayerRecursively (wepIns, LayerMask.NameToLayer (m_weaponLayerName));
	}

	public PlayerWeapon GetCurrentWeapon(){
		return m_currentWeapon;
	}

	public WeaponVFX GetWeaponVFX(){
		return m_weaponVFX;
	}
	public Transform GetWeaponHolder(){
		return m_weaponHolder;
	}
}
