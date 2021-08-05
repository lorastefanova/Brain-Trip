using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    public Question[] questions; // Array of questions
    private static List<Question> unansweredQuestions; // List of unaswered questions

    private Question currentQuestion; // Current question

    [SerializeField]
    private Text panelText; // Panel text 

    [SerializeField]
    private Text trueAnswerText; // True answer text

    [SerializeField]
    private Text falseAnswerText; // False answer text

    [SerializeField]
    private Animator animator; // Animator

    [SerializeField]
    private float timeBetweenQuestions = 1f; // Time between questions

    [SerializeField]
    private GameObject message; // Message panel

    [SerializeField]
    private Text displayScore; // Display score

    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>(); // Load all the unanswered questions
        }

        ScoreScript.instance.score = 0; // Score instance

        SetCurrentQuestion(); // Set the current question

    }

    void Update()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0) // If there are no more questions
        {
            StartCoroutine(Message()); // Message panel
        }
    }

    // Function to set the current question
    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count); // Random question

        if (unansweredQuestions.Count != 0) // If there are unanswered questions
        {
            currentQuestion = unansweredQuestions[randomQuestionIndex]; // Set random current question
        }
        
        panelText.text = currentQuestion.fact; // Display current question text

        if(currentQuestion.isTrue) // If the question is true
        {
            trueAnswerText.text = "CORRECT!"; // True answer is correct
            falseAnswerText.text = "WRONG!"; // False answer is wrong
        }
        else
        {
            trueAnswerText.text = "WRONG!"; // True answer is wrong
            falseAnswerText.text = "CORRECT!"; // False answer is correct
        }
    }

    // Function to transition to the next question
    private IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion); // Remove the answered question from the list

        yield return new WaitForSeconds(timeBetweenQuestions); // Wait for 1 second

        SetCurrentQuestion(); // Set the current question

    }

    // Function to play True animation
    private IEnumerator TrueAnimation()
    {
        animator.SetBool("True", true);

        yield return new WaitForSeconds(timeBetweenQuestions);

        animator.SetBool("True", false);

    }

    // Function to play False animation
    private IEnumerator FalseAnimation()
    {
        animator.SetBool("False", true);

        yield return new WaitForSeconds(timeBetweenQuestions);

        animator.SetBool("False", false);

    }

    // Function to display the message
    private IEnumerator Message()
    {
        yield return new WaitForSeconds(timeBetweenQuestions); // Wait for 1 second

        displayScore.text = "Score : " + ScoreScript.instance.score.ToString() + "/5"; // Display the score
        message.SetActive(true); // Set the panel active
    }

    // Function for True answer
    public void UserSelectTrue()
    {
        if (currentQuestion.isTrue) // If it is true
        {
            ScoreScript.instance.score++; // Add 1 to the score
        }

        StartCoroutine(TrueAnimation()); // Play true animation
        StartCoroutine(TransitionToNextQuestion()); // Transition to next question
    }

    // Function for False answer
    public void UserSelectFalse()
    {
        if (!currentQuestion.isTrue) // If it is false
        {
            ScoreScript.instance.score++; // Add 1 to the score
        }

        StartCoroutine(FalseAnimation()); // Play false animation 
        StartCoroutine(TransitionToNextQuestion()); // Transition to next question
    }
}
