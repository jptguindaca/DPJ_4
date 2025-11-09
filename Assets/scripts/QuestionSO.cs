using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Question", menuName = "New Question")]

public class QuestionSO : ScriptableObject
{
    [TextArea(2, 5)]
    [SerializeField] private string question;

    [SerializeField] private string[] Questions = {"ola", "adeus", "bom dia", "bora comprar pokemno booster para comprar no ebay"};

    [SerializeField] private int resposta1;

    public string GetQuestion()
    {
        return question;
    }
    public string GetCorrectAnswerIndex()
    {
        return Questions[resposta1];
    }
    public string GetAnswer()
    {
        return Questions[resposta1];
    }










}
