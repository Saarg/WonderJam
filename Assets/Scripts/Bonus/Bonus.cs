using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

    public BonusType bonusType = BonusType.Heal;
    public float bonusAmount = 50;

    public void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            switch (bonusType)
            {
                case BonusType.Heal:
                    player.ModifyLife(bonusAmount);
                    Destroy(gameObject);
                    break;
                case BonusType.Speed:
                    player.ModifyBoost(bonusAmount);
                    Destroy(gameObject);
                    break;
                case BonusType.Point:
                    GameManager.GetInstance().AddScore((int)bonusAmount, player.GetComponent<Player>().team);
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }
        
    }
}

public enum BonusType
{
    Heal,
    Speed,
    Point
}