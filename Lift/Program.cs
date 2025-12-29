using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

enum Direction
{
 Up,
 Down,
 Idle
}

class Elevator
{
    public int CurrentFloor { get; private set; }
    public Direction CurrentDirection { get; private set; }

    private SortedSet<int> upQueue = new();
    private SortedSet<int> downQueue = new();

    public Elevator(int startFloor=1)
    {
        CurrentFloor = startFloor;
        CurrentDirection = Direction.Idle;
    }

    public void AddRequest(int floor)
    {
        if (floor == CurrentFloor)
        {
            Console.WriteLine($"Elevator is already on floor {floor}.");
            return;
        }

        if (floor > CurrentFloor)
        {
            upQueue.Add(floor);
        }
        else
        {
            downQueue.Add(floor);
        }

        if (CurrentDirection == Direction.Idle)
        {
            ChooseDirection();
        }
    }

    private void ChooseDirection()
    {
            if (upQueue.Count > 0)
            {
                CurrentDirection = Direction.Up;
            }
            else if (downQueue.Count > 0)
            {
                CurrentDirection = Direction.Down;
            }
            else CurrentDirection = Direction.Idle;
    }

    private void Tick()
    {
        if (CurrentDirection == Direction.Idle)
        {
            ChooseDirection();
            return;
        }

        CurrentFloor += CurrentDirection == Direction.Up ? 1 : -1;
        Console.WriteLine($"Elevator at floor {CurrentFloor} ({CurrentDirection}).");

        if (CurrentDirection == Direction.Up && upQueue.Contains(CurrentFloor))
        {
            upQueue.Remove(CurrentFloor);
            Console.WriteLine($"Stopping at floor {CurrentFloor} to let passengers off.");
        }
        else if (CurrentDirection == Direction.Down && downQueue.Contains(CurrentFloor))
        {
            downQueue.Remove(CurrentFloor);
            Console.WriteLine($"Stopping at floor {CurrentFloor} to let passengers off.");
        }

        if (CurrentDirection == Direction.Up && upQueue.Count == 0 && downQueue.Count > 0)
            CurrentDirection = Direction.Down;
        else if (CurrentDirection == Direction.Down && downQueue.Count == 0 && upQueue.Count > 0)
            CurrentDirection = Direction.Up;
        else if (upQueue.Count == 0 && downQueue.Count == 0)
            CurrentDirection = Direction.Idle;
    }

    public void PrintStatus()
    {
        Console.WriteLine($"Current Floor: {CurrentFloor}, Direction: {CurrentDirection}");
        Console.WriteLine($"Up Queue: {string.Join(", ", upQueue)}");
        Console.WriteLine($"Down Queue: {string.Join(", ", downQueue)}");
    }

    class Program
    {
        static void Main(string[] args)
        {
            var elevator = new Elevator();

            Console.WriteLine("Commands: call <floor>, tick, status, exit");

            while ( true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                if (input == null) continue;

                var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                switch (parts[0])
                {
                    case "call":
                        if (parts.Length == 2 && int.TryParse(parts[1], out int floor))
                            elevator.AddRequest(floor);
                        break;
                    case "tick":
                        elevator.Tick();
                        break;
                    case "status":
                        elevator.PrintStatus();
                        break;
                    case "exit":
                        return;

                }
                
                    
                
            }
        }
    }
}
