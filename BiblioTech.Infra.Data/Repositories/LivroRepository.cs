

using BiblioTech.Domain.Entities;
using Dapper;
using Npgsql;

namespace BiblioTech.Infra.Data.Repositories {
    public class LivroRepository {

        private readonly string _connectionString = "Host=localhost;Port=5432;Database=bibliotechdb;Username=postgres;Password=123456";

        public void Inserir(Livro livro) {

            using (var connection = new NpgsqlConnection(_connectionString)) {

                var query = """
                        INSERT INTO livros(id, nome, editora, autor, quantidade, quantidade_paginas, ano_edicao, tipo_livro, genero_livro, status, data_hora_cadastro)
                        VALUES(@Id ,@Nome, @Editora, @Autor, @Quantidade, @QuantidadePaginas, @AnoEdicao, @TipoLivro, @GeneroLivro, @Status, @DataHoraCadastro)
                    """;


                connection.Execute(query, new {
                    livro.Id,
                    livro.Nome,
                    livro.Editora,
                    livro.Autor,
                    livro.Quantidade,
                    livro.QuantidadePaginas,
                    livro.AnoEdicao,
                    TipoLivro = livro.TipoLivro.ToString(),
                    GeneroLivro = livro.GeneroLivro.ToString(),
                    Status = livro.Status.ToString(),
                    livro.DataHoraCadastro
                });

            }
        }

        public void Atualizar(Livro livro) {

            using (var connection = new NpgsqlConnection(_connectionString)) {

                var query = """
                        UPDATE livros
                        SET nome = @Nome,
                            editora = @Editora,
                            autor = @Autor,
                            quantidade = @Quantidade,
                            quantidade_paginas = @QuantidadePaginas,
                            ano_edicao = @AnoEdicao,
                            tipo_livro = @TipoLivro,
                            genero_livro = @GeneroLivro,
                            status = @Status
                        WHERE id = @Id
                    """;

                connection.Execute(query, new {
                    livro.Id,
                    livro.Nome,
                    livro.Editora,
                    livro.Autor,
                    livro.Quantidade,
                    livro.QuantidadePaginas,
                    livro.AnoEdicao,
                    TipoLivro = livro.TipoLivro.ToString(),
                    GeneroLivro = livro.GeneroLivro.ToString(),
                    Status = livro.Status.ToString()
                });
            }
        }

        public List<Livro> ListarResumido() {

            using (var connection = new NpgsqlConnection(_connectionString)) {

                var query = """
                        SELECT id, nome, editora, autor, status
                        FROM livros
                    """;

                return connection.Query<Livro>(query).ToList();
            }
        }

        public Livro? ListarPorId(Guid id) {

            using (var connection = new NpgsqlConnection(_connectionString)) {

                var query = """
                        SELECT * FROM livros
                        WHERE id = @id
                    """;

                return connection.QueryFirstOrDefault<Livro>(query, new { id });
            }
        }

        public void Deletar(Guid id) {

            using (var connection = new NpgsqlConnection(_connectionString)) {

                var query = """
                        DELETE FROM livros
                        WHERE id = @id
                    """;

                connection.Execute(query, new { id });
            }
        }
    }
}
