- **AbstractFactory**
  - **DatabaseAndDaos**: Demonstra DAOs para SQL Server e SQLite usando Abstract Factory.
  - **Reports**: Demonstra geração de relatórios (Excel e PDF) usando Abstract Factory.

- **FactoryMethod**
  - **BankAccounts**: Criação de diferentes tipos de contas bancárias (Corrente e Poupança).
  - **Caches**: Criação de caches em memória ou banco de dados via Factory Method.
  - **DatabaseConnection**: Criação de conexões para SQL Server e SQLite via Factory Method.

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
