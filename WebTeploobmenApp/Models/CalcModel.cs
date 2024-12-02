//namespace WebTeploobmenApp.Models
//{
//    public class CalcModel
//    {
//        public double Visotasloy { get; set; }

//        public double Nachtempgas { get; set; }

//        public double Nachtempmaterial { get; set; }

//        public double Skorostgas { get; set; }

//        public double Sredtemplogas { get; set; }

//        public double Rashodmaterial { get; set; }

//        public double Teploemmaterial { get; set; }

//        public double Kofteplo { get; set; }

//        public double Diametrapparata { get; set; }

//        public double Ycoordinate { get; set; }

//        public int OperationType { get; set; }


//        public double Ploshadechen() =>
//            Math.PI * Math.Pow(Diametrapparata, 2) / 4;

//        public double TeploemMaterial() =>
//            Rashodmaterial * Teploemmaterial;

//        public double TeploemGas() =>
//            Ploshadechen() * Skorostgas * Sredtemplogas;

//        public double OtnoshTeploem() =>
//            TeploemMaterial() / TeploemGas();

//        public double PolnayaOtnositVisota() =>
//            (Visotasloy * Kofteplo) / (Skorostgas * Sredtemplogas * 1000);

//        public double CalculateY() =>
//            ( Kofteplo * Ycoordinate) / (Skorostgas * Sredtemplogas * 1000);

//        public double Exp1() =>
//        1 - Math.Exp(((OtnoshTeploem() - 1) * CalculateY()) / OtnoshTeploem());

//        public double Mexp1() =>
//       (1 - OtnoshTeploem() * Math.Exp(((OtnoshTeploem() - 1) * CalculateY()) / OtnoshTeploem()));

//        public double upsilon() =>
//            Exp1() / (1 - OtnoshTeploem() * Math.Exp(((OtnoshTeploem() - 1) * (Kofteplo * Visotasloy) / (Skorostgas * Sredtemplogas * 1000)) / OtnoshTeploem()));
//        public double theta() => Mexp1() / (1 - OtnoshTeploem() * Math.Exp(((OtnoshTeploem() - 1) * (Kofteplo * Visotasloy) / (Skorostgas * Sredtemplogas * 1000)) / OtnoshTeploem()));
//        public double t() => Nachtempmaterial + (Nachtempgas-Nachtempmaterial)*upsilon();

//        public double T() => Nachtempmaterial + (Nachtempgas - Nachtempmaterial) * theta();




//    }


//}
namespace WebTeploobmenApp.Models
{
    public class CalculationResult
    {
        public double Ycoordinate { get; set; }
        public double TemperatureMaterial { get; set; }
        public double TemperatureGas { get; set; }
        public double TemperatureDifference { get; set; }
    }

    public class CalcModel
    {
        public double Visotasloy { get; set; }
        public double Nachtempgas { get; set; }
        public double Nachtempmaterial { get; set; }
        public double Skorostgas { get; set; }
        public double Sredtemplogas { get; set; }
        public double Rashodmaterial { get; set; }
        public double Teploemmaterial { get; set; }
        public double Kofteplo { get; set; }
        public double Diametrapparata { get; set; }
        public int OperationType { get; set; }

        public double Ploshadechen() =>
            Math.PI * Math.Pow(Diametrapparata, 2) / 4;

        public double TeploemMaterial() =>
            Rashodmaterial * Teploemmaterial;

        public double TeploemGas() =>
            Ploshadechen() * Skorostgas * Sredtemplogas;

        public double OtnoshTeploem() =>
            TeploemMaterial() / TeploemGas();

        public double PolnayaOtnositVisota() =>
            (Visotasloy * Kofteplo) / (Skorostgas * Sredtemplogas * 1000);

        private double CalculateY(double y) =>
            (Kofteplo * y) / (Skorostgas * Sredtemplogas * 1000);

        private double Exp1(double y) =>
            1 - Math.Exp(((OtnoshTeploem() - 1) * CalculateY(y)) / OtnoshTeploem());

        private double Mexp1(double y) =>
            1 - OtnoshTeploem() * Math.Exp(((OtnoshTeploem() - 1) * CalculateY(y)) / OtnoshTeploem());

        public List<CalculationResult> CalculateResults()
        {
            var results = new List<CalculationResult>();
            for (double y = 0; y <= Visotasloy; y += 0.5)
            {
                var upsilon = Exp1(y) / (1 - OtnoshTeploem() * Math.Exp(((OtnoshTeploem() - 1) * (Kofteplo * Visotasloy) / (Skorostgas * Sredtemplogas * 1000)) / OtnoshTeploem())); ;
                var theta = Mexp1(y) / (1 - OtnoshTeploem() * Math.Exp(((OtnoshTeploem() - 1) * (Kofteplo * Visotasloy) / (Skorostgas * Sredtemplogas * 1000)) / OtnoshTeploem())); ;
                var t = Nachtempmaterial + (Nachtempgas - Nachtempmaterial) * upsilon;
                var T = Nachtempmaterial + (Nachtempgas - Nachtempmaterial) * theta;

                results.Add(new CalculationResult
                {
                    Ycoordinate = y,
                    TemperatureMaterial = Math.Round(t),
                    TemperatureGas = Math.Round(T),
                    TemperatureDifference = Math.Round(t - T)
                });
            }
            return results;
        }
    }
}
