using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int starLevel = 1;
    [SerializeField] protected int currentHP;
    [SerializeField] protected int maxHP;
    [SerializeField] protected int attackDamage;
    [SerializeField] protected int attackSpeed;
    protected int[] maxHPArray;
    protected int[] attackDamageArray;
    protected float[] attackSpeedArray;
    protected int StarIndex => starLevel - 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {   
        ApplyStats();
    }

    public void LevelUp()
    {
        starLevel++;
        ApplyStats();
        OnLevelUp();
    }

    protected void ApplyStats()
    {
        currentHP = maxHPArray[StarIndex];
        maxHP = maxHPArray[StarIndex];
        attackDamage = attackDamageArray[StarIndex];
        attackSpeed = attackSpeedArray[StarIndex];
    }

    protected virtual void OnLevelUp()
    {
        // stats, VFX, sounds
    }
}
