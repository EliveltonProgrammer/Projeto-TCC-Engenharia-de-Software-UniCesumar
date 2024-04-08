<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<script runat="server">

public class ProductionData
{
   public int QuantityPieces { get; set; }
}

protected void Page_Load(object sender, EventArgs e)
{
    // Adicione uma mensagem de depuração para indicar que o script está sendo carregado
    Response.Write("Script ASP.NET carregado com sucesso!<br />");

    if (Request.HttpMethod == "POST" || Request.HttpMethod == "GET")
    {
        try
        {
            // Adicione uma mensagem de depuração para indicar que uma solicitação POST foi recebida
            Response.Write("Solicitação POST recebida!<br />");

            string requestBody = new StreamReader(Request.InputStream).ReadToEnd();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            
            // Modifique a desserialização para usar o tipo ProductionData
            ProductionData jsonData = serializer.Deserialize<ProductionData>(requestBody);

            int newQuantityPieces = jsonData.QuantityPieces;

            if (newQuantityPieces < 0)
            {
                Response.StatusCode = 400; // Bad Request
                Response.Write("{\"error\": \"QuantityPieces value must be non-negative\"}");
                Response.End();
                return;
            }

            // Caminho relativo para o arquivo JSON
            string filePath = Server.MapPath("~/Production.json");

            // Tratamento de exceções ao ler e escrever o arquivo
            try
            {
                dynamic jsonObject;
                using (StreamReader file = File.OpenText(filePath))
                {
                    jsonObject = serializer.Deserialize(file.ReadToEnd(), typeof(object));
                }
                jsonObject["QuantityPieces"] = newQuantityPieces;
                File.WriteAllText(filePath, serializer.Serialize(jsonObject));
            }
            catch (IOException ex)
            {
                LogException(ex);

                Response.StatusCode = 500; // Internal Server Error
                Response.Write("{\"error\": \"An error occurred while reading/writing the file. Please contact support.\"}");
                Response.End();
                return;
            }
            catch (Exception ex)
            {
                LogException(ex);

                Response.StatusCode = 500; // Internal Server Error
                Response.Write("{\"error\": \"An internal server error occurred. Please contact support.\"}");
                Response.End();
                return;
            }

            // Responder com sucesso
            Response.ContentType = "application/json";
            Response.Write("{\"status\": \"success\"}");
            Response.End();
        }
        catch (Exception ex)
        {
            LogException(ex);

            Response.StatusCode = 500; // Internal Server Error
            Response.Write("{\"error\": \"An internal server error occurred. Please contact support.\"}");
            Response.End();
        }
    }
    else
    {
        // Adicione uma mensagem de depuração para indicar que uma solicitação de método não permitido foi recebida
        Response.Write("Método não permitido!<br />");

        Response.StatusCode = 405; // Método não permitido
        Response.End();
    }
}

// Função para registrar exceções em um arquivo de log
protected void LogException(Exception ex)
{
    // Caminho para o arquivo de log
    string logFilePath = Server.MapPath("~/error.log");

    // Formatar a mensagem de log
    string logMessage = DateTime.Now + ": " + ex.ToString();

    // Escrever a mensagem de log no arquivo
    File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
}
</script>