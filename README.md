# Agendamento

# Template para Apps .Net Core 2.2

## Como utilizar

1. Copiar todos os arquivos para o seu reposit�rio
2. Colocar a sua aplica��o dentro do diret�rio src/
3. Referenciar a DLL da aplica��o no [Dockerfile](https://git.grupofleury.com.br/pipeline/templates/dotnet/blob/dotnet-2.0/Dockerfile#L8)
4. Adicionar o usu�rio registry_user como membro do projeto ou do grupo (role de Developer)
5. Configurar o arquivo [config.conf](https://git.grupofleury.com.br/pipeline/templates/dotnet/blob/dotnet-2.0/config.conf):

    `NAMESPACE = inserir o nome do projeto no Openshift (ex. agendamento, area-medica, internal, corporativo)`

    `CSPROJ = Indicar o caminho para o arquivo .csproj do seu projeto (ex. "./src/meuapp.csproj")`

6. Configurar variaveis de ambiente da aplica��o no arquivo [./openshift/configmap.yaml](https://git.grupofleury.com.br/pipeline/templates/dotnet/blob/dotnet-2.0/openshift/configmap.yaml), mantendo o formato no template existente.

    `SUA_VARIAVEL: "{{ SUA_VARIAVEL | default("VALOR PADRAO") }}"`

7. Criar uma branch com o nome "develop" � partir da master
8. Criar uma branch com o nome "homolog" � partir da master
9. Proteger todas as branches