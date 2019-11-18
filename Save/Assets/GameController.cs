using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class GameController : MonoBehaviour
{


    public static GameController gameControl;

    public int attack;
    public int defense;
    public int health;
    public int indexWeapon;
    public List<Weapon> weapons;

    // Use this for initialization
    void Start()
    {
        if (gameControl == null)
        {
            DontDestroyOnLoad(gameObject);
            gameControl = this;
            setDefaultValue();
            weapons = new List<Weapon>();
            weapons.Add(new Weapon());
            indexWeapon = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setDefaultValue()
    {
        attack = 1;
        defense = 1;
        health = 1;
        indexWeapon = 0;
    }
    public void AddAttack()
    {
        attack++;
    }
    public void AddDefense()
    {
        defense++;
    }
    public void AddHealth()
    {
        health++;
    }

    public void AddAttackCurrentWeapon()
    {
        weapons[indexWeapon].attack++;
    }
    public void AddWeapon()
    {
        weapons.Add(new Weapon());
    }
    public void NextWeapon()
    {
        if (indexWeapon < weapons.Count - 1)
        {
            indexWeapon++;
        }
        else
        {
            indexWeapon = 0;
        }
    }
    public void PreviousWeapon()
    {
        if (indexWeapon != 0)
        {
            indexWeapon--;
        }
        else
        {
            indexWeapon = weapons.Count - 1;
        }
    }
    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "gameInfo.dat"))
        {
            throw new Exception("Game file doesnt exist");
        }
        else
        {
            FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat", FileMode.Open);
            PlayerData playerDataToLoad = (PlayerData)bf.Deserialize(file);
            file.Close();
            attack = playerDataToLoad.attack;
            defense = playerDataToLoad.defense;
            health = playerDataToLoad.health;
            weapons = playerDataToLoad.Weapons;
            indexWeapon = playerDataToLoad.indexWeapon;
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat", FileMode.Create);
        PlayerData playerDataToSave = new PlayerData();
        playerDataToSave.attack = attack;
        playerDataToSave.defense = defense;
        playerDataToSave.health = health;
        playerDataToSave.Weapons = weapons;
        playerDataToSave.indexWeapon = indexWeapon;

        bf.Serialize(file, playerDataToSave);
        file.Close();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 60, 180, 80), "Attack :" + attack, style);
        GUI.Label(new Rect(10, 110, 180, 80), "Defense :" + defense, style);
        GUI.Label(new Rect(10, 160, 180, 80), "Health :" + health, style);
        GUI.Label(new Rect(10, 210, 180, 80), "WeaponIndex :" + indexWeapon, style);
        GUI.Label(new Rect(10, 260, 180, 80), "WeaponAttack :" + weapons[indexWeapon].attack, style);


    }

}

[Serializable]

class PlayerData
{
    public int attack;
    public int defense;
    public int health;
    public List<Weapon> Weapons;
    public int indexWeapon;
}
[Serializable]
public class Weapon
{
    public int attack = 1;
}