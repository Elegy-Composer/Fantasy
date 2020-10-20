using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapObject.PlayerController.Backpack.ItemEffect
{
    public class SpeedyPotion : ItemProperty
    {
        IEnumerator SpeedUpPlayer()
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement.PlayerMovement>().move.moveSpeed *= 1.25f;
            yield return new WaitForSeconds(15f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement.PlayerMovement>().move.moveSpeed *= 0.8f;
        }
        protected override void UseItem()
        {
            Debug.Log("use potion");
        }
    }
}