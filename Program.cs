namespace Hw_26_09
{
     class Program
    {
        static bool running = true;
        static void Main(string[] args)
        {
            Random random = new Random();
            int roomCount = 5;
            int second = 10;

            Thread[] threads = new Thread[roomCount];
            for (int i = 0; i < roomCount; i++)
            {
                int roomNumber = i + 1;
                threads[i] = new Thread(() => Method(roomNumber));
                threads[i].Start();
            }
            Thread.Sleep(second * 1000);
             running = false;

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine("Simulation end");
        }
        static void Method(int RoomCount)
        {
            Random rand = new Random();
            while(running)
            {
                int temperature = rand.Next(-15, 30);
                Console.WriteLine($"Комната {RoomCount}: Температура {temperature}");
                Thread.Sleep(1000);
            }
        }

        
    }
}
