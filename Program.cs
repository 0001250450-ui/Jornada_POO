using System;

using System.Collections.Generic;

namespace JornadaPOO

{

    // ==========================================

    // 5. ABSTRAÇÃO

    // Classe base abstrata que define a essência

    // de um Veículo Terrestre.

    // ==========================================

    public abstract class VeiculoTerrestre

    {

        // Propriedades essenciais expostas

        public string Modelo { get; set; }

        public int CapacidadePassageiros { get; set; }

        public VeiculoTerrestre(string modelo, int capacidadePassageiros)

        {

            Modelo = modelo;

            CapacidadePassageiros = capacidadePassageiros;

        }

        // ==========================================

        // 3. POLIMORFISMO

        // Método abstrato/virtual que será implementado

        // de forma diferente por cada veículo derivado.

        // ==========================================

        public abstract void Mover();

        // Apresentação simplificada do veículo (Abstração)

        public virtual void ApresentarDestaques()

        {

            Console.WriteLine($"[Apresentação] Modelo: {Modelo} | Capacidade: {CapacidadePassageiros} passageiros.");

        }

    }

    // ==========================================

    // 1. CLASSE

    // ProjetoCarroJoão: A Classe mãe dos carros.

    // ==========================================

    public class CarroJoao : VeiculoTerrestre

    {

        // ==========================================

        // 4. ENCAPSULAMENTO

        // Atributos e detalhes internos ocultos do condutor.

        // ==========================================

        private bool _sistemaEletricoOk;

        private bool _motorLigado;

        private int _nivelCombustivel;

        public CarroJoao(string modelo, int capacidadePassageiros, int nivelCombustivel)

        : base(modelo, capacidadePassageiros)

        {

            _sistemaEletricoOk = true;

            _motorLigado = false;

            _nivelCombustivel = nivelCombustivel;

        }

        // Interface pública e simples para o condutor (Encapsulamento)

        public void LigarComBotaoPartida()

        {

            VerificarSistemaEletrico();

            if (_nivelCombustivel > 0)

            {

                _motorLigado = true;

                Console.WriteLine($"{Modelo}: Motor ligado com sucesso através do botão de partida!");

            }

            else

            {

                Console.WriteLine($"{Modelo}: Sem combustível suficiente para ligar.");

            }

        }

        // Método privado com complexidade interna oculta

        private void VerificarSistemaEletrico()

        {

            // Detalhes complexos do sistema elétrico

            _sistemaEletricoOk = true;

        }

        // Implementação do Polimorfismo

        public override void Mover()

        {

            if (_motorLigado)

            {

                Console.WriteLine($"{Modelo}: Desloca-se suavemente pela estrada a acelerar com o pedal.");

            }

            else

            {

                Console.WriteLine($"{Modelo}: Precisa ligar o carro antes de se mover.");

            }

        }

        // Abstração no evento de lançamento

        public override void ApresentarDestaques()

        {

            base.ApresentarDestaques();

            Console.WriteLine($" -> Destaque: Oferece incrível economia de combustível, espaço interno amplo e segurança de ponta!");

        }

    }

    // ==========================================

    // 2. HERANÇA

    // CarroJoaoSports herda de CarroJoao.

    // ==========================================

    public class CarroJoaoSports : CarroJoao

    {

        public bool ModoTurbo { get; set; }

        public CarroJoaoSports(string modelo, int nivelCombustivel)

        : base(modelo, 2, nivelCombustivel)

        {

            ModoTurbo = true;

        }

        public override void Mover()

        {

            Console.WriteLine($"{Modelo}: Acelera com alta performance e ronco desportivo no motor!");

        }

    }

    // CarroJoaoEco herda de CarroJoao

    public class CarroJoaoEco : CarroJoao

    {

        public int CargaBateriaPercentual { get; set; }

        public CarroJoaoEco(string modelo, int cargaBateria)

        : base(modelo, 5, 100) // Combustível "simulado" como bateria

        {

            CargaBateriaPercentual = cargaBateria;

        }

        public override void Mover()

        {

            Console.WriteLine($"{Modelo}: Desloca-se de forma silenciosa utilizando propulsão 100% elétrica.");

        }

    }

    // ==========================================

    // Outras Classes Derivadas (Polimorfismo)

    // ==========================================

    public class OnibusJoao : VeiculoTerrestre

    {

        public OnibusJoao(string modelo) : base(modelo, 45) { }

        public override void Mover()

        {

            Console.WriteLine($"{Modelo}: Transporta muitos passageiros fazendo paragens em rotas urbanas.");

        }

    }

    public class MotoJoao : VeiculoTerrestre

    {

        public MotoJoao(string modelo) : base(modelo, 2) { }

        public override void Mover()

        {

            Console.WriteLine($"{Modelo}: Desloca-se agilmente entre as vias e o trânsito.");

        }

    }

    // ==========================================

    // EXECUÇÃO DO PROGRAMA (A Jornada de João)

    // ==========================================

    class Program

    {

        static void Main(string[] args)

        {

            Console.WriteLine("=== A JORNADA DE JOÃO: ===\n");

            // ----------------------------------------------------

            // 1. CLASSE E OBJETO

            // 'CarroJoao' é a Classe (projeto), 'meuCarro' é o Objeto (instância física)

            // ----------------------------------------------------

            Console.WriteLine("--- 1. Criação do Primeiro Objeto ---");

            CarroJoao meuCarro = new CarroJoao("CarroJoão Original", 5, 50); // Instância/Objeto

            // 4. Encapsulamento em ação

            meuCarro.LigarComBotaoPartida();

            meuCarro.Mover();

            Console.WriteLine();

            // ----------------------------------------------------

            // 2. HERANÇA

            // ----------------------------------------------------

            Console.WriteLine("--- 2. Linha Extensível (Herança) ---");

            CarroJoaoSports carroEsportivo = new CarroJoaoSports("CarroJoão Sports", 80);

            CarroJoaoEco carroEletrico = new CarroJoaoEco("CarroJoão Eco", 95);

            carroEsportivo.LigarComBotaoPartida();

            carroEsportivo.Mover();

            carroEletrico.LigarComBotaoPartida();

            carroEletrico.Mover();

            Console.WriteLine();

            // ----------------------------------------------------

            // 3. POLIMORFISMO

            // Múltiplos veículos tratados uniformemente como VeiculoTerrestre,

            // mas cada um executa o método Mover() à sua maneira.

            // ----------------------------------------------------

            Console.WriteLine("--- 3. Frota Diversificada (Polimorfismo) ---");

            List<VeiculoTerrestre> frota = new List<VeiculoTerrestre>

 {

 meuCarro,

 carroEsportivo,

 carroEletrico,

 new OnibusJoao("ÔnibusJoão Urbano"),

 new MotoJoao("MotoJoão 250cc")

 };

            foreach (var veiculo in frota)

            {

                veiculo.Mover(); // Polimorfismo: cada objeto responde à sua maneira

            }

            Console.WriteLine();

            // ----------------------------------------------------

            // 5. ABSTRAÇÃO

            // Evento de lançamento focando no que é essencial para os clientes.

            // ----------------------------------------------------

            Console.WriteLine("--- 5. Evento de Lançamento (Abstração) ---");

            meuCarro.ApresentarDestaques();

        }

    }

}