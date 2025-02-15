#include <iostream> // Подключаем библиотеку для ввода-вывода
#include <vector>   // Подключаем библиотеку для работы с векторами
#include <string>   // Подключаем библиотеку для работы со строками

// Определяем структуру для хранения характеристик электронной книги
struct EBook
{
    std::string manufacturer; // Фирма-производитель
    float screenSize;         // Размер экрана
    bool hasBacklight;        // Наличие подсветки экрана
};

// Функция для ввода данных о структуре из консоли
void inputEBook(EBook* book)
{
    std::cout << "Введите фирму-производителя: ";
    std::getline(std::cin, book->manufacturer); // Считываем строку с названием фирмы
    std::cout << "Введите размер экрана (дюймы): ";
    std::cin >> book->screenSize; // Считываем размер экрана
    std::cout << "Наличие подсветки экрана (1 - да, 0 - нет): ";
    std::cin >> book->hasBacklight; // Считываем наличие подсветки
    std::cin.ignore(); // Игнорируем оставшийся символ новой строки
}

// Функция для вывода данных о структуре
void printEBook(const EBook& book)
{
    std::cout << "Фирма-производитель: " << book.manufacturer << std::endl; // Выводим фирму
    std::cout << "Размер экрана: " << book.screenSize << " дюймов" << std::endl; // Выводим размер экрана
    std::cout << "Подсветка экрана: " << (book.hasBacklight ? "Да" : "Нет") << std::endl; // Выводим наличие подсветки
}

// Функция для создания динамических экземпляров структуры и сохранения их в вектор
void createEBooks(std::vector<EBook>& books)
{
    for (int i = 0; i < 2; ++i)
    { // Создаем 2 экземпляра
        EBook book; // Создаем экземпляр структуры
        inputEBook(&book); // Вызываем функцию ввода данных
        books.push_back(book); // Добавляем экземпляр в вектор
    }
}
enum class Menu
{
    InputBooks=1,
    PrintBooks,
    Exit
}
// Функция main с псевдоменю
int main()
{
    std::vector<EBook> books; // Вектор для хранения экземпляров электронной книги
    int choice; // Переменная для выбора действия

    do
    {
        std::cout << "Меню:\n";
        std::cout << "1. Ввести данные о книгах\n";
        std::cout << "2. Вывести данные о книгах\n";
        std::cout << "0. Выход\n";
        std::cout << "Выберите действие: ";
        std::cin >> choice; // Считываем выбор пользователя
        std::cin.ignore(); // Игнорируем оставшийся символ новой строки

        switch (choice)
        {
            case Menu::InputBooks:
                createEBooks(books); // Вызываем функцию для создания книг
                break;
            case Menu::PrintBooks:
                for (const auto&book : books) { // Проходим по всем книгам в векторе
                    printEBook(book); // Вызываем функцию для вывода данных о книге
                }
                break;
            case Menu::Exit:
    std::cout << "Выход из программы." << std::endl; // Сообщение о выходе
    break;
default:
    std::cout << "Неверный выбор. Попробуйте снова." << std::endl; // Сообщение об ошибке
}
    } while (choice != 0) ; // Продолжаем, пока пользователь не выберет выход

return 0; // Завершаем программу
}
