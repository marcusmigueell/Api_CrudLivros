using Api.Net_Core.Negocio;
using System.Collections.Generic;

namespace Api.Net_Core.Repositorio {

    interface ILivroRepositorio {

        ListaDeLeitura ParaLer { get; }
        ListaDeLeitura Lendo { get; }
        ListaDeLeitura Lidos { get; }
        IEnumerable<Livro> Todos { get; }
        void Incluir(Livro livro);
    }
}
