using System;
using System.Threading;

namespace AsterixAndObelixConsoleRPG.Core
{
    internal class Game
    {
        private Thread thread;
        private Engine engine;
        public static bool isGameRunning = true; 

        private void Run()
        {
            while (isGameRunning)
            {
                try
                {
                    engine.CommandHandler(Console.ReadLine());
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

        public void Start()
        {
            if (this.thread == null)
            {
                this.engine = new Engine();
                this.thread = new Thread(this.Run);
                thread.Start();
            }
        }

        public void Stop()
        {
            if (this.thread != null)
            {
                this.thread.Abort();
            }
        }
    }
}
