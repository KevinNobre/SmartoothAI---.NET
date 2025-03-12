# Smartooth AI

Projeto desenvolvido por alunos do segundo ano de Análise e Desenvolvimento de Sistemas, atendendo às solicitações feitas pela OdontoPrev durante o Challenge 2024/2 da FIAP.

JULIANA MOREIRA DA SILVA – RM: 554113

KEVIN CHRISTIAN NOBRE – RM: 552590

SABRINA COUTO XAVIER – RM: 552728


## Definição do Projeto

### Objetivo do Projeto
O SmarTooth AI é um sistema inteligente voltado para otimizar serviços odontológicos, integrando inteligência
artificial (AI) e Machine Learning (ML) para proporcionar uma experiência personalizada e eficiente aos
usuários.
Nosso sistema oferece um filtro intuitivo de procedimentos odontológicos, destacando em quais planos de
saúde cada serviço está incluído, com explicações claras e acessíveis sobre os tratamentos disponíveis.
Além disso, o Smartooth AI conta com um indicador de Dicas que, utilizando machine learning, sugere
orientações de saúde bucal personalizadas com base no histórico de consultas e prontuários dos pacientes. O
sistema também inclui um programa de recompensas, onde os usuários acumulam pontos ao manter suas
consultas regulares e praticar hábitos de saúde bucal, registrados em seu formulário. Esses pontos podem ser
trocados por descontos em tratamentos dentários, proporcionando uma vantagem exclusiva aos pacientes.
Outro diferencial do nosso sistema são as recomendações personalizadas em tempo real, que auxiliam o
usuário com sugestões de cuidados e procedimentos específicos de acordo com o seu perfil e histórico
clínico.

Nosso objetivo é simples: reduzir sinistros nos planos odontológicos e melhorar a saúde bucal dos usuários,
oferecendo orientações e incentivos baseados em dados reais e comportamentos saudáveis. O nome
“Smartooth” reflete bem a ideia por trás do projeto, combinando “smart” (inteligente) com “tooth” (dente),
representando nossa proposta de unir tecnologia e odontologia em uma solução inovadora.

### Arquitetura do Sistema
O Smartooth AI foi desenvolvido utilizando uma arquitetura monolítica, onde toda a lógica da aplicação reside em um único código-base. Essa abordagem foi escolhida considerando os seguintes fatores:
- Simplicidade no desenvolvimento e manutenção: Permite uma implementação mais ágil e centralizada, facilitando correções e melhorias contínuas.
- Menor complexidade operacional: Não há necessidade de gerenciar múltiplos serviços independentes, reduzindo a sobrecarga de infraestrutura e comunicação entre microsserviços.
- Facilidade na integração com o banco de dados Oracle: Garante um fluxo de dados eficiente sem a necessidade de camadas adicionais para comunicação.
- Escalabilidade planejada: Apesar da abordagem monolítica inicial, o sistema foi estruturado de forma modular, permitindo futuras transições para uma arquitetura baseada em microsserviços, se necessário.

A API do Smartooth AI foi projetada seguindo boas práticas de desenvolvimento, utilizando princípios SOLID e garantindo modularidade nas funcionalidades para facilitar futuras expansões.

### Escopo
O projeto abrange o desenvolvimento de um sistema que:
- Realiza o gerenciamento de usuários pacientes, incluindo registro e autenticação.
- Fornece funcionalidades de CRUD (Create, Read, Update, Delete) para gerenciar os dados dos usuários pacientes.
- Implementa a lógica de negócios necessária para validações e operações específicas, como a validação de e-mail e cálculo de idade.
- Estabelece uma estrutura de repositório para o acesso e manipulação de dados no banco de dados.
- Utiliza mapeamento de entidades para garantir que as operações do banco de dados sejam realizadas de maneira eficaz.

### Requisitos Funcionais
- O sistema deve permitir o registro de novos usuários pacientes com informações básicas.
- Os usuários devem poder visualizar, editar e deletar seus dados.
- O sistema deve validar o e-mail dos usuários antes de permitir o registro.
- O cálculo da idade deve ser realizado com base na data de nascimento informada.

### Requisitos Não Funcionais
- O sistema deve ser seguro, garantindo que as informações dos usuários estejam protegidas.
- A aplicação deve ser escalável para suportar um número crescente de usuários.
- O tempo de resposta para operações de CRUD deve ser minimizado para garantir uma boa experiência do usuário.
- O sistema deve ser desenvolvido seguindo boas práticas de programação e design de software, utilizando princípios de SOLID.

## Tecnologias Utilizadas
- .NET 8.0
- Entity Framework Core
- Oracle SQL Developer Server
- C#
- ASP.NET Core
- Swagger/OpenAPI para documentação da API

## Configuração do Banco de Dados:
Certifique-se de que o SQL Developer esteja instalado e configurado.
Atualize a string de conexão no arquivo appsettings.json para o seu banco de dados.

## Como Rodar o Projeto

### Pré-requisitos
Antes de iniciar, certifique-se de ter os seguintes requisitos instalados:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Developer Server (Oracle)](https://www.oracle.com/database/sqldeveloper/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (ou outro IDE compatível)
- [Git](https://git-scm.com/)

### Passo a passo para execução

1. **Clone o repositório**
   ```sh
   git clone [https://github.com/KevinNobre/SmartoothAI---.NET]


      
