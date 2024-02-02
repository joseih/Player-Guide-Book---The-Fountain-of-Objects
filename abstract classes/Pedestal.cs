using System;


namespace TheFountainObjects.abstract_classes
{
    internal class Pedestal : Room
    {
        private bool isActive;
        public override void TellInfo()
        {
            Console.WriteLine("the pedestal room");
        }
        public void Action()
        {
            isActive = true;
        }

    }
}
