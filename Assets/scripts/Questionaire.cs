using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Questionaire : MonoBehaviour
{
    [SerializeField] private QuestionSO perguntasSO;
    [SerializeField] private TextMeshProUGUI perguntasText;
    [SerializeField] private GameObject[] respostaButtons;
    [SerializeField] private Image timerImage;
    private int respostasCorretas;

    private Timer timer;

    public bool hasAnsweredEarly = false;

    void Start()
    {
        //referência ao Timer na cena
        timer = FindObjectOfType<Timer>();

        GetNextQuestion();
    }

    void Update()
    {
        //atualiza a imagem do timer
        if (timer != null && timerImage != null)
        {
            timerImage.fillAmount = timer.fillFraction;

            if (timer.loadNextQuestion)
            {
                GetNextQuestion();
                timer.loadNextQuestion = false;
            }

            //verifica se respondeu antecipadamente
            else if (hasAnsweredEarly && !timer.isAnsweringQuestion)
            {
                hasAnsweredEarly = false;

                //aqui
                DisplayAnswer(-1);


                SetButtonState(false);
            }
        }
    }

    //método para obter a próxima questão
    public void GetNextQuestion()
    {
        SetButtonState(true);
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        if (perguntasSO != null && perguntasText != null)
        {
            perguntasText.text = perguntasSO.GetQuestion();
            respostasCorretas = perguntasSO.GetCorrectAnswer();

            for (int i = 0; i < respostaButtons.Length; i++)
            {
                TextMeshProUGUI btnText = respostaButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                btnText.text = perguntasSO.GetAnswer(i);
            }
            SetButtonState(true);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;

        if (index == perguntasSO.GetCorrectAnswer())
        {
            perguntasText.text = "Correto!!!!!!";
        }
        else
        {
            string respostaCorreta = perguntasSO.GetAnswer(perguntasSO.GetCorrectAnswer());
            perguntasText.text = "A resposta correta é: " + respostaCorreta;
        }

        SetButtonState(false);
        if (timer != null)
            timer.CancelTimer();
    }

    //método para exibir a resposta, esta no update
    void DisplayAnswer(int index)
    {
        if (index == perguntasSO.GetCorrectAnswer())
        {
            perguntasText.text = "Correto!!!!!!";
        }
        else
        {
            string respostaCorreta = perguntasSO.GetAnswer(perguntasSO.GetCorrectAnswer());
            perguntasText.text = "A resposta correta é: " + respostaCorreta;
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < respostaButtons.Length; i++)
        {
            Button btn = respostaButtons[i].GetComponent<Button>();
            btn.interactable = state;
        }
    }
}
