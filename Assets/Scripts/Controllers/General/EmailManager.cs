using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Class to control Email functions
/// </summary>
public class EmailManager
{

    /// <summary>
    /// Method to send email to the email register in the application
    /// Email contains leveldata information when level is finished
    /// </summary>
    /// <param name="data">Level data informatión</param>
    public static void Send(LevelData data)
    {
        string teacherEmail = PlayerPrefs.GetString("Email");
        if (teacherEmail != null && teacherEmail != "")
        {
            string team = PlayerPrefs.GetString("Device");

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("abctour.project@gmail.com");
            mail.To.Add(teacherEmail);
            mail.Subject = "Información equipo: " + team + " - Nivel - " + data.level.numberLevel + " - " + Utils.GetCurrentDate();
            mail.Body = "Nombre del equipo: " + team
            + "\nNivel: " + data.level.numberLevel
            + "\nNúmero de fallos: " + data.currentMisstakes
            + "\nTiempo para completar el nivel: " + Utils.GetTimeFormatted((int)data.time)
            + "\nFecha: " + data.date
            + "\nHora en la que inició: " + data.hour;

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("abctour.project@gmail.com", "abctour123!") as ICredentialsByHost;
            smtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    { return true; };
            smtpServer.Send(mail);
        }
    }
}