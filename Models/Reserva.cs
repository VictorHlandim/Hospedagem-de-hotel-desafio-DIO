namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool capacity = Suite.Capacidade >= hospedes.Count ? true : false;
            if (capacity)
                Hospedes = hospedes;
            else
                throw new Exception("A capacidade da suite está sendo sobrecarregada");
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            int quantidade = Hospedes.Count;
            return quantidade;
        }
        private decimal Porcentagem(decimal vTotal, decimal Porcentagem)
        {
            return (vTotal * Porcentagem) / 100;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            valor = DiasReservados >= 10 ? valor - Porcentagem(valor, 10) : valor;

            return valor;
        }
    }
}