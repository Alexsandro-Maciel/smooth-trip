using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

public static class EnviarEmails
{
    public static string EnviarEmail(string email, string nomeUsuario)
    {
        Random random = new Random();
        string codigo = random.Next(100000, 1000000).ToString();

        //cria uma mensagem
        SmtpClient smtpClient = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("smoothtrip.senai@gmail.com", "vbxrjavsghmdriis")
        };

        MailMessage mail = new MailMessage();

        //define os endereços
        mail.From = new MailAddress("smoothtrip.senai@gmail.com");
        mail.To.Add("alexsandromaciel.m@gmail.com");

        //define o conteúdo
        mail.Subject = "Redefinição de Senha (Não Responda)";
        mail.Body = 
                    $"Olá {nomeUsuario}," +
                    $"Você solicitou a recuperação de senha segue o código para redefiní-la:" +
                    $"" +
                    $"" +
                    $"{codigo}" +
                    $"" +
                    $"" +
                    $"Se você não solicitou este código por favor entre em contato com o nosso suporte através do email:" +
                    $"smoothtrip.senai@gmail.com" +
                    $"" +
                    $"" +
                    $"" +
                    $"Att. Equipe de Suporte Smooth Trip." +
                    $"" +
                    $"NÃO RESPONDA ESSE EMAIL!"
                    ;

        //envia a mensagem
        smtpClient.Send(mail);

        return codigo;
    }
}
