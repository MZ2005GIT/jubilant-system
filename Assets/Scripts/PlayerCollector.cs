using UnityEngine;
using TMPro;

public class PlayerCollector : MonoBehaviour
{
    // --- UI ---
    public TextMeshProUGUI coinCountText;
    public TextMeshProUGUI burgerCountText;
    public TextMeshProUGUI drinkCountText;

    // --- Audio ---
    [Header("Pickup Sounds")]
    public AudioClip coinSound;
    public AudioClip burgerSound;
    public AudioClip drinkSound;

    // --- Private Counters ---
    private int coinCount = 0;
    private int burgerCount = 0;
    private int drinkCount = 0;

    // --- Tags ---
    private const string COIN_TAG = "coin";
    private const string BURGER_TAG = "burger";
    private const string DRINK_TAG = "drink";

    // --- Audio Source ---
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // create one if missing
        }

        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(COIN_TAG))
        {
            coinCount++;
            audioSource.PlayOneShot(coinSound);
            Destroy(other.gameObject);
            UpdateUI();
        }
        else if (other.CompareTag(BURGER_TAG))
        {
            burgerCount++;
            audioSource.PlayOneShot(burgerSound);
            Destroy(other.gameObject);
            UpdateUI();
        }
        else if (other.CompareTag(DRINK_TAG))
        {
            drinkCount++;
            audioSource.PlayOneShot(drinkSound);
            Destroy(other.gameObject);
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        coinCountText.text = coinCount.ToString();
        burgerCountText.text = burgerCount.ToString();
        drinkCountText.text = drinkCount.ToString();
    }

    // Optional getters
    public int GetCoinCount() => coinCount;
    public int GetBurgerCount() => burgerCount;
    public int GetDrinkCount() => drinkCount;
}
