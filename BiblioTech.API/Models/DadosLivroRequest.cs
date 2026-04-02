using BiblioTech.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BiblioTech.API.Models {
    public class DadosLivroRequest {

        [MinLength(3, ErrorMessage = "Por favor, informe um nome com pelo menos 3 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do livro.")]
        public string Nome { get; set; }

        [MinLength(3, ErrorMessage = "Por favor, informe uma editora com pelo menos 3 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a editora do livro.")]
        public string Editora { get; set; }

        [MinLength(3, ErrorMessage = "Por favor, informe um autor com pelo menos 3 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o autor do livro.")]
        public string Autor { get; set; }

        [Range(1, 100, ErrorMessage = "A quantidade deve ser no mínimo 1 e no máximo 100.")]
        [Required(ErrorMessage = "Por favor, informe a quantidade em estoque do livro.")]
        public int Quantidade { get; set; }

        [Range(30, int.MaxValue, ErrorMessage = "A quantidade de páginas deve ser no mínimo 30.")]
        [Required(ErrorMessage = "Por favor, informe a quantidade de páginas do livro.")]
        public int QuantidadePaginas { get; set; }

        [Range (1700, 2027, ErrorMessage = "O ano deve estar entre 1700 e 2027.")]
        [Required(ErrorMessage = "Por favor, informe o ano de edição do livro.")]
        public int AnoEdicao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o tipo do livro.")]
        public TipoLivro TipoLivro { get; set; }

        [Required(ErrorMessage = "Por favor, informe o gênero do livro.")]
        public GeneroLivro GeneroLivro { get; set; }

        [Required(ErrorMessage = "Por favor, informe o status do livro.")]
        public Status Status { get; set; }


    }
}
