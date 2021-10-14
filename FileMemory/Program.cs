using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileMemory
{
    class MyString : IDisposable
    {
        ~MyString()
        {

        }

        public void Dispose()
        {
            GC.Collect();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите текст для загрузки: ");
            string textForFile = Console.ReadLine();

            Console.WriteLine();

            #region Write
            // Доступ на уровне байтов
            using (FileStream file = new FileStream("text(FileStream).txt", FileMode.OpenOrCreate))
            {
                Console.WriteLine("Начата запись в файл(FileStream)");

                byte[] textInBytes = Encoding.Default.GetBytes(textForFile);
                file.Write(textInBytes, 0, textInBytes.Length);

                Console.WriteLine("Запись окончена");
            }
            Console.WriteLine( );

            // Доступ на уровне бинарных значений
            using (BinaryWriter file = new BinaryWriter(File.Open("text(BinaryWriter-BinaryReader).dat", FileMode.OpenOrCreate)))
            {
                Console.WriteLine("Начата запись в файл(BinaryWriter)");

                file.Write(textForFile);

                Console.WriteLine("Запись окончена");
            }
            Console.WriteLine();

            // Доступ на уровне строковых значений
            using (StreamWriter file = new StreamWriter(File.Open("text(StreamWriter-StreamReader).txt", FileMode.OpenOrCreate)))
            {
                Console.WriteLine("Начата запись в файл(StreamWriter)");

                file.Write(textForFile);

                Console.WriteLine("Запись окончена");
            }
            #endregion

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            #region Read
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Идет загрузка файлов...");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            using (FileStream file = new FileStream("text(FileStream).txt", FileMode.Open))
            {
                Console.WriteLine("Начато чтение из файла(FileStream)");

                byte[] textInBytes = new byte[file.Length];
                file.Read(textInBytes, 0, textInBytes.Length);
                Console.WriteLine($"Текст файла: {Encoding.Default.GetString(textInBytes)}");

                Console.WriteLine("Чтение окончено");
            }
            Console.WriteLine();

            using (BinaryReader file = new BinaryReader(File.Open("text(BinaryWriter-BinaryReader).dat", FileMode.Open)))
            {
                Console.WriteLine("Начато чтение из файла(BinaryWriter)");

                string textInBytes = "";
                while(file.PeekChar() > -1)
                {
                    textInBytes += file.ReadString();
                }
                Console.WriteLine($"Текст файла: {textInBytes}");

                Console.WriteLine("Чтение окончено");
            }
            Console.WriteLine();

            using (StreamReader file = new StreamReader(File.Open("text(StreamWriter-StreamReader).txt", FileMode.Open)))
            {
                Console.WriteLine("Начато чтение из файла(StreamWriter)");

                Console.WriteLine($"Текст файла: {file.ReadToEnd()}");

                Console.WriteLine("Чтение окончено");
            }
            #endregion

            #region Всякая шняга
            DirectoryInfo directory = new DirectoryInfo(Environment.CurrentDirectory);
            FileInfo[] listOfFies = directory.GetFiles();

            FileInfo fileInfo = new FileInfo(@"C:\Users\Admin\Desktop\FileMemory\FileMemory\bin\Debug\netcoreapp3.1");
            #endregion

            using(MyString str = new MyString())
            {

            }
        }
    }
}
