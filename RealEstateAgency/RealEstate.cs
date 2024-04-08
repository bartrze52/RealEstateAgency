using System;

namespace RealEstateAgency
{
    [Serializable]
    public class RealEstate
    {
        public int Id { get; set; }
        public string Osiedle { get; set; }
        public string Adres { get; set; }
        public bool HasGarage { get; set; }
        public string Type { get; set; }
        public int Area { get; set; }
        public bool Availability { get; set; }
        public string Description { get; set; }
    }
}