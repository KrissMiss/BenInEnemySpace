using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject rifle;

    [SerializeField] GameObject pistolUI;
    [SerializeField] GameObject shotgunUI;
    [SerializeField] GameObject rifleUI;
    public enum Weapon { Pistol, Shotgun, Rifle }
    Weapon weapon;

    void Start()
    {
        weapon = Weapon.Pistol;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ChooseWeapon(Weapon.Pistol);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            ChooseWeapon(Weapon.Shotgun);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            ChooseWeapon(Weapon.Rifle);
        }

        if (Input.GetMouseButton(0))
        {
            switch (weapon)
            {
                case Weapon.Pistol:
                    pistol.GetComponent<Gun>().Shoot();
                    break;
                case Weapon.Shotgun:
                    shotgun.GetComponent<Gun>().Shoot();
                    break;
                case Weapon.Rifle:
                    rifle.GetComponent<Gun>().Shoot();
                    break;
            }
        }
    }

    public void ChooseWeapon(Weapon weapon)
    {
        switch (weapon)
        {
            case Weapon.Pistol:
                pistol.SetActive(true);
                shotgun.SetActive(false);
                rifle.SetActive(false);
                this.weapon = Weapon.Pistol;
                pistolUI.transform.localScale = new Vector3(1, 1, 1);
                shotgunUI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                rifleUI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                break;
            case Weapon.Shotgun:
                pistol.SetActive(false);
                shotgun.SetActive(true);
                rifle.SetActive(false);
                this.weapon = Weapon.Shotgun;
                pistolUI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                shotgunUI.transform.localScale = new Vector3(1, 1, 1);
                rifleUI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                break;
            case Weapon.Rifle:
                pistol.SetActive(false);
                shotgun.SetActive(false);
                rifle.SetActive(true);
                this.weapon = Weapon.Rifle;
                pistolUI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                shotgunUI.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                rifleUI.transform.localScale = new Vector3(1, 1, 1);
                break;
            default:
                print("Такого оружия у вас нет");
                break;
        }
    }
}
