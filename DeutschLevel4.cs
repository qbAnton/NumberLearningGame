using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///////////////////////////////////////////////////////////////////
//этот уровень должен помочь изучить немецкие числа от 100 до 999//
///////////////////////////////////////////////////////////////////

public class DeutschLevel4 : MonoBehaviour {
    public Text question;    //переменная для вывода слова, которое необходимо будет перевести
    public Text answer;      //тут будут выводиться числа, введенные пользователем
    public Text progress;    //отоброжение прогресса, будет указано количество правильных ответов  
    string answertext = "";  //строка, которую будет выводить public Text answer
    int progres_int = 0;     //число, которое будет выводить public Text progress
    int i;                   //переменная для использования в цикле for   
    int rand;                //случайное число, которое необходимо будет перевести
    int ans = -1;            //число, которое будет отображать набранные числа. я присвоил ему значение -1, потому как в программе мы рассматриваем 
                             //только положительные числа, соостветственно отрицательные числа не будут выводиться
 
    //далее я создаю массивы, из элементов которых в последствии будут составляться наши слова
    //если вместо слова указан "0", значит для написания чисел от 100 до 999 нам эти значения не пригодятся
    //например в массиве One вместо слова null, написано "0", потому как если мы напишем на немецком все числа от 100 до 999, то ни разу не встретим слово "null"
    string[] One = { "0", "ein", "zwei", "drei", "vier", "fünf", "sechs", "sieben", "acht", "neun" };
    string[] Nine = { "zehn ", "elf ", "zwölf ", "dreizehn", "vierzehn ", "fünfzehn ", "sechzehn ", "siebzehn ", "achtzehn ", "neunzehn " };
    string[] Ten = { "0", "0", "zwanzig", "dreißig", "vierzig", "fünfzig", "sechzig", "siebzig ", "achtzig", "neunzig" };

    //массив чисел и строк, которые соответствуют друг другу
    //например, числу ArrayInt[125] = 125 соответствует строка ArrayString[125] = "einhundertfünfundzwanzig"
    //пользователю выводится строка ArrayInt[i] и затем сравнивается введенное им число с числом из массива ArrayInt[i]
    string[] ArrayString = new string[1000];
    int[] ArrayInt = new int[1000];


    void Start()
    {
        FillArray();       
    }

    //заполняем массивы чисел и строк
    //каждая строка формируется по разному, в зависимости от числа, которому она соответствует
    //например, если число состоит только из сотен (200), то строка будет составлена так: One[2] + "hundret"
    //если же это, к примеру, число 578, то оно будет записано следующим образом: One[5] + "hundret" + One[8] + "und" + Ten[7]
    //и так далее, таким образом я повторяю правила написания чисел в немецком языке
    void FillArray()
    {
        rand = Random.Range(100, 999);              
        for (i = 100; i < 999; i++)
        {
                ArrayInt[i] = i;
            if (i % 100 == 0)
            {
                int one = i / 100;
                ArrayString[i] = One[one] + "hundert";
            }
            else if (i % 10 == 0)
            {
                int hun = i / 100;
                int ten = i % 100 / 10;
                ArrayString[i] = One[hun] + "hundert" + Ten[ten];
            }
            else if (i % 100 > 19)
            {
                int hun = i / 100;
                int one = i % 100 % 10;
                int ten = i % 100 / 10;
                ArrayString[i] = One[hun] + "hundert" + One[one] + "und" + Ten[ten];
            }
            else if (i % 100 / 10 == 0)
            {
                int hun = i / 100;
                int one = i % 100 % 10;
                ArrayString[i] = One[hun] + "hundert" + One[one];
            }
            else
            {
                int hun = i / 100;
                int nine = i % 100 % 10;
                ArrayString[i] = One[hun] + "hundert" + Nine[nine];
            }
            Debug.Log(ArrayInt[i] + ArrayString[i]);    
            }
        }

    //ввод чисел пользователем
    #region buttons_numbers
    public void zero()
    {
        if (ans > 0)
        {
            ans = ans * 10;

        }
        else
        {
            ans = 0;
        }
    }

    public void one()
    {
        if (ans > 0)
        {
            ans = ans * 10 + 1;
        }
        else
        {
            ans = 1;
        }
    }

    public void two()
    {
        if (ans > 0)
        {
            ans = ans * 10 + 2;
        }
        else
        {
            ans = 2;
        }
    }

    public void three()
    {
        if (ans > 0)
        {
            ans = ans * 10 + 3;
        }
        else
        {
            ans = 3;
        }
    }

    public void four()
    {
        if (ans > 0)
        {
            ans = ans * 10 + 4;
        }
        else
        {
            ans = 4;
        }
    }

    public void five()
    {
        if (ans > 0)
        {
            ans = ans * 10 + 5;
        }
        else
        {
            ans = 5;
        }
    }

    public void six()
    {
        if (ans > 0)
        {
            ans = ans * 10 + 6;
        }
        else
        {
            ans = 6;
        }
    }

    public void seven()
    {
        if (ans > 0)
        {
            ans = ans * 10 + 7;
        }
        else
        {
            ans = 7;
        }
    }

    public void eight()
    {
        if (ans > 0)
        {
            ans = ans * 10 + 8;
        }
        else
        {
            ans = 8;
        }
    }

    public void nine()
    {
        if (ans > 0)
        {
            ans = ans * 10 + 9;
        }
        else
        {
            ans = 9;
        }
    }
    #endregion

    #region buttons_other
    public void back()
    {
        Application.LoadLevel(0);
    }

   

    public void OK()
    {
        if (ans == ArrayInt[rand])
        {
            ans = -1;
            progres_int++;
            FillArray();
        }
        else
        {
            ans = -1;
        }
        if (progres_int > 20)
        {
            Application.LoadLevel(5);
        }
    }
    public void Clear()
    {
        ans = -1;
    }
    #endregion

    void OnGUI()
    {

        if (ans >= 0)
        {

            answertext = ans.ToString();
        }
        else
        {
            answertext = "";
        }

        question.text = "" + ArrayString[rand];
        answer.text = "" + answertext;
        progress.text = "" + progres_int + "/20";
    }
}
