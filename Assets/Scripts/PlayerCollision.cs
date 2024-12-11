using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	public int life  = 3;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Spike"))
		{
			TakeDamages(3);
		}
	}

	public void TakeDamages(int damage)
	{
		life -= damage;
	}
}
