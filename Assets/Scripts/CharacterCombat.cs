using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {
    [SerializeField]
    private float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float AttackCoolDown
    {
        get { return attackCooldown; }
    }

    public float AttackSpeed
    {
        get
        {
            return attackSpeed;
        }
    }

    public float attackDelay = .6f;

    public event System.Action OnAttack;

    CharacterStats myStats;
    private int roll;

    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public virtual void Attack (CharacterStats targetStats)
    {
        if(attackCooldown <= 0)
        {
            int totalAvailableDamage = myStats.damage.GetValue();
            //print("totalAvailableDamage =" + totalAvailableDamage);
            int damageDealt = 0;
            for (int i = 1; i <= totalAvailableDamage; i++)
            {
                int roll = Random.Range(1, 7);
                //print("roll number " + i + "equals " + roll);
                if(roll >= myStats.hitRollMin)
                {
                    damageDealt++;
                }
            }
            //print("total damage dealt = " + damageDealt);
            //targetStats.TakeDamage(damageDealt);
            StartCoroutine(DoDamage(targetStats, attackDelay, damageDealt));

            if (OnAttack != null)
                OnAttack(); 
            attackCooldown = 1f / AttackSpeed;
        }
        
    }
    //DoDamage used to delay the damage by float delay
    IEnumerator DoDamage(CharacterStats stats, float delay, int damage)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(damage);
    }
}
