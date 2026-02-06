## **Padrões de Projetos de Software**

## **Padrões Criacionais**
- **Abstract Factory:** 
  - Fornece uma **interface** para criar uma **família de objetos relacionados**, sem depender das classes concretas.
  - **Usar quando:** precisa trocar famílias inteiras de objetos (ex.: trocar banco, UI, relatórios) sem alterar o código cliente.
  - **Não usar quando:** só existe um objeto simples para criar ou não há variação de famílias.

- **Factory Method:** 
  - Define um método de criação em uma **superclasse/interface**, deixando as **subclasses decidirem** qual classe concreta instanciar.
  - **Usar quando:** o tipo do objeto varia conforme o contexto e você quer evitar if/switch espalhado.
  - **Não usar quando:** o tipo do objeto é fixo e não muda.
  
- **Singleton:** 
  - Garante que uma classe tenha **apenas uma única instância** e fornece um **ponto global de acesso**.
  - **Usar quando:** o estado precisa ser único e compartilhado (configuração, cache, logger).
  - **Não usar quando:** há necessidade de múltiplas instâncias, testes isolados ou injeção de dependência (Singleton vira acoplamento).
  
- **Builder:** 
  - Separa a construção de um objeto complexo em **passos**, permitindo várias combinações sem explosão de construtores.
  - **Usar quando:** o objeto tem muitos parâmetros opcionais ou múltiplas formas de montagem.
  - **Não usar quando:** o objeto é simples e pode ser criado com um construtor direto.
  
- **Prototype:** 
  - Cria novos objetos a partir da **clonagem de um protótipo existente**.
  - **Usar quando:** criar o objeto do zero é caro ou quando muitas instâncias são variações de um mesmo padrão.
  - **Não usar quando:** o objeto é simples ou a clonagem profunda é complexa e propensa a erro.

---

## Pré-requisitos

1. Instalar a versão LTS do [.NET SDK](https://dotnet.microsoft.com/download).
2. Visual Studio 2022 ou superior (ou VS Code com extensão C#).
3. SQL Server LocalDB ou SQLite (dependendo do exemplo que deseja executar).

---

## Executando os exemplos

- Abra a solução `SoftwarePatterns.sln`.
- Configure o projeto correspondente como projeto de inicialização.
- Execute (`F5` ou `Ctrl+F5`).

---

## Observações

- Cada exemplo é independente e **não requer integração com os outros módulos**.
- Alguns exemplos usam pacotes NuGet externos:
  - `EPPlus` para Excel.
  - `iTextSharp` para PDF.
  - `Microsoft.Data.SqlClient` e `Microsoft.Data.Sqlite` para bancos de dados.
- O objetivo principal é **estudo e referência de padrões de projeto** em cenários próximos do real.

---

## Autor

Carlos Tavares
