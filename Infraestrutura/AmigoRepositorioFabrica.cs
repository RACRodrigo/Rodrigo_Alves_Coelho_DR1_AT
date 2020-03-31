using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestrutura
{
    public class AmigoRepositorioFabrica
    {
        public static IAmigoRepositorio Criar()
        {
            return Criar(TipoRepositorio.LinkedList);
        }

        public static IAmigoRepositorio Criar(TipoRepositorio tipoRepositorio)
        {
            switch (tipoRepositorio)
            {
                case TipoRepositorio.List:
                    return new List.AmigoRepositorio();
                case TipoRepositorio.LinkedList:
                    return new LinkedList.AmigoRepositorio();
                default:
                    throw new NotImplementedException("Não existe implementação padrão!");
            }
        }
    }
}