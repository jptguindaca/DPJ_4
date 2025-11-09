using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timerValue;
    [SerializeField] public float timeToCompleteQuestion = 10f;
    [SerializeField] public float timeToShowCorrectAnswer = 3f;

    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion = false;

    public float fillFraction;

    void Start()
    {
        timerValue = timeToCompleteQuestion;
        isAnsweringQuestion = true;
    }

    void Update()
    {
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        if (isAnsweringQuestion)
        {
            timerValue -= Time.deltaTime;
            Debug.Log(timerValue); //ver o tempo na consola

            fillFraction = timerValue / timeToCompleteQuestion;

            if (timerValue <= 0)
            {
              //mostrar a resposta correta
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            timerValue -= Time.deltaTime;
            Debug.Log(timerValue);

            fillFraction = timerValue / timeToShowCorrectAnswer;

            if (timerValue <= 0)
            {
                 //carregar a próxima pergunta
                loadNextQuestion = true;
                timerValue = timeToCompleteQuestion;
                isAnsweringQuestion = true;
            }
        }
    }

    public void CancelTimer()
    {
        //reinicia o tempo para zero
        timerValue = 0f;
    }
}
