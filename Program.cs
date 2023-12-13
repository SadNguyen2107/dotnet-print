namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                // Get GeometryType
                Geometry.GeometryType geometryType = Geometry.GetGeometryType();

                // Handle Event Input
                Geometry.HandleGeometryType(geometryType);
            }
        }
    }
}