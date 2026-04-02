

using BiblioTech.Domain.Enums;

namespace BiblioTech.Domain.Entities {
    public class Livro {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; } = string.Empty;

        public string Editora { get; set; } = string.Empty;

        public string Autor { get; set; } = string.Empty;

        public int Quantidade { get; set; }

        public int QuantidadePaginas { get; set; }

        public int AnoEdicao { get; set; }

        public TipoLivro TipoLivro { get; set; }

        public GeneroLivro GeneroLivro { get; set; }

        public Status Status { get; set; }

        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;

    }
}
