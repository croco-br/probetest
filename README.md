# probetest
Cargox Coding Challenge

Esse projeto foi desenvolvido em .NET Core 3.0.

Para executá-lo sem o ecossitema .NET instalado, basta instalar o RUNTIME correspondente a sua plataforma: https://dotnet.microsoft.com/download/dotnet-core/3.0

Caso tenha o visual studio 2019 instalado, é possível executar direto pela IDE.

Para executá-lo basta chamar o executável com o comando abaixo, passando um caminho de arquivo como parâmetro.

Ex:
dotnet ExploringMars.dll "C:\input.txt"

Exemplo de input: <br/>
5 5 <br/>
1 2 N <br/>
LMLMLMLMM <br/>
3 3 E <br/>
MMRMMRMRRM <br/>


Retorno esperado:<br/>
1 3 N <br/>
5 1 E <br/>
