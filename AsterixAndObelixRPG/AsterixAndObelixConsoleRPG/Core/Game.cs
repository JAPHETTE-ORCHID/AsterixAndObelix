using System;
using System.Threading;

namespace AsterixAndObelixConsoleRPG.Core
{
    internal class Game
    {
        private Thread thread;
        private Engine engine;

        private void Run()
        {
            while (true)
            {
                engine.CommandHandler(Console.ReadLine());
                Thread.Sleep(1000);
                Console.WriteLine("asd2");
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
