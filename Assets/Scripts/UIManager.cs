using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private Image _liveDisplay;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private float _gameOverFlickerSpeed = 0.5f;

    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("GameManager is NULL.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScore (int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLives (int currentLives)
    {
        _liveDisplay.sprite = _liveSprites[currentLives];

        if (currentLives == 0)
        {
            GameOverSequence();
        }
    }
    void GameOverSequence ()
    {
        StartCoroutine(GameOverFlickerRoutine());
        _restartText.gameObject.SetActive(true);
        _gameManager.GameOver();
    }

    IEnumerator GameOverFlickerRoutine ()
    {
        while (true)
        {
        _gameOverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(_gameOverFlickerSpeed);
        _gameOverText.gameObject.SetActive(false);
        yield return new WaitForSeconds (_gameOverFlickerSpeed);    
        }
    }
}
