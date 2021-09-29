using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class SendEmail{
    public static void Send(LevelData data){
        string teacherEmail = PlayerPrefs.GetString("Email");
        if(teacherEmail != null && teacherEmail != ""){
            string team = PlayerPrefs.GetString("Device");

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("abctour.project@gmail.com");
            mail.To.Add(teacherEmail);
            mail.Subject = "Información equipo: " + team  + " - Nivel - " + data.level.numberLevel + " - " + Utils.GetCurrentDate();
            mail.Body = "Nombre del equipo: " + team
            + "\nNivel: " + data.level.numberLevel
            + "\nNúmero de fallos: " + data.currentMisstakes
            + "\nTiempo para completar el nivel: " + Utils.GetTimeFormatted((int) data.time)
            + "\nFecha: " + data.date
            + "\nHora en la que inició: " + data.hour;

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("abctour.project@gmail.com", "ABCTour123") as ICredentialsByHost;
            smtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = 
                delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
                    { return true; };
            smtpServer.Send(mail);
        }
    }
}