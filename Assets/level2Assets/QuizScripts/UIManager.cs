using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[Serializable()]
public struct UIManagerParameters
{
    [Header("Answers Options")]
    [SerializeField] float margins;
    public float Margins { get { return margins; } }

    [Header("Transition Screen Options")]
    [SerializeField] Color correctBGColor;
    public Color CorrectBGColor { get { return correctBGColor; } }
    [SerializeField] Color incorrectBGColor;
    public Color IncorrectBGColor { get { return incorrectBGColor; } }
    [SerializeField] Color finalBGColor;
    public Color FinalBGColor { get { return finalBGColor; } }
}
[Serializable()]
public struct UIElements
{
    [SerializeField] RectTransform answersContentArea;
    public RectTransform AnswersContentArea { get { return answersContentArea; } }

    [SerializeField] TextMeshProUGUI questionInfoTextObject;
    public TextMeshProUGUI QuestionInfoTextObject { get { return questionInfoTextObject; } }

    [SerializeField] TextMeshProUGUI scoreText;
    public TextMeshProUGUI ScoreText { get { return scoreText; } }

    [Space]

    [SerializeField] Animator transitionScreenAnimator;
    public Animator TransitionScreenAnimator { get { return transitionScreenAnimator; } }

    [SerializeField] Image transitionBG;
    public Image TransitionBG { get { return transitionBG; } }

    [SerializeField] TextMeshProUGUI transitionStateInfoText;
    public TextMeshProUGUI TransitionStateInfoText { get { return transitionStateInfoText; } }

    [SerializeField] TextMeshProUGUI transitionScoreText;
    public TextMeshProUGUI TransitionScoreText { get { return transitionScoreText; } }

    [Space]

    [SerializeField] TextMeshProUGUI highScoreText;
    public TextMeshProUGUI HighScoreText { get { return highScoreText; } }

    [SerializeField] CanvasGroup mainCanvasGroup;
    public CanvasGroup MainCanvasGroup { get { return mainCanvasGroup; } }

    [SerializeField] RectTransform finishUIElements;
    public RectTransform FinishUIElements { get { return finishUIElements; } }
}
public class UIManager : MonoBehaviour
{
    #region Variables

    public enum TransitionScreenType { Correct, Incorrect, Finish }
    [Header("References")]
    [SerializeField] GameEvents events = null;

    [Header("UI Elements (Prefabs)")]
    [SerializeField] AnswerData answerPrefab = null;

    [SerializeField] UIElements uIElements = new UIElements();

    [Space]
    [SerializeField] UIManagerParameters parameters = new UIManagerParameters();

    private List<AnswerData> currentAnswers = new List<AnswerData>();
    private int resStateParaHash = 0;

    private IEnumerator IE_DisplayTimedTransition = null;

    #endregion

    #region Default Unity methods

    /// <summary>
    /// Function that is called when the object becomes enabled and active
    /// </summary>
    void OnEnable()
    {
        events.UpdateQuestionUI += UpdateQuestionUI;
        events.DisplayTransitionScreen += DisplayTransition;
        events.ScoreUpdated += UpdateScoreUI;
    }
    /// <summary>
    /// Function that is called when the behaviour becomes disabled
    /// </summary>
    void OnDisable()
    {
        events.UpdateQuestionUI -= UpdateQuestionUI;
        events.DisplayTransitionScreen -= DisplayTransition;
        events.ScoreUpdated -= UpdateScoreUI;
    }

    /// <summary>
    /// Function that is called when the script instance is being loaded.
    /// </summary>
    void Start()
    {
        UpdateScoreUI();
        resStateParaHash = Animator.StringToHash("ScreenState");
    }

    #endregion

    /// <summary>
    /// Function that is used to update new question UI information.
    /// </summary>
    void UpdateQuestionUI(Question question)
    {
        uIElements.QuestionInfoTextObject.text = question.Info;
        CreateAnswers(question);
    }
    /// <summary>
    /// Function that is used to display transition screen.
    /// </summary>
    void DisplayTransition(TransitionScreenType type, int score)
    {
        UpdateResUI(type, score);
        uIElements.TransitionScreenAnimator.SetInteger(resStateParaHash, 2);
        uIElements.MainCanvasGroup.blocksRaycasts = false;

        if (type != TransitionScreenType.Finish)
        {
            if (IE_DisplayTimedTransition != null)
            {
                StopCoroutine(IE_DisplayTimedTransition);
            }
            IE_DisplayTimedTransition = DisplayTimedTransition();
            StartCoroutine(IE_DisplayTimedTransition);
        }
    }
    IEnumerator DisplayTimedTransition()
    {
        yield return new WaitForSeconds(GameUtility.TransitionDelayTime);
        uIElements.TransitionScreenAnimator.SetInteger(resStateParaHash, 1);
        uIElements.MainCanvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// Function that is used to display transition UI information.
    /// </summary>
    void UpdateResUI(TransitionScreenType type, int score)
    {
        var highscore = PlayerPrefs.GetInt(GameUtility.SavePrefKey);

        switch (type)
        {
            case TransitionScreenType.Correct:
                uIElements.TransitionBG.color = parameters.CorrectBGColor;
                uIElements.TransitionStateInfoText.text = "CORRECT!";
                uIElements.TransitionScoreText.text = "+" + score;
                break;
            case TransitionScreenType.Incorrect:
                uIElements.TransitionBG.color = parameters.IncorrectBGColor;
                uIElements.TransitionStateInfoText.text = "WRONG!";
                uIElements.TransitionScoreText.text = "-" + score;
                break;
            case TransitionScreenType.Finish:
                uIElements.TransitionBG.color = parameters.FinalBGColor;
                uIElements.TransitionStateInfoText.text = "FINAL SCORE";

                StartCoroutine(CalculateScore());
                uIElements.FinishUIElements.gameObject.SetActive(true);
                uIElements.HighScoreText.gameObject.SetActive(true);
                uIElements.HighScoreText.text = ((highscore > events.StartupHighscore) ? "<color=yellow>new </color>" : string.Empty) + "Highscore: " + highscore;
                break;
        }
    }

    /// <summary>
    /// Function that is used to calculate and display the score.
    /// </summary>
    IEnumerator CalculateScore()
    {
        var scoreValue = 0;
        // while (scoreValue < events.CurrentFinalScore)
        // {
        //     scoreValue++;
        //     uIElements.TransitionScoreText.text = scoreValue.ToString();

        //     yield return null;
        // }
        //fixed ittt ! :D
        scoreValue = events.CurrentFinalScore;
        uIElements.TransitionScoreText.text = scoreValue.ToString();

        yield return null;
    }

    /// <summary>
    /// Function that is used to create new question answers.
    /// </summary>
    void CreateAnswers(Question question)
    {
        EraseAnswers();

        float offset = 0 - parameters.Margins;
        for (int i = 0; i < question.Answers.Length; i++)
        {
            AnswerData newAnswer = (AnswerData)Instantiate(answerPrefab, uIElements.AnswersContentArea);
            newAnswer.UpdateData(question.Answers[i].Info, i);

            newAnswer.Rect.anchoredPosition = new Vector2(0, offset);

            offset -= (newAnswer.Rect.sizeDelta.y + parameters.Margins);
            uIElements.AnswersContentArea.sizeDelta = new Vector2(uIElements.AnswersContentArea.sizeDelta.x, offset * -1);

            currentAnswers.Add(newAnswer);
        }
    }
    /// <summary>
    /// Function that is used to erase current created answers.
    /// </summary>
    void EraseAnswers()
    {
        foreach (var answer in currentAnswers)
        {
            Destroy(answer.gameObject);
        }
        currentAnswers.Clear();
    }

    /// <summary>
    /// Function that is used to update score text UI.
    /// </summary>
    void UpdateScoreUI()
    {
        uIElements.ScoreText.text = "Score: " + events.CurrentFinalScore;
    }
}
