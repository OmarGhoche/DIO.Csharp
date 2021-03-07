using System;

namespace DIO.Series
{
    public class Serie: EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            return "Gênero: " + this.Genero + Environment.NewLine +
                   "Título: " + this.Titulo + Environment.NewLine +
                   "Descrição: " + this.Descricao + Environment.NewLine +
                   "Ano de Início: " + this.Ano + Environment.NewLine +
                   "Excluído: " + this.Excluido;
        }

        public int getId()
        {
            return this.Id;
        }

        public bool getExcluido()
        {
            return this.Excluido;
        }

        public string getTitulo()
        {
            return this.Titulo;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}