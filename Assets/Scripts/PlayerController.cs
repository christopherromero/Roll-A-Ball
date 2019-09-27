using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text coinText;
    public Text objectiveText;
    public Text winText;
    private int currentLevel = 0;
    GameObject[] jumppads;
    // public int jumpForce;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 13;
        count = 0;
        winText.text = "";
        Invoke("ShowObjective", 0.0f);
        Invoke("HideObjective", 10.0f);
        SetCoinText();
        jumppads = GameObject.FindGameObjectsWithTag("JumpPad");
        foreach (var j in jumppads)
        {
            j.SetActive(false);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCoinText();
        }
    }

    void ShowObjective()
    {
        objectiveText.text = "Collect 100 coins to win";
        objectiveText.gameObject.SetActive(true);
    }
    private void HideObjective()
    {
        objectiveText.gameObject.SetActive(false);
    }
    void SetCoinText()
    {
        coinText.text = "Coins: " + count.ToString();
        if (count == 22 || count == 58)
        {

            if (jumppads.Length > 0)
            {
                jumppads[1 - currentLevel].SetActive(true);
            }
            currentLevel++;
        }
        if (count >= 80)
        {
            winText.text = "You Win!";
        }
    }
}
