using System;

namespace Framework
{
    public static class Tools
    {
        public static string resolveMoeda(string valor)
        {
            decimal preco;

            if (decimal.TryParse(valor.Replace("R$ ", ""), out preco))
            {
                valor = String.Format("R$ {0:0.00}", preco);

            }
            else
            {
                valor = "R$ 0.00";
            }

            return valor;
        }
    }
}
