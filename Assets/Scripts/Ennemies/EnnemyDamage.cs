using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
	public int life  = 1;
	bool isDead = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
<<<<<<< Updated upstream:Assets/Scripts/PlayerCollision.cs
		if (collision.CompareTag("Spike"))
		{
			TakeDamages(1);
		}

		if (collision.CompareTag("Mob"))
=======
		if (collision.CompareTag("Ennemy"))
>>>>>>> Stashed changes:Assets/Scripts/Ennemies/EnnemyDamage.cs
		{
			TakeDamages(1);
		}
	}

	

	public void TakeDamages(int damage)
	{
		life -= damage;

		if (life <= 0 && !isDead)
		{
			Die();
		}
	
	}

	public void Die()
	{
		isDead = true;
		GetComponent<Rigidbody2D>().AddForce(Vector3.up * 150);
		GetComponent<Collider2D>().isTrigger = true;
		Invoke("RestartLevel", 0);
		
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
