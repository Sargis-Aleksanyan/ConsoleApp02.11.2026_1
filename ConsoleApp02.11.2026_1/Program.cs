namespace ConsoleApp02._11._2026_1
{
    public class Library
    {
        public delegate void Visit(string name); 

        private List<Visit> permanentSubscribers = new List<Visit>();
        private List<Visit> onceSubscribers = new List<Visit>();

        public void Subscribe(Visit x)
        {
            permanentSubscribers.Add(x);
        }

        public void Unsubscribe(Visit x)
        {
            permanentSubscribers.Remove(x);
        }

        public void SubscribeOnce(Visit x)
        {
            onceSubscribers.Add(x);
        }

        public void Enter(string name)
        {
            foreach(var subscriber in permanentSubscribers)
            {
                subscriber(name);
            }
            foreach (var subscriber in onceSubscribers)
            {
                subscriber(name);
            }
            onceSubscribers.Clear();
        }
    }

    public class Desk
    {
        int VisitorsCount = 0;

        public void Visit(string name)
        {
            VisitorsCount++;
            Console.WriteLine($"{VisitorsCount} {name}");
        }
    }

    internal class Program
    {
        static void Chime(string name) => Console.WriteLine($"Chime {name}");
        static void Slip(string name) => Console.WriteLine($"Slip {name}");
        static void Card(string name) => Console.WriteLine($"Card {name}");
        static void Hold(string name) => Console.WriteLine($"Hold {name}");

        static void Main(string[] args)
        {
            Library lib = new Library();
            Desk desk = new Desk();

            lib.Subscribe(desk.Visit);
            lib.Subscribe(Chime);

            lib.SubscribeOnce(Slip);
            lib.SubscribeOnce(Card);

            lib.Enter("Ana");

            lib.Enter("Leo");

            lib.Unsubscribe(desk.Visit);
            lib.SubscribeOnce(Hold);

            lib.Enter("Mia");
        }
    }
}
