using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons; 
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;



    void Start()
    {
        GetNextQuestion();
        DisplayQuestion();
        
    }



    public void OnAnswerSelected(int index)
    {
        Image buttonImage;

        if(index == question.GetCorrectAnsweIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;

        }
        else
        {
            correctAnswerIndex = question.GetCorrectAnsweIndex();
            string correctAnswer = question.getAnswer(correctAnswerIndex);
            questionText.text = "Sorry, the correct answer was;\n" + correctAnswer;

            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;

        }
        SetButtonState(false);

    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for(int i = 0; i <answerButtons.Length ;i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.getAnswer(i);

        }

    }

    void SetButtonState(bool state)
    {
        for(int i =0; i<answerButtons.Length;i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        setDefaultButtonSprites();
        DisplayQuestion();
    }

    void setDefaultButtonSprites()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {   
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
