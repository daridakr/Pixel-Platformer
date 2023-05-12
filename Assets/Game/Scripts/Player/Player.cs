using UnityEngine;

public class Player : MonoBehaviour
{
    private int _money = 0;
    
    public int Money => _money;

    public void AddMoney(int money)
    {
        if (money > 0)
        {
            _money += money;
        }
    }

    public void DisplayMoney()
    {
        Debug.Log(Money);
    }
}
