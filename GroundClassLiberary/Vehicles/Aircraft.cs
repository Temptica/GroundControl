using System;

namespace GroundClassLiberary.Vehicles
{
    public enum AircraftWeitghtCategory { None,Light, Medium, Heavy, Super }
    public abstract class Aircraft
    {
        public string Icao { get; private set; }
        public AircraftWeitghtCategory AircraftWeitghtCategory { get; private set; }
        public int MinSpeed { get; private set; }
        public int MaxSpeed { get; private set; }
        public int MaxHeight { get; set; }
        public int WingSpan { get; set; }
        public int Length { get; set; }
        public TakeOff AverageTakeOff { get; set; }
        public InitialClimb AverageInitialClimb { get; set; }
        public Climb AverageClimb { get; set; }
        public Descend AverageDescend { get; set; }
        public Landing AverageLanding { get; set; }

    }

    public class TakeOff
    {
        public int V1 { get; set; }
        public int VRotate { get; set; }
        public int V2 { get; set; }
        public int RequiredDistance { get; set; }
    }
    public class InitialClimb
    {
        public int Ias { get; set; }
        public int ClimbDescendRate { get; set; }
    }
    public class Climb
    {
        public int Ias { get; set; }
        public int ClimbDescendRate { get; set ; }
    }
    public class Descend
    {
        public int Ias { get; set; }
        public int ClimbDescendRate { get; set; }
    }
    public class Landing
    {
        public int VatSpeed { get; set; }
        public char APC { get; set; }
        public int Distance { get; set; }
    }

}
