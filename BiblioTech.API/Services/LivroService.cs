using BiblioTech.API.Models;
using BiblioTech.Domain.Entities;
using BiblioTech.Infra.Data.Repositories;

namespace BiblioTech.API.Services {
    public class LivroService {

        private readonly LivroRepository _livroRepository;

        public LivroService(LivroRepository livroRepository) {
            _livroRepository = livroRepository;
        }

        public void CriarLivro(DadosLivroRequest request) {

            var livro = new Livro {

                Nome = request.Nome,
                Editora = request.Editora,
                Autor = request.Autor,
                Quantidade = request.Quantidade,
                QuantidadePaginas = request.QuantidadePaginas,
                AnoEdicao = request.AnoEdicao,
                TipoLivro = request.TipoLivro,
                GeneroLivro = request.GeneroLivro,
                Status = request.Status,
            };

            _livroRepository.Inserir(livro);
        }

        public void AtualizarLivro(Guid id, DadosLivroRequest request) {

            var livro = new Livro {

                Id = id,
                Nome = request.Nome,
                Editora = request.Editora,
                Autor = request.Autor,
                Quantidade = request.Quantidade,
                QuantidadePaginas = request.QuantidadePaginas,
                AnoEdicao = request.AnoEdicao,
                TipoLivro = request.TipoLivro,
                GeneroLivro = request.GeneroLivro,
                Status = request.Status,
            };

            _livroRepository.Atualizar(livro);
        }

        public List<Livro> ListarResumido() {

            return _livroRepository.ListarResumido();

        }

        public Livro? ListarPorId(Guid id) {

            return _livroRepository.ListarPorId(id);
        }

        public void Deletar(Guid id) {

            _livroRepository.Deletar(id);
        }
    }
}

