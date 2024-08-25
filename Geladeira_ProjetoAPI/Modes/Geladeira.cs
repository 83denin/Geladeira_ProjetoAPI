using System;
using System.Collections.Generic;
using System.Text;

namespace Geladeira_ProjetoAPI.Modes
{
    public class Geladeira
    {
        public List<Andar> Andares { get; private set; }

        public Geladeira()
        {
            Andares = new List<Andar>
            {
                new Andar(), new Andar(), new Andar()
            };
        }

        public string ObterItens()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < Andares.Count; i++)
            {
                sb.AppendLine($"Andar {i}:");

                for (int j = 0; j < Andares[i].Containers.Count; j++)
                {
                    sb.AppendLine($"  Container {j}:");

                    for (int k = 0; k < Andares[i].Containers[j].Posicoes.Count; k++)
                    {
                        var posicao = Andares[i].Containers[j].Posicoes[k];
                        var item = posicao.EstaVazia ? "Vazio" : posicao.Item;
                        sb.AppendLine($"    Posição {k}: {item}");
                    }
                }
            }

            return sb.ToString();
        }
    }
}