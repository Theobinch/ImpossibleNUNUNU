using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
	public int life  = 1;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Spike"))
		{
			TakeDamages(1);
		}

		if (collision.CompareTag("Mob"))
		{
			TakeDamages(1);
		}
	}

	

	public void TakeDamages(int damage)
	{
		life -= damage;
		Die();
	}

	public void Die()
	{
		GetComponent<Rigidbody2D>().AddForce(Vector3.up * 150);
		GetComponent<Collider2D>().isTrigger = true;
		Invoke("RestartLevel", 0);
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
