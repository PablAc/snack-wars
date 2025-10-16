using UnityEngine;

public class EnemiHealt : MonoBehaviour
{

    public int Healt = 5;

    public void TakeDamage(int damage)
    {
        Healt -= damage;
        if (Healt <= 0)
        {
            Destroy(gameObject);
            
        }
    }
   

  
    

}
