using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string path = @"C:\app\proekt.txt";   // путь к файлу

            string text = "Проет Ложков А.А. ИНМЗ 212"; // текст записи в файл

            // Создание файла - запись текста в файл - закрытие файла
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                
                byte[] buffer = Encoding.Default.GetBytes(text);
               
                await fstream.WriteAsync(buffer, 0, buffer.Length);
                Console.WriteLine("Текст записан в файл");
            }

            // Открытие файла  - чтение и вывод данных на консоль - закрытие файла
            using (FileStream fstream = File.OpenRead(path))
            {
            
                byte[] buffer = new byte[fstream.Length];
            
                await fstream.ReadAsync(buffer, 0, buffer.Length);
                

                string textFromFile = Encoding.Default.GetString(buffer);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }
        }
        }
    }
