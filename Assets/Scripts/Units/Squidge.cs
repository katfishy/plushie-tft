using UnityEngine;
public class Squidge : Unit
{
    [SerializeField] private readonly string unitName = "Squidge";
    private readonly string[] traits = { "Katie's", "Ocean", "Secretly Evil" };
    private readonly int price = 5;

    protected override void Start()
    {
        maxHPArray = new[] { 100, 150, 200 };
        attackDamageArray = new[] { 5, 10, 15 };
        attackSpeedArray = new[] { 0.3f, 0.5f, 0.7f };

        base.Start();
    }
    

}

