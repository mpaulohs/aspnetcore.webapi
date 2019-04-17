using System;

namespace dwa.domain.AggregatesModel.OrdemAggregate
{
    public class Endereco // ValueObject
    {
        public String Rua { get; private set; }
        public String Cidade { get; private set; }
        public String Estado { get; private set; }
        public String Pais { get; private set; }
        public String Cep { get; private set; }
        private Endereco() { }

        public Endereco(string rua, string cidade, string estado, string pais, string cep)
        {
            Rua = rua;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Cep = cep;
        }
    }
}
