# TelegramBOT 
 
# C# Console APP .NET Framework 4.7.2 - MySQL - Telegram
 
 (Em desenvolvimento)
 
 # Bibliotecas:
- Microsoft.ToolKit
- MySql.Data
- Newtonsoft.Json
- System.Net.Http
 
 # Configurações:
 - 1- Abrir o telegram e abrir uma conversa com @BotFather
 - 2- Criar um novo bot
 - 3- Convidar o bot para um grupo à escolha.
 - 4- Copiar o token to access the HTTP API
 - 5- Colar no Program.cs em : private static readonly TelegramBotClient bot = new TelegramBotClient("TOKEN API AQUI");
 - 6- Alterar a string de ligação à base de dados em BaseDados.cs : string cs = @"server=localhost;userid=root;password=123456;database=bot";
 - 7- Correr o script para criar a base de dados.
 
 
 # Funcionalidades:
 - Sistema Anti-spam de video já enviados
 - API IPMA para obter a meteorologia (5 dias) por distrito
 - Hora atual
 - 5 ultimas noticias do site jornal de noticias através de RSS
 - Lista de administradores
 - Gerar chaves EuroMilhões
 - Mensagem personalizada de melhor grupo
 - Registo de mensagens enviadas para o grupo (utilizador, data, mensagem)
 - Numero de mensagens enviadas por um utilizador especifico
 
 # Comandos:
 (exemplo de comando Temperatura Lisboa)
 
 - Temperatura "localidade" 
 - Admins
 - Noticias
 - Euromilhoes
 - Horas
 - Melhor grupo
 - Mensagens
 
 
 
