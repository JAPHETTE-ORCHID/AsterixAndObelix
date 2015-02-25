namespace AsterixAndObelixConsoleRPG.Core
{
    using System;
    using System.Threading;

    internal class Game
    {
        public static bool IsGameRunning = true;
        private Thread thread;
        private Engine engine;

        public void Start()
        {
            if (this.thread == null)
            {
                this.engine = new Engine();
                this.thread = new Thread(this.Run);
                this.thread.Start();
            }
        }

        public void Stop()
        {
            if (this.thread != null)
            {
                this.thread.Abort();
            }
        }

        private void Run()
        {
            int tick = 0;
            while (IsGameRunning)
            {
                try
                {
                    if (tick == 0)
                    {
                        Console.WriteLine("Message");
                        tick++;
                    }

                    this.engine.CommandHandler(Console.ReadLine());
                }
                catch (ApplicationException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
