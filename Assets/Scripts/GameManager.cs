using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public Transform playerPaddle;
   public Transform enemyPaddle;
   private Vector3 _paddlePosition = new (7, 0, 0);
   public BallController ballController;

   public int playerScore = 0;
   public int enemyScore = 0;
   
   public int winPoints = 3;

   public TextMeshProUGUI playerScoreText;
   public TextMeshProUGUI enemyScoreText;
   public TextMeshProUGUI textEndGame;
   
   public GameObject gameOverPanel;
   void Start()
   {
      ResetGame();
   }

   void ResetGame()
   {
      playerPaddle.position = -_paddlePosition;
      enemyPaddle.position = _paddlePosition;
      ballController.ResetBall();
      
      playerScore = 0;
      enemyScore = 0;
      
      playerScoreText.text = playerScore.ToString();
      enemyScoreText.text = enemyScore.ToString();
      
      gameOverPanel.SetActive(false);
   }

   public void PlayerScore()
   {
      playerScore++;
      playerScoreText.text = playerScore.ToString();
      CheckWin();
   }

   public void EnemyScore()
   {
      enemyScore++;
      enemyScoreText.text = enemyScore.ToString();
      CheckWin();
   }

   public void CheckWin()
   {
      if (playerScore == winPoints || enemyScore == winPoints)
      {
         EndGame();
      }
   }

   public void EndGame()
   {
      gameOverPanel.SetActive(true);
      string winner = SaveController.Instance.GetName(playerScore > enemyScore);
      textEndGame.text = winner + " Wins!";
      SaveController.Instance.SaveWinner(winner);
      Invoke("LoadMenu", 2f);
   }

   public void LoadMenu()
   {
      SceneManager.LoadScene("Menu");
   }
}
