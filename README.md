# INTEGRANTES DO GRUPO

Gabriel de Andrade Baltazar - RM550870
Vinícius de Araújo Camargo - RM99494


## JSON PARA TESTES 
{
  "categoria": "categoria deliciosa",
  "fabricante": "fábrica de sorvetes premium",
  "nome": "sorvete saboroso",
  "preco": 10000
}
## ESPECIFICAÇÕES PARA OS REALIZAR OS TESTES
As validações do modelo SorveteRequest são as seguintes:
- Nome do sorvete deve ter entre 10 e 50 caracteres.
- O preço do sorvete deve estar entre R$ 1,00 e R$ 10.000,00.
- Categoria do sorvete deve ter entre 10 e 50 caracteres.
- Nome do fabricante deve ter entre 10 e 50 caracteres.




### CP5 - 2TDS - ADVANCED BUSINESS DEVELOPMENT WITH .NET - 2024

Bem-vindo ao CP 5! Espero que este projeto lhe proporcione uma excelente experiência em desenvolvimento.

Se tiver dúvidas, por favor, não hesite em me contatar!

## Objetivo

Desenvolver uma WebAPI em .NET que realize um CRUD no MongoDB para uma entidade de sua escolha, aplicando boas práticas de arquitetura e implementação.

## Entrega

- Repositório GitHub da turma

## Instruções Básicas

  - A checkpoint poderá ser desenvolvido em dupla (2 pessoas).
  - Não se esqueça de adicionar no README do repositório, os RMs da dupla
  - O tema do trabalho será livre *Não pode ser o exemplo utilizado em aulas*
  - Se utilizar o **PROJETO** da sua turma sua nota será 0 (zero).
  - Se tivermos projetos iguais a nota das duplas que copiaram será 0 (zero).
  - O projeto deverá compilar, caso não compile sua nota será 0 (zero).
  - Se for usar IA, use da maneira certa. Não copie e cole o que ela mandar.

## Demonstração

### Passo a passo

1. **Clone o repositório**

   Baseado na sua turma, faça o clone do repositório:

   ```sh
   git clone https://github.com/<TURMA>-2024/CP5.git
   ```

   **Exemplo para a turma 2TDSPN:**

   ```sh
   git clone https://github.com/2TDSPN-2024/CP5.git
   ```

2. **Navegue até o diretório do projeto**

   ```sh
   cd CP5
   ```

3. **Crie uma nova branch**

   Crie uma nova branch com o seu RM (Registro de Matrícula):

   ```sh
   git checkout -b RM<12345>
   ```

4. **Abra a sua IDE e faça as alterações**

   Abra o projeto na sua IDE preferida e desenvolva o seu código.

5. **Adicione as alterações**

   Adicione todas as alterações que você fez ao staging:

   ```sh
   git add .
   ```

6. **Comite as alterações**

   Faça um commit das suas alterações com uma mensagem descritiva:

   ```sh
   git commit -m "Descrição das alterações"
   ```

7. **Envie a nova branch para o repositório remoto**

   Envie a sua branch para o repositório remoto:

   ```sh
   git push origin RM<12345>
   ```

## O que eu preciso fazer???

**Integração com MongoDB**
   
   - (2 pontos) Utilizar o MongoDB como banco de dados para armazenamento das informações. A conexão com o MongoDB deve ser feita de forma segura, utilizando variáveis de ambiente para armazenar a string de conexão. Documentar no README como configurar o banco de dados.

**Chamada Assíncrona**
   - (2 pontos) Implementar chamadas assíncronas (usando async/await) para a manipulação dos dados, garantindo que as operações sejam realizadas de forma eficiente e não bloqueiem a execução do servidor.

**Swagger para Documentação**
   - (2 ponto) Configurar e documentar a API utilizando o Swagger, garantindo que todos os endpoints estejam devidamente descritos, incluindo os métodos, parâmetros de entrada e respostas possíveis. A documentação deve ser clara e completa, permitindo que qualquer desenvolvedor consiga entender como utilizar a API apenas consultando o Swagger. Além disso, configurar exemplos de requisição e resposta para facilitar o entendimento.

**HealthCheck**

  - (1 ponto) Implementar um HealthCheck para monitoramento da saúde da aplicação, incluindo a verificação da conexão com o MongoDB e o status do servidor. Adicionar um endpoint específico para o HealthCheck que possa ser consultado por ferramentas de monitoramento.

**Testes Unitários**
   - (2 pontos) Implementar testes unitários utilizando xUnit. Os testes devem cobrir as funcionalidades principais dos endpoints.

**Validação de Dados**

 - (1 ponto) Implementar validações de dados nos endpoints, garantindo que os dados recebidos estejam corretos antes de serem processados. Utilizar atributos de validação no modelo ou implementar validações personalizadas. Fornecer mensagens de erro apropriadas para ajudar o usuário da API a corrigir os dados de entrada.

## Dicas
- Utilize boas práticas de desenvolvimento, como a divisão em camadas (Controllers, Services, Repositories).

- Não se esqueça de adicionar uma descrição clara no README do repositório, explicando como rodar o projeto e quais são as funcionalidades implementadas.

- Utilize variáveis de ambiente para configurações sensíveis, como strings de conexão e chaves de API.

- Crie exemplos de uso no README para facilitar o entendimento do funcionamento da API.

- Mantenha o código limpo e organizado, seguindo padrões de nomenclatura e estruturação.

**Bons Estudos e Boa Codificação!**  

## Autores

- [@ProfThiagoVicco](https://github.com/ProfThiagoVicco)


## Propósito
“Faça o teu melhor, na condição que você tem, enquanto você não tem condições 
melhores, para fazer melhor ainda”
Mario Sergio Cortela
