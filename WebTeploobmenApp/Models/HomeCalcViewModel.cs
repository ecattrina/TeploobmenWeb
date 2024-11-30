namespace WebTeploobmenApp.Models
{
    public class HomeCalcViewModel
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
        public string OperationTypeName => OperationType switch
        {
            1 => "Изменение температуры материала",
            2 => "Измененеие температуры газа",
            3 => "Разность температур",
            4 => "Таблица",
            _ => ""
        };
        public double Result {  get; set; }

        public double Ploshadechen { get; set; }
        public double TeploemMaterial { get; set; }
        public double TeploemGas { get; set; }
        public double OtnoshTeploem { get; set; }
        public double PolnayaOtnositVisota { get; set; }

    }
}
