//Лабораторная работа №4
//Создайте структуру "Студент" с полями: фамилия и инициалы, номер группы, успеваемость (массив из пяти элементов)
//Создать массив из семи объектов и упорядочить его по возрастанию среднего балла

using System;
using pringls = System.Console; //меняем Console на чипсы

// создаем структуру "Студент"
struct Student
{
    public string name; // имя
    public int group; // номер группы
    public int[] mark; // успеваемость

    public double GetArithmeticMean()
    {
        double sum = 0;
        for (int i = 0; i < mark.Length; i++) 
        {
            sum += mark[i];
        }
        return sum / mark.Length; //складываем все оценки и делим на их количество (5)
    }
}

class Program
{
    static void Main(string[] args)
    {
        // создаем массив из семи объектов типа "Студент"
        Student[] students = new Student[7];

        // заполняем массив
        students[0] = new Student { name = "Джонни Депп", group = 1, mark = new int[5] };
        students[1] = new Student { name = "Леонардо Ди Каприо", group = 2, mark = new int[5] };
        students[2] = new Student { name = "Кшиштоф Занусси", group = 1, mark = new int[5] };
        students[3] = new Student { name = "Уилл Смит", group = 3, mark = new int[5] };
        students[4] = new Student { name = "Брэд Питт", group = 2, mark = new int[5] };
        students[5] = new Student { name = "Том Круз", group = 3, mark = new int[5] };
        students[6] = new Student { name = "Клинт Иствуд", group = 1, mark = new int[5] };
        for (int j = 0; j < 7; j++) {
            students[j].mark = RandomMark(); // оценки для 7ми студентов
        }
        
        // сортируем массив по возрастанию среднего балла
        Array.Sort(students, (a, b) => a.GetArithmeticMean().CompareTo(b.GetArithmeticMean()));

        // выводим отсортированный массив на экран
        foreach (Student student in students)
        {
            pringls.WriteLine($"{student.name}, Группа: {student.group}, {ConvertToSring(student.mark)}, Средний балл: {student.GetArithmeticMean()}");
        }
    }
    public static string ConvertToSring(int[] marksString) { //превращаем int в string, чтобы добавить строку, выводящую рандомные 5 оценок
        string marks = "Оценки: ";
        marks += String.Join(" ", marksString);
        return marks;
    }
    public static int[] RandomMark() //генератор пяти разных оценок
    {
        Random rand = new Random();
        int[] mark = new int[5];
        for (int i = 0; i < 5; i++)
        {
            mark[i] = rand.Next(2, 6); //2, 3, 4, 5
        }
        return mark;
    }
}
