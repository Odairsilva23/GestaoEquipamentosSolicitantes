using GestaoEquipamentos.ConsoleApp.Dominio;
using System;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    class ControladorSolicitante : ControladorBase
    {
        
        public string RegistrarSolicitante(int id, string nome, string email, string numeroTelefone)
        {
            Solicitante solicitante = null;

            int posicao;

            if (id == 0)
            {
                solicitante = new Solicitante();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Equipamento(id));
                posicao = ObterPosicaoOcupada(new Chamado(id));
                solicitante = (Solicitante)registros[posicao];
            }

            solicitante.nomeSoli = nome;
            solicitante.email = email;
            solicitante.numeroTelefone = numeroTelefone;

            string resultadoValidacao = solicitante.Validar();

            if (resultadoValidacao == "CHAMADO_VALIDO")
                registros[posicao] = solicitante;

            return resultadoValidacao;
        }

        public Solicitante SelecionarSolicitantePorId(int idSolicitante)
        {
            return (Solicitante)SelecionarRegistroPorId(new Solicitante(idSolicitante));
        }

        public bool ExcluirSolicitante(int idSelecionado)
        {
            return ExcluirRegistro(new Solicitante(idSelecionado));
        }

        public Solicitante[] SelecionarTodosSolicitantes()
        {
            Solicitante[] SolicitantesAux = new Solicitante[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), SolicitantesAux, SolicitantesAux.Length);

            return SolicitantesAux;
        }
    }
}
