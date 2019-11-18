using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonModifierDataPlayer : MonoBehaviour
{

    public void IncreaseDefense()
    {
        GameController.gameControl.AddDefense();
    }
    public void IncreaseAttack()
    {
        GameController.gameControl.AddAttack();
    }
    public void IncreaseHealth()
    {
        GameController.gameControl.AddHealth();
    }
    public void AddAttackWeapon()
    {
        GameController.gameControl.AddAttackCurrentWeapon();
    } public void AddWeapon()
    {
        GameController.gameControl.AddWeapon();
    } public void NextWeapon()
    {
        GameController.gameControl.NextWeapon();
    } public void PreviousWeapon()
    {
        GameController.gameControl.PreviousWeapon();
    }
}
