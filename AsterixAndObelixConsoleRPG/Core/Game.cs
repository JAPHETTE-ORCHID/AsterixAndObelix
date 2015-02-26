namespace AsterixAndObelixConsoleRPG.Core
{
    using System;
    using System.Threading;
    using CustomExceptions;

    public struct Game
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
                        Console.WriteLine("-------------------Welcome to our game \"Asterix and Obelix\".-------------------");
                        Console.WriteLine();
                        Console.WriteLine("1.For start playing the game you must create a hero.");
                        Console.WriteLine("-------------------------------------------------------------------------------");
                        Console.WriteLine("2.For creating a hero you must type add hero.");
                        Console.WriteLine("-------------------------------------------------------------------------------");
                        Console.WriteLine("3.After that you must choice which type of hero you want to play.");
                        Console.WriteLine("-------------------------------------------------------------------------------");
                        Console.WriteLine("4.The two type of hero are: Asterix and Obelix.");
                        Console.WriteLine("-------------------------------------------------------------------------------");
                        Console.WriteLine("5.For example you may type: \"add hero asterix\" or \"add hero obelix\".");
                        Console.WriteLine();
                        tick++;
                    }

                    this.engine.CommandHandler(Console.ReadLine());
                }
                catch (InputException ie)
                {
                    Console.Error.WriteLine(ie.Message);
                }
                catch (InvalidEnemyException iee)
                {
                    Console.Error.WriteLine(iee.Message);
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