using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public delegate void Gamedelegate();
    public static event Gamedelegate OnGameStarted;
    public static event Gamedelegate OnGameOverConfirmed;

    public static GameManager Instance;

    public GameObject startPage;
    public GameObject gameOverPage;
    public GameObject countdownpage;
    public Text scoretext;

    enum PageState {
        None,
        Start,
        GameOver,
        Countdown
    }

    int score = 0;
    bool gameOver = false;

    public bool Gameover { get { return gameOver; } }

    private void Awake() {
        Instance = this;
    }

    void SetPageState(PageState state) {
        switch (state) {
            case PageState.None:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownpage.SetActive(false);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                countdownpage.SetActive(false);
                break;
            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                countdownpage.SetActive(false);
                break;
            case PageState.Countdown:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownpage.SetActive(true);
                break;
        }
    }

    public void ConfirmGameOver() {
        //activated when replay button is hit
    }

    public void StartGame() {
        //activated when play button is hit
    }
}
