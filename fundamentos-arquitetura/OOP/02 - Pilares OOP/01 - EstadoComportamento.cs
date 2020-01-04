using System;

namespace OOP
{
    public class Pessoa
    {
        //As propriedades indicam estado da classe
        public string Nome { get; set; } 
        public DateTime DataNascimento { get; set; }

        public int CalcularIdade() //Comportamento
        {
            //Comportamento pode modiicar o estado das propriedades
            var dataAtual = DateTime.Now;
            var idade = dataAtual.Year - DataNascimento.Year;

            if (dataAtual < DataNascimento.AddYears(idade)) idade--;

            return idade;
        }
    }
}