namespace CarDealership.Infrastructure.DataAccess.Entities
{
    /// <summary>
    /// Clase que aplica principios solid:
    /// - De responsabilidad única
    /// - Abierto/Cerrado
    /// </summary>
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
