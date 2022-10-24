using System.Diagnostics;

//Наша задача — сравнить производительность вставки в List<T> и LinkedList<T>.Для этого используйте уже знакомый вам StopWatch.

namespace FP_13Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\admin\\Desktop\\Text1.txt";

            var timer = Enter_List(path);

            Console.WriteLine("Производительность вставки в List<T>: " + timer.ElapsedMilliseconds.ToString() + " мс");

            var time = Enter_LinkedList(path);

            Console.WriteLine("Производительность вставки в LinkedList<T>: " + time.ElapsedMilliseconds.ToString() + " мс");
        }

        static Stopwatch Enter_List(string path)
        {
            var textList = new List<string>();

            var timer = new Stopwatch();
            timer.Start();
            // Вставка в List<T>
            textList = File.ReadAllLines(path).ToList();

            timer.Stop();
            return timer;
        }

        static Stopwatch Enter_LinkedList(string path)
        {
            var txtLinkedList = new LinkedList<string>();
            // Потоки чтения
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            var time = new Stopwatch();
            time.Start();
            // Пока не окончится чтение, вставка в LinkedList<T>
            while (!sr.EndOfStream)
            {
                txtLinkedList.AddLast(sr.ReadLine());
            }
            sr.Close();

            time.Stop();
            return time;
        }
    }
}