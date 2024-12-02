using System.ComponentModel.DataAnnotations;

namespace WebTeploobmenApp.Data
{
    public class InputData
    {
        [Key]

        public int Id { get; set; }

        public double Visotasloy { get; set; }

        public double Nachtempgas { get; set; }

        public double Nachtempmaterial { get; set; }

        public double Skorostgas { get; set; }

        public double Sredtemplogas { get; set; }

        public double Rashodmaterial { get; set; }

        public double Teploemmaterial { get; set; }

        public double Kofteplo { get; set; }

        public double Diametrapparata { get; set; }

        public double Ycoordinate { get; set; }

        public int OperationType { get; set; }


    }
}
