using System;
using System.Threading;

namespace AsterixAndObelixConsoleRPG.Core
{
    public class Engine
    {
        private Thread thread;

        public void Start()
        {
            if (this.thread == null)
            {
                Game game = new Game();
                this.thread = new Thread(game.Run);
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