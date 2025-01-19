using TMPro;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private float increaseTime = 5f;
    [SerializeField] private TMP_Text checkPointText;

    private void Start()
    {
        checkPointText.text = "+" + increaseTime.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            GameManager.Instance.IncreaseTime(increaseTime);
        }
    }
}
