// --- Начало программы ----------------/\---/\------------------------------------------------
// --------------------------------------*---*-------------------------------------------------
// ---------------------------------------\*/--------------------------------------------------


// --- Блок методов ---------------------------------------------------------------------------
// --------------------------------------------------------------------------------------------

using System.Dynamic;

static bool SumDigitsEvenOrOdd(int num) // Четная или нечетная сумма цифр у числа
{   
    int sum = 0;
    int order;
    int num1 = num;
    
    while (num1 > 10) {

        order = 1;

        while(num1 > 10) {

            num1 /= 10;
            order *= 10;

        }

        sum += num1;
        num1 = num - num1 * order;
        num = num1;

    }

    sum += num1;

    if (sum % 2 == 0) {
        return true;
    } else {
        return false;
    }

}

static bool CheckStop(string str) // проверка выполнения условия для остановки программы
{
    bool result = false;

    if (Int32.TryParse(str, out int num) == false) {        
        Console.Write("> Вы ввели строку '{0}'!\n", str);
        num = 1;
    } else {
        Console.Write("> Вы ввели число '{0}'!\n", num);
    }

    if ( num < 0 ) num *= -1;
 
    if (str == "q" || SumDigitsEvenOrOdd(num)) result = true;
    
    return result;
    
}

static int[] FillArray3digitNumbers(int volume, int LowerBound, int UpperBound) // Заполнение массива целыми числами
{
    
    Random rnd1 = new();

    if ( volume < 0 ) volume *= -1;

    int[] result = new int[volume];
 
    for ( int i = 0; i < volume; i++ ) {
        result[i] = rnd1.Next(LowerBound, UpperBound);
    }
    
    return result;
    
}

static int CountingEvenNumInArray(int[] array) // Подсчет четных чисел в массиве
{   
    int cnt = 0;
    int volume = array.Length;

    for ( int i = 0; i < volume; i++ ) {
        
        if (array[i] % 2 == 0) {
            cnt++; 
            Console.Write("> Элемент массива '{0}'\t= {1} *\n", i, array[i]);   
        } else {
            Console.Write("> Элемент массива '{0}'\t= {1}\n", i, array[i]);
        }

    }

    return cnt;

}

static int RequestSizeOfArray() // Запрашивает в консоли число для определения размера массива
{    
    string? str;
    string str1;

    Console.Write("> Введите требуемое число элементов массива: ");
    
    str = Console.ReadLine();
    str1 = str ?? "";

    if (Int32.TryParse(str1, out int num) == false) {        
        Console.Write("> Вы ввели число 0. Массив не будет сформирован.\n");
        num = 0;
    }

    return num;

}

static int[] ReverseArray(int[] arrayOrig) // Процедура, которая переворачивает массив
{

    int arrLn = arrayOrig.Length;

    int arrLnM1 = arrLn - 1;

    int[] arrayFix = new int[arrLn];

    for ( int i = 0; i < arrLn; i++ ) {

        arrayFix[i] = arrayOrig[arrLnM1 - i];

    }

    return arrayFix;

}

static void ShowArray(int[] array) // Вывод массива на экран
{   
    int length = array.Length;

    for ( int i = 0; i < length; i++ ) { 
        
        Console.Write("> Элемент массива '{0}'\t= {1}\n", i, array[i]);   
        
    }

}

static void Task1() {

    string? str;
    string str1;
    bool stop;

    Console.Write("> Вас приветствует программы тестирования ввода символов и чисел с клавитуры!\n");
    Console.Write("> Для выхода из программы введите символ 'q' или число, с четной суммой цифр: ");
    
    str = Console.ReadLine();
    str1 = str ?? "";

    stop = CheckStop(str1);

    while (stop == false) {

        Console.Write("> Для выхода введите символ 'q' или число, сумма цифр которого - четная: ");
        str = Console.ReadLine();
        str1 = str ?? "";
        stop = CheckStop(str1);

    }

    Console.Write("> Работа программы завершена!");

}

static void Task2() {

    string? str;
    string str1;
    int[] array;
    
    Console.Write("> Вас приветствует программы подсчета четных чисел в массиве!\n");
    Console.Write("> Введите требуемое число элементов массива: ");
    
    str = Console.ReadLine();
    str1 = str ?? "";

    if (Int32.TryParse(str1, out int num) == false) {        
        Console.Write("> Вы ввели число 0. Массив не будет сформирован.\n");
        num = 0;
    }

    array = FillArray3digitNumbers(num, 100, 1000);

    Console.Write("> Количество четных чисел в массиве = {0}.\n", CountingEvenNumInArray(array));

    Console.Write("> Работа программы завершена!");

}

static void Task3() {

    int[] array;
    
    Console.Write("> Вас приветствует программы, которая переворачивает одномерный массив!\n");
    
    int num = RequestSizeOfArray();

    array = FillArray3digitNumbers(num, 100, 1000);

    Console.Write("> Исходный массив:\n");

    ShowArray(array);

    array = ReverseArray(array);

    Console.Write("> Перевернутый массив:\n");

    ShowArray(array);

    Console.Write("> Работа программы завершена!");

}

// --- end ------------------------------------------------------------------------------------



// --- Основной блок --------------------------------------------------------------------------
// --------------------------------------------------------------------------------------------

// Задача 1: Напишите программу, которая бесконечно запрашивает 
// целые числа с консоли. Программа завершается при вводе символа ‘q’
// или при вводе числа, сумма цифр которого чётная.

Task1();

// Задача 2: Задайте массив заполненный случайными трёхзначными числами. 
// Напишите программу, которая покажет количество чётных чисел в массиве.

Task2();

// Задача 3: Напишите программу, которая перевернёт одномерный массив 
// (первый элемент станет последним, второй – предпоследним и т.д.)

Task3();

// --- end ------------------------------------------------------------------------------------
