using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    bool hasBeenPickedUp = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hasBeenPickedUp && collision.tag == "Player")
        {
            hasBeenPickedUp = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(coinSFX, transform.position);
            Destroy(gameObject);
        }
    }
}
