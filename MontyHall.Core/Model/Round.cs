using MontyHall.Core.Helpers;
using System;
using System.Collections.Generic;

namespace MontyHall.Core.Model
{
    public class Round
    {
        private readonly List<int> Doors = new() { 1, 2, 3 };
        private int CarDoor { get; }
        private int SelectedDoor { get; set; }
        private int OpenedDoor { get; set; }

        private Random Random { get; } = new Random();

        public Round()
        {
            //determine car position
            CarDoor = Random.Next(Doors.Count);
        }

        public void Start()
        {
            //first selection
            SelectedDoor = Random.Next(Doors.Count);
            //open a door which is not selected door and not car door
            OpenedDoor = Random.NextExcept(Doors.Count, new() { SelectedDoor, CarDoor });
        }

        public void Reselect()
        {
            //make new selection which is not the opened door
            SelectedDoor = Random.NextExcept(Doors.Count, new() { OpenedDoor });
        }

        public bool Finalize()
        {
            //check if selected door is car door
            return SelectedDoor == CarDoor;
        }
    }
}
