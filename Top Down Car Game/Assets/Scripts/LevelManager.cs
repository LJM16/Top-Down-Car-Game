using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public TextMeshProUGUI CoinCountText;
    public TextMeshProUGUI GasAmountText;
    public TextMeshProUGUI CountdownTimerText;
    
    private int _countdownTimer = 3;
    [SerializeField] private int _coinsCollected = 0;
    [SerializeField] private int _gasAmount = 10;
    [SerializeField] private bool _isGameActive = false;
    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        CoinCountText.text = _coinsCollected.ToString();
        GasAmountText.text = _gasAmount.ToString();
        StartCoroutine(StartCountdownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool StartGame()
    {
        //_isGameActive = true;
        return _isGameActive;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }

    public void ReplayButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeButtonPressed()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void PauseButtonPressed()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void PlayButtonPressed()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    public void UpdateLevelCoinCount(int amount)
    {
        _coinsCollected += amount;
        CoinCountText.text = _coinsCollected.ToString();
    }

    public void UpdateGasAmount(int amount)
    {
        _gasAmount += amount;
        GasAmountText.text = _gasAmount.ToString();
    }

    IEnumerator StartCountdownTimer()
    {
        yield return new WaitForSeconds(0.25f);
        CountdownTimerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        while(_countdownTimer > 0)
        {
            CountdownTimerText.text = _countdownTimer.ToString();
            yield return new WaitForSeconds(1f);
            _countdownTimer--; //_countdownTimer = _countdownTime - 1; (Same thing)
        }

        CountdownTimerText.text = "GO!";
        _isGameActive = true;
        yield return new WaitForSeconds(1f);
        CountdownTimerText.gameObject.SetActive(false);
    }
}
