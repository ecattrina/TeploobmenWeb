namespace WebTeploobmenApp.Models
{
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

        public double Ycoordinate { get; set; }

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

        public double CalculateY() =>
            (Visotasloy * Ycoordinate) / (Skorostgas * Sredtemplogas * 1000);

        public double Exp1() =>
        1 - Math.Exp(((OtnoshTeploem() - 1) * CalculateY()) / OtnoshTeploem());

        public double Mexp1() =>
       (1 - OtnoshTeploem() * Math.Exp(((OtnoshTeploem() - 1) * CalculateY()) / OtnoshTeploem()));





        //         teploempotmaterial, teploempotgas, otnoshteploem, polnayaontositvisota;

        //     ploshadechen = Math.PI* Math.Pow(model.Diametrapparata, 2) / 4;
        //teploempotmaterial = model.Rashodmaterial* model.Teploemmaterial;
        //     teploempotgas = ploshadechen* model.Skorostgas * model.Sredtemplogas;
        //     otnoshteploem = teploempotmaterial / teploempotgas;
        //polnayaontositvisota = (model.Visotasloy* model.Kofteplo) / (model.Skorostgas* model.Sredtemplogas* 1000);


    }


}
