namespace ATM.Classes.Interfaces
{
    public interface IAirSpace
    {
        Vector3D Coordinate1 { get; set; }
        Vector3D Coordinate2 { get; set; }

        Vector3D Center();
        bool CheckAirSpace(int x, int y, int z);
        bool CheckAirSpace(Vector3D track);
    }
}