using ContatosApp.Domain.Entities;
using ContatosApp.Domain.Interfaces.Services;
using ContatosApp.Domain.Services;
using ContatosApp.Presentation.Models.Contatos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ContatosApp.Presentation.Controllers
{
    public class ContatosController : Controller
    {
        private IContatoDomainService _contatoDomainService;

        public ContatosController(IContatoDomainService contatoDomainService)
        {
            _contatoDomainService = contatoDomainService;
        }

        public IActionResult Cadastro()
        {
            var model = new ContatosCadastroViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(ContatosCadastroViewModel model)
        {
            //verificar se não há erros de validação
            if (ModelState.IsValid)
            {
                try
                {
                    var contato = new Contato
                    {
                        Nome = model.Nome,
                        Email= model.Email,
                        Telefone= model.Telefone
                    };

                   _contatoDomainService.Cadastrar(contato);

                   model = new ContatosCadastroViewModel();
                   ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }
            return View(model);
        }


        public IActionResult Edicao(Guid id)
        {
            var model = new ContatosEdicaoViewModel();

            try
            {
                //consultar a movimentação através do ID
                var contato = _contatoDomainService?.GetById(id);

                //passar os dados da movimentação para a model
                model.Id = contato.Id.Value;
                model.Nome = contato.Nome;
                model.Email = contato.Email;
                model.Telefone = contato.Telefone;
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edicao(ContatosEdicaoViewModel model)
        {
            //verificar se não há erros de validação
            if (ModelState.IsValid)
            {
                try
                {
                    var contato = new Contato
                    {
                        Id = model.Id, 
                        Nome = model.Nome,
                        Email = model.Email,
                        Telefone = model.Telefone
                    };

                    //gravar a movimentação
                    _contatoDomainService?.Atualizar(contato);

                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso.";

                    return RedirectToAction("Consulta");
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }

            return View(model);
        }


        public IActionResult Consulta()
        {
            var model = new ContatosConsultaViewModel();

            try
            {
                model.ListagemContatos = _contatoDomainService?.GetAll();
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Consulta(ContatosConsultaViewModel model)
        {
            try
            {
                model.ListagemContatos = _contatoDomainService?.GetAll();
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            //retornando a model
            return View(model);
        }

        public IActionResult Exclusao(Guid id)
        {
            try
            {
                //realizando a exclusão do registro
                _contatoDomainService?.Excluir(id);
                TempData["MensagemSucesso"] = "Contato excluído com sucesso.";
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            //redirecionar de volta para a página de consulta
            return RedirectToAction("Consulta");
        }



    }
}
