using System;

public class Health : IStat
{
    public int value { get { return hp; }}
    public int max { get { return 100; }}
    public int min { get {return 0; }}

    private int hp = 100;

    public event StatUpdatedHandler statUpdated;

    public void Heal(int heal_amount)
    {
        int new_val = hp - heal_amount;
        if(new_val > max)
            hp = max;
        else
            hp = new_val;
    }

    public void Damage(int damange_amount)
    {
        int new_val = hp - damange_amount;
        if(new_val < min)
            hp = min;
        else
            hp = new_val;
        OnStatUpdated();
    }

    protected void OnStatUpdated()
    {
        if(statUpdated != null)
            statUpdated(hp);
    }
    
}
