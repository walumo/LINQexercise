using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    static class Program
    {
        public enum ShipType
        {
            SmallCruiser,
            LargeCruiser,
            Tanker
        }
        static void Main(string[] args)
        {
            List<IShip> cruiseShips = new List<IShip>();
            List<string> cargoManifest = new List<string>();

            CruiseShip wallabie = new CruiseShip() { ShipId = 1, Name = "M/S Wallabie", Type = 0, PassengerCount = 1205 };
            cruiseShips.Add(wallabie);
            CruiseShip maria = new CruiseShip() { ShipId = 2, Name = "S/V Maria", Type = 0, PassengerCount = 1400 };
            cruiseShips.Add(maria);
            CruiseShip kingOfTheSeas = new CruiseShip() { ShipId = 3, Name = "M/S King of the Seas", PassengerCount = 4970, Type = 1 };
            cruiseShips.Add(kingOfTheSeas);
            Tanker oilSpiller = new Tanker() { ShipId = 4, Name = "M/S OilSpiller", Tonnage = 45000, Type = 2 };
            cruiseShips.Add(oilSpiller);
            oilSpiller.AddCargo("Bananas", cargoManifest);

            GetSmallShips(cruiseShips);
            GetLargeShips(cruiseShips);
            GetTankers(cruiseShips);

        }

        public static void GetLargeShips(List<IShip> list)
        {
            var bigCruisers = list.Where(ship => ship.Type == (byte)ShipType.LargeCruiser);
            Console.WriteLine("\nBig Cruisers in your fleet: ");
            foreach (CruiseShip ship in bigCruisers)
            {
                Console.WriteLine($"{ship.Name} has {ship.PassengerCount} passengers on board.");
            }
        }
        public static void GetSmallShips(List<IShip> list)
        {

            var smallCruisers = list.Where(ship => ship.Type == (byte)ShipType.SmallCruiser);

            Console.WriteLine("\nSmall cruisers in your fleet: ");
            foreach (CruiseShip ship in smallCruisers)
            {
                Console.WriteLine($"{ship.Name} has {ship.PassengerCount} passengers on board.");
            }

        }
        public static void GetTankers(List<IShip> list)
        {

            var tankers = list.Where(ship => ship.Type == (byte)ShipType.Tanker);

            Console.WriteLine("\nTankers in your fleet: ");
            foreach (Tanker ship in tankers)
            {
                Console.WriteLine($"{ship.Name} has {ship.Tonnage} of tonnage.");
            }

        }
    }

    public interface IShip
    {
        int ShipId { get; set; }
        string Name { get; set; }
        byte Type { get; set; }
    }

    public class CruiseShip : IShip
    {
        public int ShipId { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
        public int PassengerCount { get; set; }
        public int Route { get; set; }
    }

    public class Tanker : IShip
    {
        public int ShipId { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
        public int Tonnage { get; set; }

        public List<string> AddCargo(string cargo, List<string> manifest)
        {
            manifest.Add(cargo);
            return manifest;
        }
    }
}
