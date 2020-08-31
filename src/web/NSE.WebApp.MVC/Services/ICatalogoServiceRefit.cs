using System;
using Refit;
using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NSE.WebApp.MVC.Services
{
    public interface ICatalogoServiceRefit
    {
        [Get("/catalogo/produtos/")]
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();

        [Get("/catalogo/produtos/{id}")]
        Task<ProdutoViewModel> ObterPorId(Guid id);
    }
}
