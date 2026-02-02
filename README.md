## **Padrões de Projetos de Software**

## **Padrões Criacionais**
- **Abstract Factory:** 
  - Fornece uma interface para criar famílias de objetos relacionados sem expor as classes concretas. Ideal quando você precisa garantir que os objetos criados sejam compatíveis entre si.
	Ex.: gerar relatórios em PDF e Excel, ou criar DAOs para diferentes tipos de banco (SQL Server, MySQL, etc).

- **Factory Method:** 
  - Define um método de criação em uma classe base, mas permite que as subclasses decidam qual classe concreta instanciar. Dá flexibilidade e facilita extensão sem alterar código existente.
	Ex.: criar contas bancárias (Corrente ou Poupança) ou conexões para diferentes bancos de dados.

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
