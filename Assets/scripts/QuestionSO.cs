using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/New Question")]

public class QuestionSO : ScriptableObject
{
    [TextArea(2, 5)]
    [SerializeField] private string question;

    [SerializeField] private string[] repostas;

    [SerializeField] private int respostasCorretas;

    public string GetQuestion()
    {
        return question;
    }

    public int GetCorrectAnswer()
    {
        return respostasCorretas;
    }

    public string GetAnswer(int index)
    {
        if (index >= 0 && index < repostas.Length)
        {
            return repostas[index];
        }
        return "";
    }
}
