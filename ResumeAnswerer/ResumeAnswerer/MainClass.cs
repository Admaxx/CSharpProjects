namespace ResumeAnswerer
{
    public class MainClass
    {
        public string messageToOtherCandidates(string role)
        {
            return "Dzień dobry,\r\n\r\n" +
                $"dziękujemy za zainteresowanie ofertą firmy Company na stanowisko: {role}." +
                $"\r\n\r\nPo przeanalizowaniu nadesłanych dokumentów aplikacyjnych informujemy, " +
                $"że aktualnie nie możemy zaproponować dalszego udziału w procesie rekrutacji." +
                $"\r\n\r\nZapraszamy do śledzenia aktualnych ofert na naszej stronie " +
                $"www.kariera.company.pl oraz zachęcamy do aplikowania w przyszłości.\r\n\r\n" +
                $"Na żadne pytania dotyczące obecnej rekrutacji nie odpowiemy, ponieważ" +
                $"3/4 nadesłanych CV wrzuciliśmy do domowej czarnej dziury, a reszta " +
                $"służy jako podpałka do grilla dyrektora generalnego." +
                $"Z poważaniem,\r\n" +
                $"Hiper super duper quality rekruting Team\r\n\r\n" +
                $"Kazimierz Przerwa-Tetmajer\r\n" +
                $"<IsPies.png/>";
        }
    }
}