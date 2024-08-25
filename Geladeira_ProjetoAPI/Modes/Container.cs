namespace Geladeira_ProjetoAPI.Modes
{
    public class Container
    {
        public List<Posicao> Posicoes { get; private set; }
        public bool EstaVazio => Posicoes.All(p => p.EstaVazia);
        public bool EstaCheio => Posicoes.All(p => !p.EstaVazia);

        public Container()
        {
            Posicoes = new List<Posicao>
            {
                new Posicao(), new Posicao(), new Posicao(), new Posicao()
            };
        }

        public void AdicionarItem(int posicaoIndex, string item)
        {
            if (posicaoIndex < 0 || posicaoIndex >= Posicoes.Count)
            {
                throw new System.ArgumentException("Posição inválida.");
            }

            if (Posicoes[posicaoIndex].EstaVazia)
            {
                Posicoes[posicaoIndex].Item = item;
            }
            else
            {
                throw new System.InvalidOperationException("Posição já ocupada.");
            }
        }

        public void RemoverItem(int posicaoIndex)
        {
            if (posicaoIndex < 0 || posicaoIndex >= Posicoes.Count)
            {
                throw new System.ArgumentException("Posição inválida.");
            }

            if (!Posicoes[posicaoIndex].EstaVazia)
            {
                Posicoes[posicaoIndex].Item = null;
            }
            else
            {
                throw new System.InvalidOperationException("Posição já está vazia.");
            }
        }

        public void RemoverTodosItens()
        {
            if (EstaVazio)
            {
                throw new System.InvalidOperationException("Container já está vazio.");
            }

            foreach (var posicao in Posicoes)
            {
                posicao.Item = null;
            }
        }

        public void AdicionarItemEmContainer(int posicaoIndex, string item)
        {
            if (EstaCheio)
            {
                throw new System.InvalidOperationException("Container já está cheio.");
            }

            AdicionarItem(posicaoIndex, item);
        }
    }
}