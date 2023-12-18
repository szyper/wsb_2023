using System;
using System.Collections.Generic;

// Interfejs, który definiuje kontrakt dla listy liczb losowych
public interface IRandomList
{
    // Właściwość zwracająca liczbę elementów na liście
    int Count { get; }

    // Metoda, która wyświetla listę na konsoli
    void Display();

    // Metoda, która zwraca listę liczb podzielnych przez 3 lub 5
    List<int> DivisibleBy3Or5();

    // Metoda, która zwraca listę liczb nieparzystych
    List<int> Odd();

    // Metoda, która zwraca listę liczb posortowanych rosnąco
    List<int> Ascending();

    // Metoda, która zwraca listę liczb posortowanych malejąco
    List<int> Descending();

    // Zdarzenie, które jest wywoływane, gdy lista liczb losowych jest pusta
    public event EmptyListHandler EmptyList;
}

// Delegat, który reprezentuje operację na liście liczb losowych
delegate List<int> ListOperation(RandomList list);

// Delegat, który reprezentuje metodę obsługi zdarzenia EmptyList
public delegate void EmptyListHandler();

// Klasa reprezentująca listę liczb losowych, która implementuje interfejs IRandomList
class RandomList : IRandomList
{
    // Pole przechowujące listę liczb
    private List<int> list;

    // Właściwość zwracająca liczbę elementów na liście
    public int Count
    {
        get
        {
            return list.Count;
        }
    }

    // Konstruktor, który tworzy listę o podanej długości i wypełnia ją losowymi liczbami z podanego zakresu
    public RandomList(int length, int min, int max)
    {
        // Tworzenie pustej listy
        list = new List<int>();

        // Tworzenie obiektu generatora liczb losowych
        Random rnd = new Random();

        // Wypełnianie listy losowymi liczbami
        for (int i = 0; i < length; i++)
        {
            list.Add(rnd.Next(min, max + 1));
        }

        // Sprawdzanie, czy lista jest pusta
        if (list.Count == 0)
        {
            // Wywołanie zdarzenia EmptyList, jeśli ma jakichś subskrybentów
            /*
             * EmptyList?.Invoke() jest wyrażeniem w języku C#, które wywołuje delegat o nazwie EmptyList, jeśli nie jest on null. Jest to skrót od EmptyList != null ? EmptyList.Invoke() : null. Operator ?. nazywa się operatorem null-conditional i pozwala na sprawdzenie, czy wartość po lewej stronie jest null, zanim wywoła się metodę lub właściwość po prawej stronie. Jeśli wartość po lewej stronie jest null, całe wyrażenie zwraca null, zamiast rzucać wyjątek NullReferenceException
             */
            EmptyList?.Invoke();
        }
    }

    // Metoda, która wyświetla listę na konsoli
    public void Display()
    {
        // Sprawdzanie, czy lista jest pusta
        if (list.Count == 0)
        {
            // Wywołanie zdarzenia EmptyList, jeśli ma jakichś subskrybentów
            EmptyList?.Invoke();
            return;
        }

        // Przechodzenie po liście i wyświetlanie liczb
        foreach (int x in list)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }

    // Metoda, która zwraca listę liczb podzielnych przez 3 lub 5
    public List<int> DivisibleBy3Or5() // usunięcie parametru list
    {
        // Tworzenie pustej listy
        List<int> result = new List<int>();

        // Przechodzenie po liście i sprawdzanie warunku podzielności
        foreach (int x in list) // używanie pola list zamiast parametru list
        {
            if (x % 3 == 0 || x % 5 == 0)
            {
                // Dodawanie liczby do listy wynikowej
                result.Add(x);
            }
        }

        // Zwracanie listy wynikowej
        return result;
    }


    // Metoda, która zwraca listę liczb nieparzystych
    public List<int> Odd()
    {
        // Tworzenie pustej listy
        List<int> result = new List<int>();

        // Przechodzenie po liście i sprawdzanie warunku nieparzystości
        foreach (int x in list)
        {
            if (x % 2 != 0)
            {
                // Dodawanie liczby do listy wynikowej
                result.Add(x);
            }
        }

        // Zwracanie listy wynikowej
        return result;
    }

    // Metoda, która zwraca listę liczb posortowanych rosnąco
    public List<int> Ascending()
    {
        // Tworzenie kopii listy
        List<int> result = new List<int>(list);

        // Sortowanie listy rosnąco
        result.Sort();

        // Zwracanie listy wynikowej
        return result;
    }

    // Metoda, która zwraca listę liczb posortowanych malejąco
    public List<int> Descending()
    {
        // Tworzenie kopii listy
        List<int> result = new List<int>(list);

        // Sortowanie listy malejąco
        result.Sort();
        result.Reverse();

        // Zwracanie listy wynikowej
        return result;
    }

    // Zdarzenie, które jest wywoływane, gdy lista liczb losowych jest pusta
    public event EmptyListHandler? EmptyList;
}

class Program
{
    // Metoda statyczna, która przyjmuje obiekt klasy RandomList, delegat ListOperation i wiadomość do wyświetlenia
    static void PerformOperation(IRandomList list, ListOperation operation, string message) // zmiana typu parametru na IRandomList
    {
        // Wywołanie delegata na obiekcie RandomList
        List<int> result = operation(list as RandomList); // użycie operatora as, aby przekonwertować obiekt interfejsu na obiekt klasy

        // Wyświetlanie wynikowej listy z podaną wiadomością
        Console.WriteLine(message);
        foreach (int x in result)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }

    static void ShowMessage()
    {
        Console.WriteLine("Lista jest pusta!");
    } 

    static void ShowMenu()
    {
        Console.WriteLine("Co chesz zrobić z listą?");
        Console.WriteLine("1. Wyświetlić listęliczb podzielnycg przez 3 lub 5");
        Console.WriteLine("2. Wyświetlić listę liczb nieparzystych");
        Console.WriteLine("3. Wyświetlić listę liczb posortowanych niemalejąco");
        Console.WriteLine("4. Wyświetlić listę liczb posortowanych nierosnąco");
        Console.WriteLine("5. Wyjść z programu");
    }
    static void Main(string[] args)
    {
        IRandomList randomList = new RandomList(20, 1, 100);
        randomList.EmptyList += ShowMessage;

        Console.WriteLine("Lista liczb losowych:");
        randomList.Display();

        int choice = 0;

        do
        {
            ShowMenu();

            Console.Write("Podaj swój wybór:");
            string? input = Console.ReadLine();

            if (input != null)
            {
                bool success = int.TryParse(input, out choice);
                if (success)
                {
                    switch (choice)
                    {
                        case 1:
                            PerformOperation(randomList, list => list.DivisibleBy3Or5(), "Lista liczb podzielnych przez 3 lub 5");
                        break;
                        case 2:
                            PerformOperation(randomList, list => list.Odd(), "Lista liczb nieparzystych");
                            break;
                        case 3:
                            PerformOperation(randomList, list => list.Ascending(), "Lista liczb niemalejących");
                        break;
                        case 4:
                            PerformOperation(randomList, list => list.Descending(), "Lista liczb nierosnących");
                            break;
                        case 5:
                            Console.WriteLine("Dziękujęza skorzystanie z programu. Do zobaczenia");
                        break;
                        default:
                            Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Nie podano żadnego wyboru. Spróbuj ponownie");
            }
        }
        while (choice != 5);
    }
}

