using System;


namespace GestaoEquipamentos.ConsoleApp.Dominio
{
    public class Solicitante
    {
        public int id;
        public string nomeSoli;
        public string email;
        public string numeroTelefone;


        public Solicitante()
        {
            id = GeradorId.GerarIdSolicitante();
        }

        public Solicitante(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nomeSoli))
                resultadoValidacao += "O campo Nome é obrigatório \n";

            if (nomeSoli.Length < 6)
                resultadoValidacao += "O campo Nome não pode ter menos de 6 letras \n";

            if (string.IsNullOrEmpty(email))
                resultadoValidacao += "O campo email é obrigatório \n";

            if (string.IsNullOrEmpty(numeroTelefone))
                resultadoValidacao += "O campo Numero de Telefone é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "EQUIPAMENTO_VALIDO";

            return resultadoValidacao;
        }
        public override bool Equals(object obj)
        {
            Solicitante solicitante = (Solicitante)obj;

            if (id == solicitante.id)
                return true;
            else
                return false;
        }
    }
}


