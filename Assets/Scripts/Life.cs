using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Life : MonoBehaviour
{

    private Stats stats;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Slider sliderExp;
    [SerializeField]
    private TMP_Text levelText;

    public TextMeshProUGUI timerText; // Reference to the TextMesh Pro UI element

    private float timeElapsed = 0f; // Time elapsed in seconds

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
        slider.value = stats.life / stats.maxLife;
        sliderExp.value = stats.exp / stats.expCap;
        levelText.text = "" + (stats.lvl + 1);


        timeElapsed += Time.deltaTime; // Increase timeElapsed by the time passed since the last frame

        int minutes = Mathf.FloorToInt(timeElapsed / 60); // Calculate minutes
        int seconds = Mathf.FloorToInt(timeElapsed % 60); // Calculate seconds

        // Format the time as MM:SS
        timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
        
    }
}
