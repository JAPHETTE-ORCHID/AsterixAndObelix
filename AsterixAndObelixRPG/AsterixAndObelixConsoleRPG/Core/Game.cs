namespace AsterixAndObelixConsoleRPG.Core
{
    using AsterixAndObelixConsoleRPG.CustomException;
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
            while (IsGameRunning)
            {
                try
                {
                    this.engine.CommandHandler(Console.ReadLine());
                }
                catch (InvalidEnemyException iee)
                {
                    Console.Error.WriteLine(iee.Message);
                }
                catch (ApplicationException ae)
                {
                    Console.Error.WriteLine(ae + ae.Message);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                }
            }
        }
    }
}
